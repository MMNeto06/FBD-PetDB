CREATE TABLE PETDB_Audit_ClinicaVeterinaria (
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

CREATE TABLE PETDB_Audit_MedicoVeterinario
(
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    NumOMV INT NOT NULL,
    Nome VARCHAR(64),
    Telefone VARCHAR(9),
    Email VARCHAR(64),
    Especialidade INT,
    Clinica INT,
    IsActive BIT,
    DeletedAt DATETIME,
    DeletedBy VARCHAR(64),
    ActionType VARCHAR(10),  
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    ActionBy VARCHAR(64)
);
GO

CREATE TABLE PETDB_Audit_Animal
(
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    Numero INT NOT NULL,
    Nome VARCHAR(64),
    DataNascimento DATE,
    Peso FLOAT,
    Sexo CHAR(1),
    Especie INT,
    Dono INT,
    IsActive BIT,
    DeletedAt DATETIME,
    DeletedBy VARCHAR(64),
    ActionType VARCHAR(10), 
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    ActionBy VARCHAR(64)
);
GO

CREATE TABLE PETDB_Audit_Dono
(
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    NIF INT NOT NULL,
    Nome VARCHAR(64),
    Telefone VARCHAR(9),
    Email VARCHAR(64),
    Endereco VARCHAR(64),
    IsActive BIT,
    DeletedAt DATETIME,
    DeletedBy VARCHAR(64),
    ActionType VARCHAR(10), 
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    ActionBy VARCHAR(64)
);
GO

CREATE TABLE PETDB_Audit_Medicamento
(
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo INT NOT NULL,
    Descricao VARCHAR(64),
    Dose VARCHAR(10),
    IsActive BIT,
    DeletedAt DATETIME,
    DeletedBy VARCHAR(64),
    ActionType VARCHAR(10),   
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    ActionBy VARCHAR(64)
);
GO

CREATE TABLE PETDB_Audit_Consulta (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    Id INT NOT NULL,
    [Data] DATETIME NOT NULL,
    Animal INT NOT NULL,
    Medico INT NOT NULL,
    IsActive BIT,
    DeletedAt DATETIME,
    DeletedBy VARCHAR(64),
    ActionType VARCHAR(10) NOT NULL,
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    ActionBy VARCHAR(64) NULL
);
GO

CREATE TABLE PETDB_Audit_Pagamento (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    Id INT NOT NULL,
    [Data] DATETIME NOT NULL,
    Custo FLOAT NOT NULL,
    Estado VARCHAR(8) NOT NULL,
    MetodoPagamento INT NOT NULL,
    Consulta INT NOT NULL,
    IsActive BIT,
    DeletedAt DATETIME,
    DeletedBy VARCHAR(64),
    ActionType VARCHAR(10) NOT NULL,
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    ActionBy VARCHAR(64) NULL
);
GO

CREATE TABLE PETDB_Audit_Prescricao (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    Numero INT NOT NULL,
    [Data] DATE NOT NULL,
    Animal INT NOT NULL,
    IsActive BIT,
    DeletedAt DATETIME,
    DeletedBy VARCHAR(64),
    ActionType VARCHAR(10) NOT NULL,
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    ActionBy VARCHAR(64) NULL
);
GO

CREATE TABLE PETDB_Audit_Especialidade (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo INT NOT NULL,
    Descricao VARCHAR(64) NOT NULL,
    IsActive BIT,
    DeletedAt DATETIME,
    DeletedBy VARCHAR(64),
    ActionType VARCHAR(10) NOT NULL,
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    ActionBy VARCHAR(64) NULL
);
GO

CREATE TABLE PETDB_Audit_Especie (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo INT NOT NULL,
    Descricao VARCHAR(64) NOT NULL,
    IsActive BIT,
    DeletedAt DATETIME,
    DeletedBy VARCHAR(64),
    ActionType VARCHAR(10) NOT NULL,
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    ActionBy VARCHAR(64) NULL
);
GO

CREATE TABLE PETDB_Audit_MetodoPagamento (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo INT NOT NULL,
    Descricao VARCHAR(64) NOT NULL,
    IsActive BIT,
    DeletedAt DATETIME,
    DeletedBy VARCHAR(64),
    ActionType VARCHAR(10) NOT NULL,
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    ActionBy VARCHAR(64) NULL
);
GO

CREATE TABLE PETDB_Audit_Tratamento (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    Codigo INT NOT NULL,
    Descricao VARCHAR(64) NOT NULL,
    IsActive BIT,
    DeletedAt DATETIME,
    DeletedBy VARCHAR(64),
    ActionType VARCHAR(10) NOT NULL,
    ActionDate DATETIME NOT NULL DEFAULT GETDATE(),
    ActionBy VARCHAR(64) NULL
);
GO