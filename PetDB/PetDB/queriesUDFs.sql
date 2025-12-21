CREATE FUNCTION dbo.fn_GetMedInfo(
	@IsActive BIT = 1, @Search VARCHAR(64) = NULL
)
RETURNS TABLE
AS 
	RETURN(SELECT Codigo, Descricao AS Nome, Dose FROM PETDB_Medicamento
	WHERE IsActive = @IsActive AND (@Search IS NULL OR Descricao LIKE '%' + @Search + '%'))
GO

CREATE FUNCTION dbo.fn_GetAnimalsBySpecie (@specieID INT)
RETURNS TABLE 
AS 
	RETURN(
	SELECT a.Nome 
	FROM PETDB_Animal as a
	WHERE a.Especie = @specieID AND a.IsActive = 1)
GO

CREATE FUNCTION dbo.fn_GetSpecieInfo (@IsActive BIT = 1, @Search VARCHAR(64) = NULL)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM PETDB_Especie
    WHERE IsActive = @IsActive AND (@Search IS NULL OR Descricao LIKE '%' + @Search + '%')
);
GO

CREATE FUNCTION dbo.fn_GetSpecialityInfo (@IsActive BIT = 1, @Search VARCHAR(64) = NULL)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM PETDB_Especialidade
    WHERE IsActive = @IsActive AND (@Search IS NULL OR Descricao LIKE '%' + @Search + '%')
);
GO

CREATE FUNCTION dbo.fn_GetVetsBySpeciality (@SpecialityID INT)
RETURNS TABLE
AS
RETURN
(
    SELECT v.Nome
    FROM PETDB_MedicoVeterinario v
    WHERE v.Especialidade = @SpecialityID AND v.IsActive = 1
);
GO

CREATE FUNCTION dbo.fn_GetPrescriptionMedsById(@prescriptionID INT)
RETURNS TABLE
AS 
	RETURN(SELECT m.Codigo, m.Descricao, m.Dose
	FROM PETDB_PrescricaoMedicamento as pm 
	JOIN PETDB_Medicamento as m ON pm.CodigoMedicamento = m.Codigo
	WHERE pm.NumeroPrescricao = @prescriptionID AND m.IsActive = 1 )
GO

CREATE FUNCTION dbo.fn_GetPrescriptionInfo(
	@PetId int = NULL,@VetOMV int = NULL, @ClinicNIF int = NULL, @IsActive BIT = 1, @Search VARCHAR(64) = NULL)
	RETURNS TABLE
AS 

	RETURN( 

	SELECT p.Numero, p.[Data], a.Nome as Animal, m.Nome as Medico
	FROM PETDB_Prescricao as p 
	JOIN PETDB_Animal as a ON p.Animal = a.Numero
	JOIN PETDB_MedicoVeterinario as m ON p.VetOMV = m.NumOMV
	WHERE (@PetId IS NULL OR a.Numero = @PetId) AND (@VetOMV IS NULL OR m.NumOMV = @VetOMV) AND (@ClinicNIF IS NULL OR m.Clinica = @ClinicNIF)
	AND (@Search IS NULL OR  a.Nome LIKE '%' + @Search + '%') AND p.IsActive = @IsActive
) 
GO 

CREATE FUNCTION dbo.fn_GetAppointmentReportById (@appointmentID INT)
RETURNS TABLE
AS 

	RETURN( 

	SELECT r.CodigoRelatorio, r.Conteudo
	FROM PETDB_Relatorio as r 
	WHERE r.Consulta = @appointmentID
) 
GO 

CREATE FUNCTION dbo.fn_GetAppointmentTreatmentsById (@appointmentID INT)
RETURNS TABLE
AS 

	RETURN( 

	SELECT Codigo, Descricao
	FROM PETDB_ConsultaTratamento as ct
	JOIN PETDB_Tratamento as t ON ct.CodigoTratamento = t.Codigo
	WHERE ct.IdConsulta = @appointmentID
) 
GO 

CREATE FUNCTION dbo.fn_GetAppointmentDateById (@appointmentID int)
RETURNS TABLE
AS 

	RETURN( 
	SELECT [Data] FROM PETDB_Consulta WHERE Id = @appointmentID AND IsActive = 1
)
GO

