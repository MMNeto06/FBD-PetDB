CREATE TRIGGER TR_Audit_ClinicaVeterinaria
ON PETDB_ClinicaVeterinaria
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Soft delete 
    INSERT INTO Audit_ClinicaVeterinaria
    (
        NIF, Nome, Telefone, Email, Endereco,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.NIF, i.Nome, i.Telefone, i.Email, i.Endereco,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'UPDATE', i.DeletedBy
    FROM inserted i
    JOIN deleted d ON i.NIF = d.NIF
    WHERE i.IsActive = 0 AND d.IsActive = 1;

    -- Restore
    INSERT INTO Audit_ClinicaVeterinaria
    (
        NIF, Nome, Telefone, Email, Endereco,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        i.NIF, i.Nome, i.Telefone, i.Email, i.Endereco,
        i.IsActive, i.DeletedAt, i.DeletedBy,
        'RESTORE', i.DeletedBy
    FROM inserted i
    JOIN deleted d ON i.NIF = d.NIF
    WHERE i.IsActive = 1 AND d.IsActive = 0;

    -- Delete
    INSERT INTO Audit_ClinicaVeterinaria
    (
        NIF, Nome, Telefone, Email, Endereco,
        IsActive, DeletedAt, DeletedBy, ActionType, ActionBy
    )
    SELECT 
        d.NIF, d.Nome, d.Telefone, d.Email, d.Endereco,
        d.IsActive, d.DeletedAt, d.DeletedBy,
        'DELETE', d.DeletedBy
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted i WHERE i.NIF = d.NIF);
END
GO
