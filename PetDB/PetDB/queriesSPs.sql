CREATE FUNCTION fn_GetMedInfo(
	@IsActive BIT = 1
)
RETURNS TABLE
AS 
	RETURN(SELECT Codigo, Descricao AS Nome, Dose FROM PETDB_Medicamento
	WHERE IsActive = @IsActive)
	--ORDER BY Descricao
GO

CREATE FUNCTION fn_GetAnimalsBySpecie (@specieID INT)
RETURNS TABLE 
AS 
	RETURN(
	SELECT a.Nome 
	FROM PETDB_Animal as a
	WHERE a.Especie = @specieID AND a.IsActive = 1)
	-- ORDER BY a.Nome
GO

CREATE FUNCTION fn_GetSpecieInfo (@IsActive BIT = 1)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM PETDB_Especie
    WHERE IsActive = @IsActive
    -- ORDER BY Descricao
);
GO


CREATE FUNCTION fn_GetSpecieName (@SpecieID INT) -- possivelmente obsoleto, não encontro referência a isto 
RETURNS TABLE
AS
RETURN
(
    SELECT Descricao
    FROM PETDB_Especie
    WHERE Codigo = @SpecieID AND IsActive = 1
    -- ORDER BY Descricao
);
GO

CREATE FUNCTION dbo.fn_GetSpecialityInfo (@IsActive BIT = 1)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM PETDB_Especialidade
    WHERE IsActive = @IsActive
    -- ORDER BY Descricao
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
    -- ORDER BY v.Nome
);
GO

CREATE FUNCTION fn_GetPrescriptionMedsById(@prescriptionID INT)
RETURNS TABLE
AS 
	RETURN(SELECT m.Codigo, m.Descricao, m.Dose
	FROM PETDB_PrescricaoMedicamento as pm 
	JOIN PETDB_Medicamento as m ON pm.CodigoMedicamento = m.Codigo
	WHERE pm.NumeroPrescricao = @prescriptionID AND m.IsActive = 1 )
	-- ORDER BY m.Descricao;
GO

CREATE FUNCTION fn_GetPrescriptionInfo(
	@PetId int = NULL,@VetOMV int = NULL, @IsActive BIT = 1)
	RETURNS TABLE
AS 

	RETURN( 

	SELECT p.Numero, p.[Data], a.Nome as Animal, m.Nome as Medico
	FROM PETDB_Prescricao as p 
	JOIN PETDB_Animal as a ON p.Animal = a.Numero
	JOIN PETDB_PrescricaoMedico as pm ON p.Numero = pm.NumeroPrescricao
	JOIN PETDB_MedicoVeterinario as m ON pm.NumeroOMVMedico = m.NumOMV
	WHERE (@PetId IS NULL OR a.Numero = @PetId) AND (@VetOMV IS NULL OR m.NumOMV = @VetOMV) AND p.IsActive = @IsActive
	-- ORDER BY p.[Data] DESC;
) 
GO 

CREATE FUNCTION fn_GetAppointmentReportById (@appointmentID INT)
RETURNS TABLE
AS 

	RETURN( 

	SELECT r.CodigoRelatorio, r.Conteudo
	FROM PETDB_Relatorio as r 
	WHERE r.Consulta = @appointmentID
) 
GO 

CREATE FUNCTION fn_GetAppointmentTreatmentsById (@appointmentID INT)
RETURNS TABLE
AS 

	RETURN( 

	SELECT Codigo, Descricao
	FROM PETDB_ConsultaTratamento as ct
	JOIN PETDB_Tratamento as t ON ct.CodigoTratamento = t.Codigo
	WHERE ct.IdConsulta = @appointmentID
	-- ORDER BY Descricao;
) 
GO 

CREATE FUNCTION fn_GetAppointmentDateById (@appointmentID int)
RETURNS TABLE
AS 

	RETURN( 
	SELECT [Data] FROM PETDB_Consulta WHERE Id = @appointmentID AND IsActive = 1
)
GO

