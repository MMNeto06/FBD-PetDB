CREATE TRIGGER TR_Audit_ClinicaVeterinaria
ON PETDB_ClinicaVeterinaria
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionBy VARCHAR(64);
    SELECT @ActionBy = CAST(SESSION_CONTEXT(N'ActionBy') AS VARCHAR(64));
    SET @ActionBy = COALESCE(@ActionBy, SUSER_SNAME());

    -- Soft delete 
    INSERT INTO PETDB_Audit_ClinicaVeterinaria
    (
        NIF, Nome, Telefone, Email, Endereco,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.NIF, i.Nome, i.Telefone, i.Email, i.Endereco,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'UPDATE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.NIF = d.NIF
    WHERE i.IsActive = 0 AND d.IsActive = 1;

    -- Restore
    INSERT INTO PETDB_Audit_ClinicaVeterinaria
    (
        NIF, Nome, Telefone, Email, Endereco,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.NIF, i.Nome, i.Telefone, i.Email, i.Endereco,
        i.IsActive, NULL, NULL,
        'RESTORE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.NIF = d.NIF
    WHERE i.IsActive = 1 AND d.IsActive = 0;

    -- Delete
    INSERT INTO PETDB_Audit_ClinicaVeterinaria
    (
        NIF, Nome, Telefone, Email, Endereco,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        d.NIF, d.Nome, d.Telefone, d.Email, d.Endereco,
        d.IsActive, GETDATE(), @ActionBy,
        'DELETE', @ActionBy
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted i WHERE i.NIF = d.NIF);
END
GO

CREATE TRIGGER TR_Audit_MedicoVeterinario
ON PETDB_MedicoVeterinario
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionBy VARCHAR(64);

    SELECT @ActionBy = CAST(SESSION_CONTEXT(N'ActionBy') AS VARCHAR(64));
    SET @ActionBy = COALESCE(@ActionBy, SUSER_SNAME());

    INSERT INTO PETDB_Audit_MedicoVeterinario
    (
        NumOMV, Nome, Telefone, Email,
        Especialidade, Clinica,
        IsActive, DeletedAt, DeletedBy,
        ActionType, ActionBy
    )
    SELECT
        i.NumOMV, i.Nome, i.Telefone, i.Email,
        i.Especialidade, i.Clinica,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'UPDATE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.NumOMV = d.NumOMV
    WHERE i.IsActive = 0
      AND d.IsActive = 1;

    INSERT INTO PETDB_Audit_MedicoVeterinario
    (
        NumOMV, Nome, Telefone, Email,
        Especialidade, Clinica,
        IsActive,
        ActionType, ActionBy
    )
    SELECT
        i.NumOMV, i.Nome, i.Telefone, i.Email,
        i.Especialidade, i.Clinica,
        i.IsActive,
        'RESTORE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.NumOMV = d.NumOMV
    WHERE i.IsActive = 1
      AND d.IsActive = 0;


    INSERT INTO PETDB_Audit_MedicoVeterinario
    (
        NumOMV, Nome, Telefone, Email,
        Especialidade, Clinica,
        IsActive, DeletedAt, DeletedBy,
        ActionType, ActionBy
    )
    SELECT
        d.NumOMV, d.Nome, d.Telefone, d.Email,
        d.Especialidade, d.Clinica,
        d.IsActive,
        GETDATE(), @ActionBy,
        'DELETE', @ActionBy
    FROM deleted d
    WHERE NOT EXISTS (
        SELECT 1 FROM inserted i WHERE i.NumOMV = d.NumOMV
    );
END
GO

CREATE TRIGGER TR_Audit_Animal
ON PETDB_Animal
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionBy VARCHAR(64);

    SELECT @ActionBy = CAST(SESSION_CONTEXT(N'ActionBy') AS VARCHAR(64));
    SET @ActionBy = COALESCE(@ActionBy, SUSER_SNAME());


    INSERT INTO PETDB_Audit_Animal
    (
        Numero, Nome, DataNascimento, Peso, Sexo,
        Especie, Dono,
        IsActive, DeletedAt, DeletedBy,
        ActionType, ActionBy
    )
    SELECT
        i.Numero, i.Nome, i.DataNascimento, i.Peso, i.Sexo,
        i.Especie, i.Dono,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'UPDATE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Numero = d.Numero
    WHERE i.IsActive = 0
      AND d.IsActive = 1;

    INSERT INTO PETDB_Audit_Animal
    (
        Numero, Nome, DataNascimento, Peso, Sexo,
        Especie, Dono,
        IsActive,
        ActionType, ActionBy
    )
    SELECT
        i.Numero, i.Nome, i.DataNascimento, i.Peso, i.Sexo,
        i.Especie, i.Dono,
        i.IsActive,
        'RESTORE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Numero = d.Numero
    WHERE i.IsActive = 1
      AND d.IsActive = 0;

    INSERT INTO PETDB_Audit_Animal
    (
        Numero, Nome, DataNascimento, Peso, Sexo,
        Especie, Dono,
        IsActive, DeletedAt, DeletedBy,
        ActionType, ActionBy
    )
    SELECT
        d.Numero, d.Nome, d.DataNascimento, d.Peso, d.Sexo,
        d.Especie, d.Dono,
        d.IsActive,
        GETDATE(), @ActionBy,
        'DELETE', @ActionBy
    FROM deleted d
    WHERE NOT EXISTS (
        SELECT 1 FROM inserted i WHERE i.Numero = d.Numero
    );
END
GO

CREATE TRIGGER TR_Audit_Dono
ON PETDB_Dono
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionBy VARCHAR(64);

    SELECT @ActionBy = CAST(SESSION_CONTEXT(N'ActionBy') AS VARCHAR(64));
    SET @ActionBy = COALESCE(@ActionBy, SUSER_SNAME());

    INSERT INTO PETDB_Audit_Dono
    (
        NIF, Nome, Telefone, Email, Endereco,
        IsActive, DeletedAt, DeletedBy,
        ActionType, ActionBy
    )
    SELECT
        i.NIF, i.Nome, i.Telefone, i.Email, i.Endereco,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'UPDATE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.NIF = d.NIF
    WHERE i.IsActive = 0
      AND d.IsActive = 1;

    INSERT INTO PETDB_Audit_Dono
    (
        NIF, Nome, Telefone, Email, Endereco,
        IsActive,
        ActionType, ActionBy
    )
    SELECT
        i.NIF, i.Nome, i.Telefone, i.Email, i.Endereco,
        i.IsActive,
        'RESTORE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.NIF = d.NIF
    WHERE i.IsActive = 1
      AND d.IsActive = 0;

    INSERT INTO PETDB_Audit_Dono
    (
        NIF, Nome, Telefone, Email, Endereco,
        IsActive, DeletedAt, DeletedBy,
        ActionType, ActionBy
    )
    SELECT
        d.NIF, d.Nome, d.Telefone, d.Email, d.Endereco,
        d.IsActive,
        GETDATE(), @ActionBy,
        'DELETE', @ActionBy
    FROM deleted d
    WHERE NOT EXISTS (
        SELECT 1 FROM inserted i WHERE i.NIF = d.NIF
    );
END
GO

CREATE TRIGGER TR_Audit_Medicamento
ON PETDB_Medicamento
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionBy VARCHAR(64);

    SELECT @ActionBy = CAST(SESSION_CONTEXT(N'ActionBy') AS VARCHAR(64));
    SET @ActionBy = COALESCE(@ActionBy, SUSER_SNAME());

    INSERT INTO PETDB_Audit_Medicamento
    (
        Codigo, Descricao, Dose,
        IsActive, DeletedAt, DeletedBy,
        ActionType, ActionBy
    )
    SELECT
        i.Codigo, i.Descricao, i.Dose,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'UPDATE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Codigo = d.Codigo
    WHERE i.IsActive = 0
      AND d.IsActive = 1;


    INSERT INTO PETDB_Audit_Medicamento
    (
        Codigo, Descricao, Dose,
        IsActive,
        ActionType, ActionBy
    )
    SELECT
        i.Codigo, i.Descricao, i.Dose,
        i.IsActive,
        'RESTORE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Codigo = d.Codigo
    WHERE i.IsActive = 1
      AND d.IsActive = 0;

    INSERT INTO PETDB_Audit_Medicamento
    (
        Codigo, Descricao, Dose,
        IsActive, DeletedAt, DeletedBy,
        ActionType, ActionBy
    )
    SELECT
        d.Codigo, d.Descricao, d.Dose,
        d.IsActive,
        GETDATE(), @ActionBy,
        'DELETE', @ActionBy
    FROM deleted d
    WHERE NOT EXISTS (
        SELECT 1 FROM inserted i WHERE i.Codigo = d.Codigo
    );
END
GO

CREATE TRIGGER TR_Audit_Consulta
ON PETDB_Consulta
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionBy VARCHAR(64);
    SELECT @ActionBy = CAST(SESSION_CONTEXT(N'ActionBy') AS VARCHAR(64));
    SET @ActionBy = COALESCE(@ActionBy, SUSER_SNAME());

    -- Soft delete 
    INSERT INTO PETDB_Audit_Consulta
    (
        Id, [Data], Animal, Medico,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Id, i.[Data], i.Animal, i.Medico,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'UPDATE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Id = d.Id
    WHERE i.IsActive = 0 AND d.IsActive = 1;

    -- Restore
    INSERT INTO PETDB_Audit_Consulta
    (
        Id, [Data], Animal, Medico,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Id, i.[Data], i.Animal, i.Medico,
        i.IsActive, NULL, NULL,
        'RESTORE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Id = d.Id
    WHERE i.IsActive = 1 AND d.IsActive = 0;

    -- Delete
    INSERT INTO PETDB_Audit_Consulta
    (
        Id, [Data], Animal, Medico,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        d.Id, d.[Data], d.Animal, d.Medico,
        d.IsActive, GETDATE(), @ActionBy,
        'DELETE', @ActionBy
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted i WHERE i.Id = d.Id);
END
GO

CREATE TRIGGER TR_Audit_Pagamento
ON PETDB_Pagamento
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionBy VARCHAR(64);
    SELECT @ActionBy = CAST(SESSION_CONTEXT(N'ActionBy') AS VARCHAR(64));
    SET @ActionBy = COALESCE(@ActionBy, SUSER_SNAME());

    -- Soft delete 
    INSERT INTO PETDB_Audit_Pagamento
    (
        Id, [Data], Custo, Estado, MetodoPagamento, Consulta,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Id, i.[Data], i.Custo, i.Estado, i.MetodoPagamento, i.Consulta,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'UPDATE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Id = d.Id
    WHERE i.IsActive = 0 AND d.IsActive = 1;

    -- Restore
    INSERT INTO PETDB_Audit_Pagamento
    (
        Id, [Data], Custo, Estado, MetodoPagamento, Consulta,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Id, i.[Data], i.Custo, i.Estado, i.MetodoPagamento, i.Consulta,
        i.IsActive, NULL, NULL,
        'RESTORE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Id = d.Id
    WHERE i.IsActive = 1 AND d.IsActive = 0;

    -- Delete
    INSERT INTO PETDB_Audit_Pagamento
    (
        Id, [Data], Custo, Estado, MetodoPagamento, Consulta,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        d.Id, d.[Data], d.Custo, d.Estado, d.MetodoPagamento, d.Consulta,
        d.IsActive, GETDATE(), @ActionBy,
        'DELETE', @ActionBy
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted i WHERE i.Id = d.Id);
END
GO

CREATE TRIGGER TR_Audit_Prescricao
ON PETDB_Prescricao
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionBy VARCHAR(64);
    SELECT @ActionBy = CAST(SESSION_CONTEXT(N'ActionBy') AS VARCHAR(64));
    SET @ActionBy = COALESCE(@ActionBy, SUSER_SNAME());

    -- Soft delete 
    INSERT INTO PETDB_Audit_Prescricao
    (
        Numero, [Data], Animal,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Numero, i.[Data], i.Animal,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'UPDATE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Numero = d.Numero
    WHERE i.IsActive = 0 AND d.IsActive = 1;

    -- Restore
    INSERT INTO PETDB_Audit_Prescricao
    (
        Numero, [Data], Animal,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Numero, i.[Data], i.Animal,
        i.IsActive, NULL, NULL,
        'RESTORE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Numero = d.Numero
    WHERE i.IsActive = 1 AND d.IsActive = 0;

    -- Delete
    INSERT INTO PETDB_Audit_Prescricao
    (
        Numero, [Data], Animal,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        d.Numero, d.[Data], d.Animal,
        d.IsActive, GETDATE(), @ActionBy,
        'DELETE', @ActionBy
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted i WHERE i.Numero = d.Numero);
END
GO

CREATE TRIGGER TR_Audit_Especialidade
ON PETDB_Especialidade
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionBy VARCHAR(64);
    SELECT @ActionBy = CAST(SESSION_CONTEXT(N'ActionBy') AS VARCHAR(64));
    SET @ActionBy = COALESCE(@ActionBy, SUSER_SNAME());

    -- Soft delete 
    INSERT INTO PETDB_Audit_Especialidade
    (
        Codigo, Descricao,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Codigo, i.Descricao,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'UPDATE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Codigo = d.Codigo
    WHERE i.IsActive = 0 AND d.IsActive = 1;

    -- Restore
    INSERT INTO PETDB_Audit_Especialidade
    (
        Codigo, Descricao,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Codigo, i.Descricao,
        i.IsActive, NULL, NULL,
        'RESTORE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Codigo = d.Codigo
    WHERE i.IsActive = 1 AND d.IsActive = 0;

    -- Delete
    INSERT INTO PETDB_Audit_Especialidade
    (
        Codigo, Descricao,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        d.Codigo, d.Descricao,
        d.IsActive, GETDATE(), @ActionBy,
        'DELETE', @ActionBy
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted i WHERE i.Codigo = d.Codigo);
END
GO

CREATE TRIGGER TR_Audit_Especie
ON PETDB_Especie
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionBy VARCHAR(64);
    SELECT @ActionBy = CAST(SESSION_CONTEXT(N'ActionBy') AS VARCHAR(64));
    SET @ActionBy = COALESCE(@ActionBy, SUSER_SNAME());

    -- Soft delete 
    INSERT INTO PETDB_Audit_Especie
    (
        Codigo, Descricao,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Codigo, i.Descricao,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'UPDATE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Codigo = d.Codigo
    WHERE i.IsActive = 0 AND d.IsActive = 1;

    -- Restore
    INSERT INTO PETDB_Audit_Especie
    (
        Codigo, Descricao,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Codigo, i.Descricao,
        i.IsActive, NULL, NULL,
        'RESTORE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Codigo = d.Codigo
    WHERE i.IsActive = 1 AND d.IsActive = 0;

    -- Delete
    INSERT INTO PETDB_Audit_Especie
    (
        Codigo, Descricao,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        d.Codigo, d.Descricao,
        d.IsActive, GETDATE(), @ActionBy,
        'DELETE', @ActionBy
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted i WHERE i.Codigo = d.Codigo);
END
GO

CREATE TRIGGER TR_Audit_MetodoPagamento
ON PETDB_MetodoPagamento
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionBy VARCHAR(64);
    SELECT @ActionBy = CAST(SESSION_CONTEXT(N'ActionBy') AS VARCHAR(64));
    SET @ActionBy = COALESCE(@ActionBy, SUSER_SNAME());

    -- Soft delete 
    INSERT INTO PETDB_Audit_MetodoPagamento
    (
        Codigo, Descricao,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Codigo, i.Descricao,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'UPDATE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Codigo = d.Codigo
    WHERE i.IsActive = 0 AND d.IsActive = 1;

    -- Restore
    INSERT INTO PETDB_Audit_MetodoPagamento
    (
        Codigo, Descricao,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Codigo, i.Descricao,
        i.IsActive, NULL, NULL,
        'RESTORE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Codigo = d.Codigo
    WHERE i.IsActive = 1 AND d.IsActive = 0;

    -- Delete
    INSERT INTO PETDB_Audit_MetodoPagamento
    (
        Codigo, Descricao,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        d.Codigo, d.Descricao,
        d.IsActive, GETDATE(), @ActionBy,
        'DELETE', @ActionBy
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted i WHERE i.Codigo = d.Codigo);
END
GO

CREATE TRIGGER TR_Audit_Tratamento
ON PETDB_Tratamento
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionBy VARCHAR(64);
    SELECT @ActionBy = CAST(SESSION_CONTEXT(N'ActionBy') AS VARCHAR(64));
    SET @ActionBy = COALESCE(@ActionBy, SUSER_SNAME());

    -- Soft delete 
    INSERT INTO PETDB_Audit_Tratamento
    (
        Codigo, Descricao,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Codigo, i.Descricao,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'UPDATE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Codigo = d.Codigo
    WHERE i.IsActive = 0 AND d.IsActive = 1;

    -- Restore
    INSERT INTO PETDB_Audit_Tratamento
    (
        Codigo, Descricao,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.Codigo, i.Descricao,
        i.IsActive, NULL, NULL,
        'RESTORE', @ActionBy
    FROM inserted i
    JOIN deleted d ON i.Codigo = d.Codigo
    WHERE i.IsActive = 1 AND d.IsActive = 0;

    -- Delete
    INSERT INTO PETDB_Audit_Tratamento
    (
        Codigo, Descricao,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        d.Codigo, d.Descricao,
        d.IsActive, GETDATE(), @ActionBy,
        'DELETE', @ActionBy
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted i WHERE i.Codigo = d.Codigo);
END
GO