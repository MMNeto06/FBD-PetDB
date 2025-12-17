CREATE TABLE Audit_ClinicaVeterinaria (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    NIF INT NOT NULL,
    Nome VARCHAR(64),
    Telefone VARCHAR(9),
    Email VARCHAR(64),
    Endereco VARCHAR(64),
    IsActive BIT,
    DeletedAt DATETIME,
    DeletedBy VARCHAR(64),
    ActionType VARCHAR(10) NOT NULL,
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    ActionBy VARCHAR(64) NULL
);
GO