CREATE FUNCTION fn_GetPaymentInfo(@OwnerNIF int = NULL, @IsActive BIT = 1)
RETURNS TABLE
AS 

	RETURN( 

	SELECT p.Id, p.[Data], p.Custo, p.Estado, m.Descricao as Metodo, a.Nome as Animal, v.Nome as Medico
	FROM PETDB_Pagamento as p
	JOIN PETDB_MetodoPagamento as m ON p.MetodoPagamento = m.Codigo
	JOIN PETDB_Consulta as c ON p.Consulta = c.Id
	JOIN PETDB_Animal as a ON c.Animal = a.Numero
	JOIN PETDB_MedicoVeterinario as v ON c.Medico = v.NumOMV
	WHERE (@OwnerNIF IS NULL OR a.Dono = @OwnerNIF) AND p.IsActive = @IsActive
	-- ORDER BY p.[Data] DESC;
) 
GO

CREATE FUNCTION fn_GetAppointmentInfo
	(@PetId int = NULL, @VetOMV int = NULL, @IsActive BIT = 1)
	RETURNS TABLE
AS 

	RETURN( 

	SELECT c.Id, c.[Data], a.Nome as Animal, v.Nome as Medico
	FROM PETDB_Consulta as c
	JOIN PETDB_Animal as a ON c.Animal = a.Numero
	JOIN PETDB_MedicoVeterinario as v ON c.Medico = v.NumOMV
	WHERE (@PetId IS NULL OR a.Numero = @PetId) AND (@VetOMV IS NULL OR v.NumOMV = @VetOMV) AND c.IsActive = @IsActive
	-- ORDER BY c.[Data] DESC;
) 
GO 

CREATE FUNCTION fn_GetClinicTable
	(@IsActive BIT = 1)
RETURNS TABLE
AS 

	RETURN( 

	SELECT * FROM PETDB_ClinicaVeterinaria
	WHERE IsActive = @IsActive
	-- ORDER BY Nome;
)
GO

CREATE FUNCTION fn_GetVetInfo
(
    @ClinicNIF INT = NULL,
    @VetOMV INT = NULL,
    @IsActive BIT = 1
)
RETURNS TABLE
AS
RETURN
(
    SELECT v.NumOMV, v.Nome, v.Telefone, v.Email, e.Descricao AS Especialidade, c.Nome AS Clinica
    FROM PETDB_MedicoVeterinario v
    JOIN PETDB_Especialidade e ON v.Especialidade = e.Codigo
    JOIN PETDB_ClinicaVeterinaria c ON v.Clinica = c.NIF
    WHERE (@ClinicNIF IS NULL OR c.NIF = @ClinicNIF) AND (@VetOMV IS NULL OR v.NumOMV = @VetOMV) AND v.IsActive = @IsActive
    -- ORDER BY v.Nome
);
GO

CREATE FUNCTION fn_GetPetInfo
	(@OwnerNIF int = NULL, @IsActive BIT = 1)
	RETURNS TABLE
AS
	RETURN( 

	SELECT a.Numero, a.Nome, a.DataNascimento, a.Peso, a.Sexo, e.Descricao as Especie, d.Nome as Dono
	FROM PETDB_Animal as a
	JOIN PETDB_Especie as e ON e.Codigo = a.Especie
	JOIN PETDB_Dono as d ON d.NIF = a.Dono
	WHERE (@OwnerNIF IS NULL OR d.NIF = @OwnerNIF) AND a.IsActive = @IsActive
	-- ORDER BY a.Nome;
)
GO


CREATE FUNCTION fn_GetOwnerTable
(@OwnerNIF int = NULL, @IsActive BIT = 1)
RETURNS TABLE
AS 

	RETURN( 

	SELECT * FROM PETDB_Dono
	WHERE (@OwnerNIF IS NULL OR NIF=@OwnerNIF) AND IsActive = @IsActive
	-- ORDER BY Nome;
) 
GO

