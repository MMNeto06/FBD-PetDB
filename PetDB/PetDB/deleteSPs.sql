CREATE PROCEDURE PR_SoftDeleteClinica
    @ClinicNIF INT,
    @DeletedBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM PETDB_ClinicaVeterinaria WHERE NIF = @ClinicNIF AND IsActive = 1)
    BEGIN
        RAISERROR('Clínica não existe ou já está desativada.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM PETDB_MedicoVeterinario WHERE Clinica = @ClinicNIF AND IsActive = 1)
    BEGIN
        BEGIN TRY
			BEGIN TRANSACTION SCHEDULEUPDATE
				UPDATE PETDB_ClinicaVeterinaria
				SET IsActive = 0,
					DeletedAt = GETDATE(),
					DeletedBy = @DeletedBy
				WHERE NIF = @ClinicNIF;
			COMMIT TRANSACTION SCHEDULEUPDATE
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION SCHEDULEUPDATE
		END CATCH 

        PRINT 'Clínica desativada com sucesso. Médicos associados permanecem ativos.';
    END
    ELSE
    BEGIN
		BEGIN TRY 
			BEGIN TRANSACTION SCHEDULEDELETE
				UPDATE PETDB_ClinicaVeterinaria
				SET IsActive = 0,
					DeletedAt = GETDATE(),
					DeletedBy = @DeletedBy
				WHERE NIF = @ClinicNIF;

				DELETE FROM PETDB_ClinicaVeterinaria
				WHERE NIF = @ClinicNIF;
			COMMIT TRANSACTION SCHEDULEDELETE
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION SCHEDULEDELETE
		END CATCH

        PRINT 'Clínica removida com sucesso!';
    END
END
GO


