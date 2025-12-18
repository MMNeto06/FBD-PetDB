CREATE PROCEDURE SP_GetMedInfo
AS 
BEGIN
	SET NOCOUNT ON; 

	SELECT Codigo, Descricao AS Nome, Dose FROM PETDB_Medicamento
	WHERE IsActive = 1
	ORDER BY Descricao;
END
GO

CREATE PROCEDURE SP_GetAnimalsBySpecie @specieID INT
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT a.Nome 
	FROM PETDB_Animal as a
	WHERE a.Especie = @specieID AND a.IsActive = 1
	ORDER BY a.Nome;
END
GO

CREATE PROCEDURE SP_GetSpecieInfo
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Especie
	WHERE IsActive = 1
	ORDER BY Descricao;
END 
GO

CREATE PROCEDURE SP_GetSpecieName @specieID int
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT Descricao FROM PETDB_Especie
	WHERE Codigo=@specieID AND IsActive = 1
	ORDER BY Descricao;
END 
GO

CREATE PROCEDURE SP_GetSpecialityInfo
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Especialidade
	WHERE IsActive = 1
	ORDER BY Descricao;
END 
GO

CREATE PROCEDURE SP_GetVetsBySpeciality @specialityID INT 
AS
BEGIN 
	SET NOCOUNT ON; 

	SELECT v.Nome 
	FROM PETDB_MedicoVeterinario as v 
	WHERE v.Especialidade = @specialityID AND v.IsActive = 1
	ORDER BY v.Nome;
END
GO

CREATE PROCEDURE SP_GetPrescriptionMedsById @prescriptionID INT
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT m.Codigo, m.Descricao, m.Dose
	FROM PETDB_PrescricaoMedicamento as pm 
	JOIN PETDB_Medicamento as m ON pm.CodigoMedicamento = m.Codigo
	WHERE pm.NumeroPrescricao = @prescriptionID AND m.IsActive = 1 
	ORDER BY m.Descricao;
END 
GO

CREATE PROCEDURE SP_GetPrescriptionInfo 
	@PetId int = NULL 
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT p.Numero, p.[Data], a.Nome as Animal, m.Nome as Medico
	FROM PETDB_Prescricao as p 
	JOIN PETDB_Animal as a ON p.Animal = a.Numero
	JOIN PETDB_PrescricaoMedico as pm ON p.Numero = pm.NumeroPrescricao
	JOIN PETDB_MedicoVeterinario as m ON pm.NumeroOMVMedico = m.NumOMV
	WHERE (@PetId IS NULL OR a.Numero = @PetId) AND p.IsActive = 1 
	ORDER BY p.[Data] DESC;
END 
GO 

CREATE PROCEDURE SP_GetAppointmentReportById @appointmentID INT
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT r.CodigoRelatorio, r.Conteudo
	FROM PETDB_Relatorio as r 
	WHERE r.Consulta = @appointmentID
END 
GO 

CREATE PROCEDURE SP_GetAppointmentTreatmentsById @appointmentID INT 
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT Codigo, Descricao
	FROM PETDB_ConsultaTratamento as ct
	JOIN PETDB_Tratamento as t ON ct.CodigoTratamento = t.Codigo
	WHERE ct.IdConsulta = @appointmentID
	ORDER BY Descricao;
END 
GO 

CREATE PROCEDURE SP_GetAppointmentDateById
	@appointmentID int
AS 
BEGIN 
	SET NOCOUNT ON; 
	SELECT [Data] FROM PETDB_Consulta WHERE Id = @appointmentID AND IsActive = 1;
END
GO

CREATE PROCEDURE SP_GetPaymentInfo
	@OwnerNIF int = NULL
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT p.Id, p.[Data], p.Custo, p.Estado, m.Descricao as Metodo, a.Nome as Animal, v.Nome as Medico
	FROM PETDB_Pagamento as p
	JOIN PETDB_MetodoPagamento as m ON p.MetodoPagamento = m.Codigo
	JOIN PETDB_Consulta as c ON p.Consulta = c.Id
	JOIN PETDB_Animal as a ON c.Animal = a.Numero
	JOIN PETDB_MedicoVeterinario as v ON c.Medico = v.NumOMV
	WHERE (@OwnerNIF IS NULL OR a.Dono = @OwnerNIF) AND p.IsActive = 1
	ORDER BY p.[Data] DESC;
END 
GO

CREATE PROCEDURE SP_GetAppointmentInfo
	@PetId int = NULL, @VetOMV int = NULL
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT c.Id, c.[Data], a.Nome as Animal, v.Nome as Medico
	FROM PETDB_Consulta as c
	JOIN PETDB_Animal as a ON c.Animal = a.Numero
	JOIN PETDB_MedicoVeterinario as v ON c.Medico = v.NumOMV
	WHERE (@PetId IS NULL OR a.Numero = @PetId) AND (@VetOMV IS NULL OR v.NumOMV = @VetOMV) AND c.IsActive = 1
	ORDER BY c.[Data] DESC;
END 
GO 

CREATE PROCEDURE SP_GetClinicTable
	@IsActive BIT = 1
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_ClinicaVeterinaria
	WHERE IsActive = @IsActive
	ORDER BY Nome;
END
GO

CREATE PROCEDURE SP_GetVetInfo
	@ClinicNIF int = NULL, @IsActive BIT = 1
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT v.NumOMV, v.Nome, v.Telefone, v.Email, e.Descricao as Especialidade, c.Nome as Clinica
	FROM PETDB_MedicoVeterinario as v
	JOIN PETDB_Especialidade as e ON v.Especialidade = e.Codigo
	JOIN PETDB_ClinicaVeterinaria as c ON v.Clinica = c.NIF
	WHERE (@ClinicNIF IS NULL OR c.NIF = @ClinicNIF) AND v.IsActive = @IsActive
	ORDER BY v.Nome;