CREATE FUNCTION dbo.fn_GetPaymentInfo(@OwnerNIF int = NULL, @ClinicNIF int = NULL, @IsActive BIT = 1, @Search VARCHAR(64) = NULL)
RETURNS TABLE
AS 

	RETURN( 

	SELECT p.Id, p.[Data], p.Custo, p.Estado, m.Descricao as Metodo, a.Nome as Animal, v.Nome as Medico
	FROM PETDB_Pagamento as p
	JOIN PETDB_MetodoPagamento as m ON p.MetodoPagamento = m.Codigo
	JOIN PETDB_Consulta as c ON p.Consulta = c.Id
	JOIN PETDB_Animal as a ON c.Animal = a.Numero
	JOIN PETDB_MedicoVeterinario as v ON c.Medico = v.NumOMV
	WHERE (@OwnerNIF IS NULL OR a.Dono = @OwnerNIF) AND (@ClinicNIF IS NULL OR v.Clinica = @ClinicNIF) AND (@Search IS NULL OR  a.Nome LIKE '%' + @Search + '%') AND p.IsActive = @IsActive
) 
GO

CREATE FUNCTION dbo.fn_GetAppointmentInfo
	(@PetId int = NULL, @VetOMV int = NULL, @ClinicNIF int = NULL, @IsActive BIT = 1, @Search VARCHAR(64) = NULL) 
	RETURNS TABLE
AS 

	RETURN( 

	SELECT c.Id, c.[Data], a.Nome as Animal, v.Nome as Medico
	FROM PETDB_Consulta as c
	JOIN PETDB_Animal as a ON c.Animal = a.Numero
	JOIN PETDB_MedicoVeterinario as v ON c.Medico = v.NumOMV
	WHERE (@PetId IS NULL OR a.Numero = @PetId) AND (@VetOMV IS NULL OR v.NumOMV = @VetOMV) AND 
	(@Search IS NULL OR  a.Nome LIKE '%' + @Search + '%') AND (@ClinicNIF IS NULL OR v.Clinica = @ClinicNIF) AND c.IsActive = @IsActive
) 
GO 

CREATE FUNCTION dbo.fn_GetClinicTable
	(@ClinicNIF int = NULL, @IsActive BIT = 1, @Search varchar(64) = NULL)
RETURNS TABLE
AS 

	RETURN( 

	SELECT * FROM PETDB_ClinicaVeterinaria
	WHERE (@ClinicNIF IS NULL OR NIF=@ClinicNIF) AND IsActive = @IsActive AND (@Search IS NULL OR Nome LIKE '%' + @Search + '%')
)
GO

CREATE FUNCTION dbo.fn_GetVetInfo
(
    @ClinicNIF INT = NULL,
    @VetOMV INT = NULL,
    @IsActive BIT = 1,
	@Search VARCHAR(64) = NULL
)
RETURNS TABLE
AS
RETURN
(
    SELECT v.NumOMV, v.Nome, v.Telefone, v.Email, e.Descricao AS Especialidade, c.Nome AS Clinica
    FROM PETDB_MedicoVeterinario v
    JOIN PETDB_Especialidade e ON v.Especialidade = e.Codigo
    JOIN PETDB_ClinicaVeterinaria c ON v.Clinica = c.NIF
    WHERE (@ClinicNIF IS NULL OR c.NIF = @ClinicNIF) AND (@VetOMV IS NULL OR v.NumOMV = @VetOMV) AND
	(@Search IS NULL OR v.Nome LIKE '%' + @Search + '%') AND v.IsActive = @IsActive
);
GO

CREATE FUNCTION dbo.fn_GetPetInfo
	(@OwnerNIF int = NULL, @IsActive BIT = 1, @Search VARCHAR(64) = NULL)
	RETURNS TABLE
AS
	RETURN( 

	SELECT a.Numero, a.Nome, a.DataNascimento, a.Peso, a.Sexo, e.Descricao as Especie, d.Nome as Dono
	FROM PETDB_Animal as a
	JOIN PETDB_Especie as e ON e.Codigo = a.Especie
	JOIN PETDB_Dono as d ON d.NIF = a.Dono
	WHERE (@OwnerNIF IS NULL OR d.NIF = @OwnerNIF) AND (@Search IS NULL OR a.Nome LIKE '%' + @Search + '%') AND a.IsActive = @IsActive
)
GO


