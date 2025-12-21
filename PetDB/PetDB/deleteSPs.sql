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

    EXEC sys.sp_set_session_context 
	@key = N'ActionBy',
	@value = @DeletedBy;

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

CREATE PROCEDURE PR_SoftDeleteMedicoVeterinario
    @NumOMV INT,
    @DeletedBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM PETDB_MedicoVeterinario WHERE NumOMV = @NumOMV AND IsActive = 1)
    BEGIN
        RAISERROR('Médico não existe ou já está inativo.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context
        @key = N'ActionBy',
        @value = @DeletedBy;

    IF EXISTS (
        SELECT 1 FROM PETDB_Consulta WHERE Medico = @NumOMV
    )
    OR EXISTS (
        SELECT 1 FROM PETDB_Prescricao WHERE VetOMV = @NumOMV
    )
    BEGIN
        BEGIN TRY 
            BEGIN TRANSACTION SCHEDULEUPDATE
                UPDATE PETDB_MedicoVeterinario
                SET IsActive = 0,
                    DeletedAt = GETDATE(),
                    DeletedBy = @DeletedBy
                WHERE NumOMV = @NumOMV;

                PRINT 'Médico desativado com sucesso! Existem dependentes ativos.';
            COMMIT TRANSACTION SCHEDULEUPDATE
        END TRY
        BEGIN CATCH 
            ROLLBACK TRANSACTION SCHEDULEUPDATE
        END CATCH 
    END
    ELSE
    BEGIN
        BEGIN TRY 
            BEGIN TRANSACTION SCHEDULEDELETE
                DELETE FROM PETDB_MedicoVeterinario
                WHERE NumOMV = @NumOMV;

                PRINT 'Médico removido com sucesso!';
            COMMIT TRANSACTION SCHEDULEDELETE
        END TRY 
        BEGIN CATCH 
            ROLLBACK TRANSACTION SCHEDULEDELETE
        END CATCH 
    END
END
GO

CREATE PROCEDURE PR_SoftDeleteAnimal
    @Numero INT,
    @DeletedBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1 
        FROM PETDB_Animal 
        WHERE Numero = @Numero AND IsActive = 1
    )
    BEGIN
        RAISERROR('Animal não existe ou já está inativo.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context
        @key = N'ActionBy',
        @value = @DeletedBy;

    IF EXISTS (
        SELECT 1 FROM PETDB_Consulta WHERE Animal = @Numero
    )
    OR EXISTS (
        SELECT 1 FROM PETDB_Prescricao WHERE Animal = @Numero
    )
    BEGIN
        BEGIN TRY 
            BEGIN TRANSACTION SCHEDULEUPDATE
                UPDATE PETDB_Animal
                SET IsActive = 0,
                    DeletedAt = GETDATE(),
                    DeletedBy = @DeletedBy
                WHERE Numero = @Numero;

                PRINT 'Animal desativado com sucesso! Existem dependentes ativos.';
            COMMIT TRANSACTION SCHEDULEUPDATE
        END TRY
        BEGIN CATCH 
            ROLLBACK TRANSACTION SCHEDULEUPDATE
        END CATCH 
    END
    ELSE
    BEGIN
        BEGIN TRY 
            BEGIN TRANSACTION SCHEDULEDELETE
                DELETE FROM PETDB_Animal
                WHERE Numero = @Numero;

                PRINT 'Animal removido com sucesso!';
            COMMIT TRANSACTION SCHEDULEDELETE
        END TRY 
        BEGIN CATCH 
            ROLLBACK TRANSACTION SCHEDULEDELETE
        END CATCH 
    END
END
GO

CREATE PROCEDURE PR_SoftDeleteDono
    @NIF INT,
    @DeletedBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1 
        FROM PETDB_Dono 
        WHERE NIF = @NIF AND IsActive = 1
    )
    BEGIN
        RAISERROR('Dono não existe ou já está inativo.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context
        @key = N'ActionBy',
        @value = @DeletedBy;

    IF EXISTS (
        SELECT 1 FROM PETDB_Animal WHERE Dono = @NIF
    )
    BEGIN
        BEGIN TRY 
            BEGIN TRANSACTION SCHEDULEUPDATE
                UPDATE PETDB_Dono
                SET IsActive = 0,
                    DeletedAt = GETDATE(),
                    DeletedBy = @DeletedBy
                WHERE NIF = @NIF;

                PRINT 'Dono desativado com sucesso! Existem dependentes ativos.';
            COMMIT TRANSACTION SCHEDULEUPDATE
        END TRY
        BEGIN CATCH 
            ROLLBACK TRANSACTION SCHEDULEUPDATE
        END CATCH 
    END
    ELSE
    BEGIN
        BEGIN TRY 
            BEGIN TRANSACTION SCHEDULEDELETE
                DELETE FROM PETDB_Dono
                WHERE NIF = @NIF;

                PRINT 'Dono removido com sucesso!';
            COMMIT TRANSACTION SCHEDULEDELETE
        END TRY 
        BEGIN CATCH 
            ROLLBACK TRANSACTION SCHEDULEDELETE
        END CATCH 
    END
END
GO

CREATE PROCEDURE PR_SoftDeleteMedicamento
    @Codigo INT,
    @DeletedBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1 
        FROM PETDB_Medicamento 
        WHERE Codigo = @Codigo AND IsActive = 1
    )
    BEGIN
        RAISERROR('Medicamento não existe ou já está inativo.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context
        @key = N'ActionBy',
        @value = @DeletedBy;

    IF EXISTS (
        SELECT 1 
        FROM PETDB_PrescricaoMedicamento 
        WHERE CodigoMedicamento = @Codigo
    )
    BEGIN
        BEGIN TRY 
            BEGIN TRANSACTION SCHEDULEUPDATE
                UPDATE PETDB_Medicamento
                SET IsActive = 0,
                    DeletedAt = GETDATE(),
                    DeletedBy = @DeletedBy
                WHERE Codigo = @Codigo;

                PRINT 'Medicamento desativado com sucesso!';
            COMMIT TRANSACTION SCHEDULEUPDATE
        END TRY
        BEGIN CATCH 
            ROLLBACK TRANSACTION SCHEDULEUPDATE
        END CATCH 
    END
    ELSE
    BEGIN
        BEGIN TRY 
            BEGIN TRANSACTION SCHEDULEDELETE
                DELETE FROM PETDB_Medicamento
                WHERE Codigo = @Codigo;

                PRINT 'Medicamento removido com sucesso!';
            COMMIT TRANSACTION SCHEDULEDELETE
        END TRY 
        BEGIN CATCH 
            ROLLBACK TRANSACTION SCHEDULEDELETE
        END CATCH 
    END
END
GO

CREATE PROCEDURE PR_SoftDeleteConsulta
    @ConsultaId INT,
    @DeletedBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM PETDB_Consulta WHERE Id = @ConsultaId AND IsActive = 1)
    BEGIN
        RAISERROR('Consulta não existe ou já está desativada.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context 
        @key = N'ActionBy',
        @value = @DeletedBy;

    IF EXISTS (SELECT 1 FROM PETDB_Pagamento WHERE Consulta = @ConsultaId AND IsActive = 1)
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION SCHEDULEDELETE
                UPDATE PETDB_Consulta
                SET IsActive = 0,
                    DeletedAt = GETDATE(),
                    DeletedBy = @DeletedBy
                WHERE Id = @ConsultaId;
            COMMIT TRANSACTION SCHEDULEDELETE
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION SCHEDULEDELETE
        END CATCH

        PRINT 'Consulta desativada com sucesso. Existem dependentes ativos.';
    END
    ELSE
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION SCHEDULEDELETE
                DELETE FROM PETDB_Relatorio
                WHERE Consulta = @ConsultaId;

                DELETE FROM PETDB_Consulta
                WHERE Id = @ConsultaId;
            COMMIT TRANSACTION SCHEDULEDELETE
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION SCHEDULEDELETE
        END CATCH

        PRINT 'Consulta removida com sucesso!';
    END
END
GO

CREATE PROCEDURE PR_SoftDeletePagamento
    @PagamentoId INT,
    @DeletedBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM PETDB_Pagamento WHERE Id = @PagamentoId AND IsActive = 1)
    BEGIN
        RAISERROR('Pagamento não existe ou já está desativado.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context 
        @key = N'ActionBy',
        @value = @DeletedBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_Pagamento
            SET IsActive = 0,
                DeletedAt = GETDATE(),
                DeletedBy = @DeletedBy
            WHERE Id = @PagamentoId;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
    END CATCH

    PRINT 'Pagamento arquivado com sucesso.';
END
GO

CREATE PROCEDURE PR_SoftDeletePrescricao
    @PrescricaoNumero INT,
    @DeletedBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM PETDB_Prescricao WHERE Numero = @PrescricaoNumero AND IsActive = 1)
    BEGIN
        RAISERROR('Prescrição não existe ou já está desativada.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context 
        @key = N'ActionBy',
        @value = @DeletedBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_Prescricao
            SET IsActive = 0,
                DeletedAt = GETDATE(),
                DeletedBy = @DeletedBy
            WHERE Numero = @PrescricaoNumero;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
    END CATCH

    PRINT 'Prescrição arquivada com sucesso.';
END
GO

CREATE PROCEDURE PR_SoftDeleteEspecialidade
    @EspecialidadeCodigo INT,
    @DeletedBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM PETDB_Especialidade WHERE Codigo = @EspecialidadeCodigo AND IsActive = 1)
    BEGIN
        RAISERROR('Especialidade não existe ou já está desativada.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context 
        @key = N'ActionBy',
        @value = @DeletedBy;

    IF EXISTS (SELECT 1 FROM PETDB_MedicoVeterinario WHERE Especialidade = @EspecialidadeCodigo AND IsActive = 1)
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION SCHEDULEUPDATE
                UPDATE PETDB_Especialidade
                SET IsActive = 0,
                    DeletedAt = GETDATE(),
                    DeletedBy = @DeletedBy
                WHERE Codigo = @EspecialidadeCodigo;
            COMMIT TRANSACTION SCHEDULEUPDATE
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION SCHEDULEUPDATE
        END CATCH

        PRINT 'Especialidade desativada com sucesso. Existem médicos associados ativos.';
    END
    ELSE
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION SCHEDULEDELETE
                DELETE FROM PETDB_Especialidade
                WHERE Codigo = @EspecialidadeCodigo;
            COMMIT TRANSACTION SCHEDULEDELETE
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION SCHEDULEDELETE
        END CATCH

        PRINT 'Especialidade removida com sucesso!';
    END
END
GO

CREATE PROCEDURE PR_SoftDeleteEspecie
    @EspecieCodigo INT,
    @DeletedBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM PETDB_Especie WHERE Codigo = @EspecieCodigo AND IsActive = 1)
    BEGIN
        RAISERROR('Espécie não existe ou já está desativada.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context 
        @key = N'ActionBy',
        @value = @DeletedBy;

    IF EXISTS (SELECT 1 FROM PETDB_Animal WHERE Especie = @EspecieCodigo AND IsActive = 1)
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION SCHEDULEUPDATE
                UPDATE PETDB_Especie
                SET IsActive = 0,
                    DeletedAt = GETDATE(),
                    DeletedBy = @DeletedBy
                WHERE Codigo = @EspecieCodigo;
            COMMIT TRANSACTION SCHEDULEUPDATE
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION SCHEDULEUPDATE
        END CATCH

        PRINT 'Espécie desativada com sucesso. Existem animais associados ativos.';
    END
    ELSE
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION SCHEDULEDELETE
                DELETE FROM PETDB_Especie
                WHERE Codigo = @EspecieCodigo;
            COMMIT TRANSACTION SCHEDULEDELETE
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION SCHEDULEDELETE
        END CATCH

        PRINT 'Espécie removida com sucesso!';
    END
END
GO

CREATE PROCEDURE PR_SoftDeleteMetodoPagamento
    @MetodoCodigo INT,
    @DeletedBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM PETDB_MetodoPagamento WHERE Codigo = @MetodoCodigo AND IsActive = 1)
    BEGIN
        RAISERROR('Método de pagamento não existe ou já está desativado.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context 
        @key = N'ActionBy',
        @value = @DeletedBy;

    IF EXISTS (SELECT 1 FROM PETDB_Pagamento WHERE MetodoPagamento = @MetodoCodigo AND IsActive = 1)
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION SCHEDULEUPDATE
                UPDATE PETDB_MetodoPagamento
                SET IsActive = 0,
                    DeletedAt = GETDATE(),
                    DeletedBy = @DeletedBy
                WHERE Codigo = @MetodoCodigo;
            COMMIT TRANSACTION SCHEDULEUPDATE
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION SCHEDULEUPDATE
        END CATCH

        PRINT 'Método de pagamento desativado com sucesso. Existem pagamentos associados ativos.';
    END
    ELSE
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION SCHEDULEDELETE
                DELETE FROM PETDB_MetodoPagamento
                WHERE Codigo = @MetodoCodigo;
            COMMIT TRANSACTION SCHEDULEDELETE
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION SCHEDULEDELETE
        END CATCH

        PRINT 'Método de pagamento removido com sucesso!';
    END
END
GO

CREATE PROCEDURE PR_SoftDeleteTratamento
    @TratamentoCodigo INT,
    @DeletedBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM PETDB_Tratamento WHERE Codigo = @TratamentoCodigo AND IsActive = 1)
    BEGIN
        RAISERROR('Tratamento não existe ou já está desativado.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context 
        @key = N'ActionBy',
        @value = @DeletedBy;

    IF EXISTS (SELECT 1 FROM PETDB_ConsultaTratamento WHERE CodigoTratamento = @TratamentoCodigo)
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION SCHEDULEUPDATE
                UPDATE PETDB_Tratamento
                SET IsActive = 0,
                    DeletedAt = GETDATE(),
                    DeletedBy = @DeletedBy
                WHERE Codigo = @TratamentoCodigo;
            COMMIT TRANSACTION SCHEDULEUPDATE
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION SCHEDULEUPDATE
        END CATCH

        PRINT 'Tratamento desativado com sucesso. Existem consultas associadas.';
    END
    ELSE
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION SCHEDULEDELETE
                DELETE FROM PETDB_Tratamento
                WHERE Codigo = @TratamentoCodigo;
            COMMIT TRANSACTION SCHEDULEDELETE
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION SCHEDULEDELETE
        END CATCH

        PRINT 'Tratamento removido com sucesso!';
    END
END
GO

CREATE PROCEDURE PR_RemoveTreatmentFromAppointment
    (@TreatmentID int, @AppointmentID int) 
AS
BEGIN 
    SET NOCOUNT ON; 

    IF NOT EXISTS (SELECT 1 FROM PETDB_Tratamento WHERE Codigo = @TreatmentID) 
    BEGIN 
        RAISERROR('Esse tratamento não existe!', 16, 1); 
        RETURN; 
    END

    IF NOT EXISTS (SELECT 1 FROM PETDB_Consulta WHERE Id = @AppointmentID) 
    BEGIN 
        RAISERROR('Essa consulta não existe!', 16, 1); 
        RETURN; 
    END 

    BEGIN TRY 
        BEGIN TRANSACTION SCHEDULEDELETE 
            DELETE FROM PETDB_ConsultaTratamento
            WHERE (IdConsulta = @AppointmentID AND CodigoTratamento = @TreatmentID); 
        COMMIT TRANSACTION SCHEDULEDELETE
    END TRY
    BEGIN CATCH 
        ROLLBACK TRANSACTION SCHEDULEDELETE
        RAISERROR('Não foi possível concluir a operação.', 16, 1); 
    END CATCH 

    PRINT 'Tratamento removido da consulta com sucesso!'; 
END
GO

CREATE PROCEDURE PR_RemoveMedFromPrescription
    (@PrescriptionID int, @MedID int) 
AS
BEGIN 
    SET NOCOUNT ON; 

    IF NOT EXISTS (SELECT 1 FROM PETDB_Prescricao WHERE Numero = @PrescriptionID) 
    BEGIN 
        RAISERROR('Essa prescrição não existe!', 16, 1); 
        RETURN; 
    END

    IF NOT EXISTS (SELECT 1 FROM PETDB_Medicamento WHERE Codigo = @MedID) 
    BEGIN 
        RAISERROR('Esse medicamento não existe!', 16, 1); 
        RETURN; 
    END 

    BEGIN TRY 
        BEGIN TRANSACTION SCHEDULEDELETE 
            DELETE FROM PETDB_PrescricaoMedicamento
            WHERE (NumeroPrescricao = @PrescriptionID AND CodigoMedicamento = @MedID); 
        COMMIT TRANSACTION SCHEDULEDELETE
    END TRY
    BEGIN CATCH 
        ROLLBACK TRANSACTION SCHEDULEDELETE
        RAISERROR('Não foi possível concluir a operação.', 16, 1); 
    END CATCH 

    PRINT 'Medicamento removido da prescrição com sucesso!'; 
END