END
GO

CREATE PROCEDURE SP_GetPetInfo
	@OwnerNIF int = NULL
AS
BEGIN
	SET NOCOUNT ON; 

	SELECT a.Numero, a.Nome, a.DataNascimento, a.Peso, a.Sexo, e.Descricao as Especie, d.Nome as Dono
	FROM PETDB_Animal as a
	JOIN PETDB_Especie as e ON e.Codigo = a.Especie
	JOIN PETDB_Dono as d ON d.NIF = a.Dono
	WHERE (@OwnerNIF IS NULL OR d.NIF = @OwnerNIF) AND a.IsActive = 1
	ORDER BY a.Nome;
END
GO


CREATE PROCEDURE SP_GetOwnerTable
	@OwnerNIF int = NULL
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Dono
	WHERE (@OwnerNIF IS NULL OR NIF=@OwnerNIF) AND IsActive = 1
	ORDER BY Nome;
END 
GO

CREATE PROCEDURE SP_GetPetsByClinic
		@ClinicNIF int
AS
BEGIN  
	SET NOCOUNT ON; 

	SELECT a.Numero, a.Nome, a.DataNascimento, a.Peso, a.Sexo, d.Nome as Dono, e.Descricao as Especie 
	FROM PETDB_Animal as a
	JOIN PETDB_Especie as e ON e.Codigo = a.Especie
	JOIN PETDB_Consulta as c ON a.Numero=Animal
	JOIN PETDB_MedicoVeterinario as m ON c.Medico=m.NumOMV
	JOIN PETDB_Dono as d ON d.NIF = a.Dono
	WHERE m.Clinica=@ClinicNIF AND a.IsActive = 1
	ORDER BY a.Nome;
END
GO

CREATE PROCEDURE SP_GetPrescriptionsByPet
		@PetNum int
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Prescricao
	WHERE Animal=@PetNum AND IsActive = 1
	ORDER BY [Data] DESC; 
END 
GO



CREATE PROCEDURE SP_GetSpecialtyTable
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM PETDB_Especialidade
	WHERE IsActive = 1
	ORDER BY Descricao;
END
GO

CREATE PROCEDURE SP_GetClinicByNIF
	@ClinicNIF int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM PETDB_ClinicaVeterinaria WHERE NIF=@ClinicNIF AND IsActive = 1;
END
GO

CREATE PROCEDURE SP_GetMedicByOMV
	@MedicOMV int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM PETDB_MedicoVeterinario WHERE NumOMV=@MedicOMV AND IsActive = 1;
END
GO

CREATE PROCEDURE SP_GetPaymentAppointment
	@PaymentId int
AS 
BEGIN 
	SET NOCOUNT ON; 
	SELECT Consulta FROM PETDB_Pagamento WHERE Id = @PaymentId AND IsActive = 1; 
END 
GO

CREATE PROCEDURE SP_GetPaymentMethods
AS 
BEGIN 
	SET NOCOUNT ON; 
	SELECT * FROM PETDB_MetodoPagamento WHERE IsActive = 1; 
END 
GO 

CREATE PROCEDURE SP_GetPaymentDate
	@PaymentId int
AS 
BEGIN 
	SET NOCOUNT ON; 
	SELECT [Data] FROM PETDB_Pagamento WHERE Id = @PaymentId AND IsActive = 1;
END 
GO

CREATE PROCEDURE SP_GetTreatments
AS 
BEGIN 
	SET NOCOUNT ON; 
	SELECT * FROM PETDB_Tratamento WHERE IsActive = 1;
END 
GO

CREATE PROCEDURE SP_GetMostRecentAppointmentId
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT TOP 1 Id FROM PETDB_Consulta
	ORDER BY Id DESC; 
END 
GO

CREATE PROCEDURE SP_GetPrescriptionDate
	@PrescriptionId int
AS 
BEGIN 
	SET NOCOUNT ON;	
	SELECT [Data] FROM PETDB_Prescricao
	WHERE Numero = @PrescriptionId AND IsActive = 1;
END
GO

CREATE PROCEDURE SP_GetPaymentsByMethod
	@MethodId int
AS 
BEGIN 
	SET NOCOUNT ON; 
	SELECT p.Id, p.[Data], p.Custo, p.Estado, m.Descricao as Metodo, a.Nome as Animal, v.Nome as Medico
	FROM PETDB_Pagamento as p
	JOIN PETDB_MetodoPagamento as m ON p.MetodoPagamento = m.Codigo
	JOIN PETDB_Consulta as c ON p.Consulta = c.Id
	JOIN PETDB_Animal as a ON c.Animal = a.Numero
	JOIN PETDB_MedicoVeterinario as v ON c.Medico = v.NumOMV
	WHERE m.Codigo = @MethodId AND p.IsActive = 1
	ORDER BY p.[Data] DESC;
END
GO 

CREATE PROCEDURE SP_GetAppointmentsByTreatment
	@TreatmentId int
AS 
BEGIN 
	SET NOCOUNT ON;

	SELECT c.Id, c.[Data], a.Nome as Animal, c.Medico FROM PETDB_ConsultaTratamento as ct 
	JOIN PETDB_Consulta as c ON c.Id = ct.IdConsulta
	JOIN PETDB_Animal as a ON a.Numero = c.Animal
	WHERE ct.CodigoTratamento = @TreatmentId AND c.IsActive = 1;
END
GO