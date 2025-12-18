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
        RAISERROR('Ocorreu um erro, operação cancelada!', 16, 1);
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
        RAISERROR('Ocorreu um erro, operação cancelada!', 16, 1);
    END CATCH

    PRINT 'Médico veterinário restaurado com sucesso!';
END
GO

CREATE PROCEDURE PR_RestoreDono
    @DonoNIF INT,
    @RestoredBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1 
        FROM PETDB_Dono 
        WHERE NIF = @DonoNIF AND IsActive = 0
    )
    BEGIN
        RAISERROR('Dono não existe ou já está ativo.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context 
        @key = N'ActionBy',
        @value = @RestoredBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_Dono
            SET IsActive = 1,
                DeletedAt = NULL,
                DeletedBy = NULL
            WHERE NIF = @DonoNIF;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
        RAISERROR('Ocorreu um erro, operação cancelada!', 16, 1);
    END CATCH

    PRINT 'Dono restaurado com sucesso.';
END
GO

CREATE PROCEDURE PR_RestoreAnimal
    @AnimalNumero INT,
    @RestoredBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM PETDB_Animal
        WHERE Numero = @AnimalNumero AND IsActive = 0
    )
    BEGIN
        RAISERROR('Animal não existe ou já está ativo.', 16, 1);
        RETURN;
    END

    IF EXISTS (
        SELECT 1
        FROM PETDB_Animal as A
        JOIN PETDB_Dono as D ON A.Dono = D.NIF
        JOIN PETDB_Especie as E ON A.Especie = E.Codigo
        WHERE A.Numero = @AnimalNumero
          AND (D.IsActive = 0 OR E.IsActive = 0)
    )
    BEGIN
        RAISERROR('Não é possível restaurar o animal: Dono ou Espécie estão desativados.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context
        @key = N'ActionBy',
        @value = @RestoredBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_Animal
            SET IsActive = 1,
                DeletedAt = NULL,
                DeletedBy = NULL
            WHERE Numero = @AnimalNumero;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
        RAISERROR('Ocorreu um erro, operação cancelada!', 16, 1);
    END CATCH

    PRINT 'Animal restaurado com sucesso.';
END
GO

CREATE PROCEDURE PR_RestoreMedicamento
    @MedicamentoCodigo INT,
    @RestoredBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM PETDB_Medicamento
        WHERE Codigo = @MedicamentoCodigo AND IsActive = 0
    )
    BEGIN
        RAISERROR('Medicamento não existe ou já está ativo.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context
        @key = N'ActionBy',
        @value = @RestoredBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_Medicamento
            SET IsActive = 1,
                DeletedAt = NULL,
                DeletedBy = NULL
            WHERE Codigo = @MedicamentoCodigo;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
        RAISERROR('Ocorreu um erro, operação cancelada!', 16, 1);
    END CATCH

    PRINT 'Medicamento restaurado com sucesso.';
END
GO

CREATE PROCEDURE PR_RestoreConsulta
    @ConsultaId INT,
    @RestoredBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM PETDB_Consulta
        WHERE Id = @ConsultaId AND IsActive = 0
    )
    BEGIN
        RAISERROR('Consulta não existe ou já está ativa.', 16, 1);
        RETURN;
    END

    IF EXISTS (
        SELECT 1
        FROM PETDB_Consulta as C
        JOIN PETDB_Animal as A ON C.Animal = A.Numero
        JOIN PETDB_MedicoVeterinario as M ON C.Medico = M.NumOMV
        WHERE C.Id = @ConsultaId
          AND (A.IsActive = 0 OR M.IsActive = 0)
    )
    BEGIN
        RAISERROR('Não é possível restaurar a consulta: Animal ou Médico estão desativados.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context
        @key = N'ActionBy',
        @value = @RestoredBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_Consulta
            SET IsActive = 1,
                DeletedAt = NULL,
                DeletedBy = NULL
            WHERE Id = @ConsultaId;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
        RAISERROR('Ocorreu um erro, operação cancelada!', 16, 1);
    END CATCH

    PRINT 'Consulta restaurada com sucesso!';
END
GO

CREATE PROCEDURE PR_RestorePagamento
    @PagamentoId INT,
    @RestoredBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM PETDB_Pagamento
        WHERE Id = @PagamentoId AND IsActive = 0
    )
    BEGIN
        RAISERROR('Pagamento não existe ou já está ativo.', 16, 1);
        RETURN;
    END

    IF EXISTS (
        SELECT 1
        FROM PETDB_Pagamento as P
        JOIN PETDB_Consulta as C ON P.Consulta = C.Id
        WHERE P.Id = @PagamentoId
          AND C.IsActive = 0
    )
    BEGIN
        RAISERROR('Não é possível restaurar o pagamento: a consulta associada está desativada.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context
        @key = N'ActionBy',
        @value = @RestoredBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_Pagamento
            SET IsActive = 1,
                DeletedAt = NULL,
                DeletedBy = NULL
            WHERE Id = @PagamentoId;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
        RAISERROR('Ocorreu um erro, operação cancelada!', 16, 1);
    END CATCH

    PRINT 'Pagamento restaurado com sucesso!';
END
GO

CREATE PROCEDURE PR_RestorePrescricao
    @PrescricaoNumero INT,
    @RestoredBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM PETDB_Prescricao
        WHERE Numero = @PrescricaoNumero AND IsActive = 0
    )
    BEGIN
        RAISERROR('Prescrição não existe ou já está ativa.', 16, 1);
        RETURN;
    END

    IF EXISTS (
        SELECT 1
        FROM PETDB_Prescricao as P
        JOIN PETDB_Animal as A ON P.Animal = A.Numero
        WHERE P.Numero = @PrescricaoNumero
          AND A.IsActive = 0
    )
    BEGIN
        RAISERROR('Não é possível restaurar a prescrição: o animal associado está desativado.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context
        @key = N'ActionBy',
        @value = @RestoredBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_Prescricao
            SET IsActive = 1,
                DeletedAt = NULL,
                DeletedBy = NULL
            WHERE Numero = @PrescricaoNumero;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
        RAISERROR('Ocorreu um erro, operação cancelada!', 16, 1);
    END CATCH

    PRINT 'Prescrição restaurada com sucesso.';
END
GO

CREATE PROCEDURE PR_RestoreEspecialidade
    @EspecialidadeCodigo INT,
    @RestoredBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM PETDB_Especialidade
        WHERE Codigo = @EspecialidadeCodigo AND IsActive = 0
    )
    BEGIN
        RAISERROR('Especialidade não existe ou já está ativa.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context
        @key = N'ActionBy',
        @value = @RestoredBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_Especialidade
            SET IsActive = 1,
                DeletedAt = NULL,
                DeletedBy = NULL
            WHERE Codigo = @EspecialidadeCodigo;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
        RAISERROR('Ocorreu um erro, operação cancelada!', 16, 1);
    END CATCH

    PRINT 'Especialidade restaurada com sucesso!';
END
GO

CREATE PROCEDURE PR_RestoreEspecie
    @EspecieCodigo INT,
    @RestoredBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM PETDB_Especie
        WHERE Codigo = @EspecieCodigo AND IsActive = 0
    )
    BEGIN
        RAISERROR('Espécie não existe ou já está ativa.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context
        @key = N'ActionBy',
        @value = @RestoredBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_Especie
            SET IsActive = 1,
                DeletedAt = NULL,
                DeletedBy = NULL
            WHERE Codigo = @EspecieCodigo;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
        RAISERROR('Ocorreu um erro, operação cancelada!', 16, 1);
    END CATCH

    PRINT 'Espécie restaurada com sucesso!';
END
GO

CREATE PROCEDURE PR_RestoreMetodoPagamento
    @MetodoPagamentoCodigo INT,
    @RestoredBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM PETDB_MetodoPagamento
        WHERE Codigo = @MetodoPagamentoCodigo AND IsActive = 0
    )
    BEGIN
        RAISERROR('Método de pagamento não existe ou já está ativo.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context
        @key = N'ActionBy',
        @value = @RestoredBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_MetodoPagamento
            SET IsActive = 1,
                DeletedAt = NULL,
                DeletedBy = NULL
            WHERE Codigo = @MetodoPagamentoCodigo;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
        RAISERROR('Ocorreu um erro, operação cancelada!', 16, 1);
    END CATCH

    PRINT 'Método de pagamento restaurado com sucesso!';
END
GO

CREATE PROCEDURE PR_RestoreTratamento
    @TratamentoCodigo INT,
    @RestoredBy VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM PETDB_Tratamento
        WHERE Codigo = @TratamentoCodigo AND IsActive = 0
    )
    BEGIN
        RAISERROR('Tratamento não existe ou já está ativo.', 16, 1);
        RETURN;
    END

    EXEC sys.sp_set_session_context
        @key = N'ActionBy',
        @value = @RestoredBy;

    BEGIN TRY
        BEGIN TRANSACTION SCHEDULEUPDATE
            UPDATE PETDB_Tratamento
            SET IsActive = 1,
                DeletedAt = NULL,
                DeletedBy = NULL
            WHERE Codigo = @TratamentoCodigo;
        COMMIT TRANSACTION SCHEDULEUPDATE
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION SCHEDULEUPDATE
        RAISERROR('Ocorreu um erro, operação cancelada!', 16, 1);
    END CATCH

    PRINT 'Tratamento restaurado com sucesso.';
END
GO
