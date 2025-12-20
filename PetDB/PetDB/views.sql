CREATE VIEW PETDB_VW_AuditLog_Global
AS
SELECT
    'ClinicaVeterinaria' AS Entidade,
    CAST(NIF AS VARCHAR(32)) AS Identificador,
    Nome AS Descricao,
    ActionType,
    ActionDate,
    ActionBy
FROM PETDB_Audit_ClinicaVeterinaria
    
UNION ALL

SELECT
    'MedicoVeterinario' AS Entidade,
    CAST(NumOMV AS VARCHAR(32)) AS Identificador,
    Nome AS Descricao,
    ActionType,
    ActionDate,
    ActionBy
FROM PETDB_Audit_MedicoVeterinario

UNION ALL

SELECT
    'Dono' AS Entidade,
    CAST(NIF AS VARCHAR(32)) AS Identificador,
    Nome AS Descricao,
    ActionType,
    ActionDate,
    ActionBy
FROM PETDB_Audit_Dono

UNION ALL

SELECT
    'Animal' AS Entidade,
    CAST(Numero AS VARCHAR(32)) AS Identificador,
    Nome AS Descricao,
    ActionType,
    ActionDate,
    ActionBy
FROM PETDB_Audit_Animal

UNION ALL

SELECT
    'Consulta' AS Entidade,
    CAST(Id AS VARCHAR(32)) AS Identificador,
    CONVERT(VARCHAR(19), [Data], 120) AS Descricao,
    ActionType,
    ActionDate,
    ActionBy
FROM PETDB_Audit_Consulta

UNION ALL

SELECT
    'Pagamento' AS Entidade,
    CAST(Id AS VARCHAR(32)) AS Identificador,
    CONCAT('€ ', CAST(Custo AS VARCHAR(16))) AS Descricao,
    ActionType,
    ActionDate,
    ActionBy
FROM PETDB_Audit_Pagamento

UNION ALL

SELECT
    'Prescricao' AS Entidade,
    CAST(Numero AS VARCHAR(32)) AS Identificador,
    CONVERT(VARCHAR(10), [Data], 120) AS Descricao,
    ActionType,
    ActionDate,
    ActionBy
FROM PETDB_Audit_Prescricao;
GO