CREATE FUNCTION fn_GetPetsByClinic
		(@ClinicNIF int)
RETURNS TABLE
AS
 
	RETURN( 

	SELECT a.Numero, a.Nome, a.DataNascimento, a.Peso, a.Sexo, d.Nome as Dono, e.Descricao as Especie 
	FROM PETDB_Animal as a
	JOIN PETDB_Especie as e ON e.Codigo = a.Especie
	JOIN PETDB_Consulta as c ON a.Numero=Animal
	JOIN PETDB_MedicoVeterinario as m ON c.Medico=m.NumOMV
	JOIN PETDB_Dono as d ON d.NIF = a.Dono
	WHERE m.Clinica=@ClinicNIF AND a.IsActive = 1
	-- ORDER BY a.Nome;
)
GO

CREATE FUNCTION fn_GetPrescriptionsByPet
		(@PetNum int)
RETURNS TABLE
AS 

	RETURN( 

	SELECT * FROM PETDB_Prescricao
	WHERE Animal=@PetNum AND IsActive = 1
	-- ORDER BY [Data] DESC; 
) 
GO



CREATE FUNCTION fn_GetSpecialtyTable ()  -- possivelemnete obsoleto
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM PETDB_Especialidade
    WHERE IsActive = 1
    -- ORDER BY Descricao
);
GO


CREATE FUNCTION fn_GetClinicByNIF --pode ser trocada provavelmente
	(@ClinicNIF int)
RETURNS TABLE
AS
	RETURN(
	SELECT * FROM PETDB_ClinicaVeterinaria WHERE NIF=@ClinicNIF AND IsActive = 1
)
GO

CREATE FUNCTION fn_GetMedicByOMV --pode ser trocada provavelmente
	(@MedicOMV int)
RETURNS TABLE
AS
	RETURN(
	SELECT * FROM PETDB_MedicoVeterinario WHERE NumOMV=@MedicOMV AND IsActive = 1
)
GO

CREATE FUNCTION fn_GetPaymentAppointment
	(@PaymentId int)
RETURNS TABLE
AS 

	RETURN( 
	SELECT Consulta FROM PETDB_Pagamento WHERE Id = @PaymentId AND IsActive = 1
) 
GO

CREATE FUNCTION fn_GetPaymentMethods
	(@IsActive BIT = 1)
RETURNS TABLE
AS 

	RETURN( 
	SELECT * FROM PETDB_MetodoPagamento WHERE IsActive = @IsActive
) 
GO 

CREATE FUNCTION fn_GetPaymentDate
	(@PaymentId int)
RETURNS TABLE
AS 

	RETURN( 
	SELECT [Data] FROM PETDB_Pagamento WHERE Id = @PaymentId AND IsActive = 1
) 
GO

CREATE FUNCTION fn_GetTreatments
	(@IsActive BIT = 1)
RETURNS TABLE
AS 

	RETURN( 
	SELECT * FROM PETDB_Tratamento WHERE IsActive = @IsActive
) 
GO

CREATE FUNCTION fn_GetMostRecentAppointmentId() -- possivelmente obsoleto
RETURNS TABLE
AS 

	RETURN( 

	SELECT TOP 1 Id FROM PETDB_Consulta
	ORDER BY Id DESC
) 
GO

CREATE FUNCTION fn_GetPrescriptionDate
	(@PrescriptionId int)
RETURNS TABLE
AS 
	RETURN(	
	SELECT [Data] FROM PETDB_Prescricao
	WHERE Numero = @PrescriptionId AND IsActive = 1
)
GO

CREATE FUNCTION fn_GetPaymentsByMethod
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
	--ORDER BY p.[Data] DESC;
)
GO 

CREATE FUNCTION fn_GetAppointmentsByTreatment
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