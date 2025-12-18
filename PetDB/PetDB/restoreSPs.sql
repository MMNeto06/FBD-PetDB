CREATE PROCEDURE PR_RestoreClinica
    @ClinicNIF INT,
    @RestoredBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM PETDB_ClinicaVeterinaria WHERE NIF = @ClinicNIF AND IsActive = 0)
    BEGIN
        RAISERROR('Clínica não existe ou já está ativa.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context 
        @key = N'ActionBy',
        @value = @RestoredBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_ClinicaVeterinaria
            SET IsActive = 1,
                DeletedAt = NULL,
                DeletedBy = NULL
            WHERE NIF = @ClinicNIF;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
    END CATCH

    PRINT 'Clínica restaurada com sucesso!';
END
GO

CREATE PROCEDURE PR_RestoreMedicoVeterinario
    @NumOMV INT,
    @RestoredBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1 
        FROM PETDB_MedicoVeterinario 
        WHERE NumOMV = @NumOMV AND IsActive = 0
    )
    BEGIN
        RAISERROR('Médico veterinário não existe ou já está ativo.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context 
        @key = N'ActionBy',
        @value = @RestoredBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_MedicoVeterinario
            SET IsActive = 1,
                DeletedAt = NULL,
                DeletedBy = NULL
            WHERE NumOMV = @NumOMV;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
    END CATCH

    PRINT 'Médico veterinário restaurado com sucesso!';
END
GO