CREATE FUNCTION dbo.fn_GetOwnerTable
(@OwnerNIF int = NULL, @IsActive BIT = 1, @Search VARCHAR(64) = NULL)
RETURNS TABLE
AS 

	RETURN( 

	SELECT * FROM PETDB_Dono
	WHERE (@OwnerNIF IS NULL OR NIF=@OwnerNIF) AND (@Search IS NULL OR Nome LIKE '%' + @Search + '%') AND IsActive = @IsActive
) 
GO

CREATE FUNCTION dbo.fn_GetPaymentAppointment
	(@PaymentId int)
RETURNS TABLE
AS 

	RETURN( 
	SELECT Consulta FROM PETDB_Pagamento WHERE Id = @PaymentId AND IsActive = 1
) 
GO

CREATE FUNCTION dbo.fn_GetPaymentMethods
	(@IsActive BIT = 1, @Search VARCHAR(64) = NULL)
RETURNS TABLE
AS 

	RETURN( 
	SELECT * FROM PETDB_MetodoPagamento WHERE IsActive = @IsActive 
	AND (@Search IS NULL OR Descricao LIKE '%' + @Search + '%') 
) 
GO 

CREATE FUNCTION dbo.fn_GetPaymentDate
	(@PaymentId int)
RETURNS TABLE
AS 

	RETURN( 
	SELECT [Data] FROM PETDB_Pagamento WHERE Id = @PaymentId AND IsActive = 1
) 
GO

CREATE FUNCTION dbo.fn_GetTreatments
	(@IsActive BIT = 1, @Search VARCHAR(64) = NULL)
RETURNS TABLE
AS 

	RETURN( 
	SELECT * FROM PETDB_Tratamento WHERE IsActive = @IsActive
	AND (@Search IS NULL OR Descricao LIKE '%' + @Search + '%')
) 
GO


CREATE FUNCTION dbo.fn_GetPrescriptionDate
	(@PrescriptionId int)
RETURNS TABLE
AS 
	RETURN(	
	SELECT [Data] FROM PETDB_Prescricao
	WHERE Numero = @PrescriptionId AND IsActive = 1
)
GO

CREATE FUNCTION dbo.fn_GetPaymentsByMethod
	(@MethodId int)
RETURNS TABLE
AS 
	RETURN( 
	SELECT p.Id, p.[Data], p.Custo, p.Estado, m.Descricao as Metodo, a.Nome as Animal, v.Nome as Medico
	FROM PETDB_Pagamento as p
	JOIN PETDB_MetodoPagamento as m ON p.MetodoPagamento = m.Codigo
	JOIN PETDB_Consulta as c ON p.Consulta = c.Id
	JOIN PETDB_Animal as a ON c.Animal = a.Numero
	JOIN PETDB_MedicoVeterinario as v ON c.Medico = v.NumOMV
	WHERE m.Codigo = @MethodId AND p.IsActive = 1
)
GO 

CREATE FUNCTION dbo.fn_GetAppointmentsByTreatment
	(@TreatmentId int)
RETURNS TABLE
AS 

	RETURN(

	SELECT c.Id, c.[Data], a.Nome as Animal, c.Medico FROM PETDB_ConsultaTratamento as ct 
	JOIN PETDB_Consulta as c ON c.Id = ct.IdConsulta
	JOIN PETDB_Animal as a ON a.Numero = c.Animal
	WHERE ct.CodigoTratamento = @TreatmentId AND c.IsActive = 1
)
GO

CREATE FUNCTION dbo.fn_GetPetsByClinic
		(@ClinicNIF int, @IsActive BIT = 1, @Search VARCHAR(64) = NULL)
RETURNS TABLE
AS
 
	RETURN( 
	SELECT a.Numero, a.Nome, a.DataNascimento, a.Peso, a.Sexo, d.Nome as Dono, e.Descricao as Especie , d.NIF as DonoNIF
	FROM PETDB_Animal as a
	JOIN PETDB_Especie as e ON e.Codigo = a.Especie
	JOIN PETDB_Consulta as c ON a.Numero=Animal
	JOIN PETDB_MedicoVeterinario as m ON c.Medico=m.NumOMV
	JOIN PETDB_Dono as d ON d.NIF = a.Dono
	WHERE m.Clinica=@ClinicNIF AND a.IsActive = @IsActive AND (@Search IS NULL OR  a.Nome LIKE '%' + @Search + '%')
)
GO