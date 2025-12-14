CREATE PROCEDURE SP_GetMedInfo
AS 
BEGIN
	SET NOCOUNT ON; 

	SELECT Codigo, Descricao AS Nome, Dose FROM PETDB_Medicamento
	ORDER BY Descricao;
END
GO

CREATE PROCEDURE SP_GetAnimalsBySpecie @specieID INT
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT a.Nome 
	FROM PETDB_Animal as a
	WHERE a.Especie = @specieID
	ORDER BY a.Nome;
END
GO

CREATE PROCEDURE SP_GetSpecieInfo
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Especie
	ORDER BY Descricao;
END 
GO

CREATE PROCEDURE SP_GetSpecieName @specieID int
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT Descricao FROM PETDB_Especie
	WHERE Codigo=@specieID
	ORDER BY Descricao;
END 
GO

CREATE PROCEDURE SP_GetSpecialityInfo
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Especialidade
	ORDER BY Descricao;
END 
GO

CREATE PROCEDURE SP_GetVetsBySpeciality @specialityID INT 
AS
BEGIN 
	SET NOCOUNT ON; 

	SELECT v.Nome 
	FROM PETDB_MedicoVeterinario as v 
	WHERE v.Especialidade = @specialityID
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
	WHERE pm.NumeroPrescricao = @prescriptionID
	ORDER BY m.Descricao;
END 
GO

CREATE PROCEDURE SP_GetPrescriptionInfo 
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT p.Numero, p.[Data], a.Nome as Animal
	FROM PETDB_Prescricao as p 
	JOIN PETDB_Animal as a ON p.Animal = a.Numero
	ORDER BY p.[Data] DESC;
END 
GO 

CREATE PROCEDURE SP_GetAppointmentReportById @appointmentID INT
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT r.CodigoRelatorio, r.Conteudo
	FROM PETDB_Relatorio as r 
	WHERE r.Consulta = @appointmentID;
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

CREATE PROCEDURE SP_GetPaymentInfo
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT p.Id, p.[Data], p.Custo, p.Estado, m.Descricao as Metodo, a.Nome as Animal, v.Nome as Medico
	FROM PETDB_Pagamento as p
	JOIN PETDB_MetodoPagamento as m ON p.MetodoPagamento = m.Codigo
	JOIN PETDB_Consulta as c ON p.Consulta = c.Id
	JOIN PETDB_Animal as a ON c.Animal = a.Numero
	JOIN PETDB_MedicoVeterinario as v ON c.Medico = v.NumOMV
	ORDER BY p.[Data] DESC;
END 
GO

CREATE PROCEDURE SP_GetAppointmentInfo
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT c.Id, c.[Data], a.Nome as Animal, v.Nome as Medico
	FROM PETDB_Consulta as c
	JOIN PETDB_Animal as a ON c.Animal = a.Numero
	JOIN PETDB_MedicoVeterinario as v ON c.Medico = v.NumOMV
	ORDER BY c.[Data] DESC;
END 
GO 

CREATE PROCEDURE SP_GetAppointmentInfoByAnimal @AnimalId int
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT c.Id, c.[Data], a.Nome as Animal, v.Nome as Medico
	FROM PETDB_Consulta as c
	JOIN PETDB_Animal as a ON c.Animal = a.Numero
	JOIN PETDB_MedicoVeterinario as v ON c.Medico = v.NumOMV
	WHERE a.Numero=@AnimalId
	ORDER BY c.[Data] DESC;
END 
GO 

CREATE PROCEDURE SP_GetClinicTable
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_ClinicaVeterinaria
	ORDER BY Nome;
END
GO

CREATE PROCEDURE SP_GetVetInfo
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT v.NumOMV, v.Nome, v.Telefone, v.Email, e.Descricao as Especialidade, c.Nome as Clinica
	FROM PETDB_MedicoVeterinario as v
	JOIN PETDB_Especialidade as e ON v.Especialidade = e.Codigo
	JOIN PETDB_ClinicaVeterinaria as c ON v.Clinica = c.NIF
	ORDER BY v.Nome;
END
GO

CREATE PROCEDURE SP_GetPetInfo
AS
BEGIN
	SET NOCOUNT ON; 

	SELECT a.Numero, a.Nome, a.DataNascimento, a.Peso, a.Sexo, e.Descricao as Especie, d.Nome as Dono
	FROM PETDB_Animal as a
	JOIN PETDB_Especie as e ON e.Codigo = a.Especie
	JOIN PETDB_Dono as d ON d.NIF = a.Dono
	ORDER BY a.Nome;
END
GO


CREATE PROCEDURE SP_GetOwnerTable
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Dono
	ORDER BY Nome;
END 
GO

CREATE PROCEDURE SP_GetVetsByClinic
		@ClinicNIF int
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_MedicoVeterinario
	WHERE Clinica=@ClinicNIF
	ORDER BY Nome; 

END
GO

CREATE PROCEDURE SP_GetPetsByOwner
		@OwnerNIF int
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Animal
	WHERE Dono=@OwnerNIF
	ORDER BY Nome;

END 
GO

CREATE PROCEDURE SP_GetPetsByClinic
		@ClinicNIF int
AS
BEGIN  
	SET NOCOUNT ON; 

	SELECT A.Numero, A.Nome, A.DataNascimento, A.Peso, A.Sexo, A.Dono, A.Especie 
	FROM PETDB_Animal as A
	JOIN PETDB_Consulta ON Numero=Animal
	JOIN PETDB_MedicoVeterinario ON Medico=NumOMV
	WHERE Clinica=@ClinicNIF
	ORDER BY A.Nome;
END
GO

CREATE PROCEDURE SP_GetAppointmentsByPet
		@PetNum int
AS
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Consulta
	WHERE Animal=@PetNum
	ORDER BY [Data] DESC;
END
GO

CREATE PROCEDURE SP_GetAppointmentsByVet
		@VetOMV int
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Consulta
	WHERE Medico=@VetOMV
	ORDER BY [Data] DESC; 
END 
GO

CREATE PROCEDURE SP_GetPrescriptionsByPet
		@PetNum int
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Prescricao
	WHERE Animal=@PetNum
	ORDER BY [Data] DESC; 
END 
GO

CREATE PROCEDURE SP_GetPaymentsByOwner
		@OwnerNIF int
AS
BEGIN
	SET NOCOUNT ON; 

	SELECT p.Id, p.[Data], p.Custo, p.Estado, m.Descricao as MetodoPagamento, a.Nome, v.Nome as Medico, p.Consulta
	FROM PETDB_Pagamento as p
	JOIN PETDB_MetodoPagamento as m ON p.MetodoPagamento = m.Codigo
	JOIN PETDB_Consulta as c ON p.Consulta = c.Id
	JOIN PETDB_Animal as a ON c.Animal = a.Numero
	JOIN PETDB_MedicoVeterinario as v ON c.Medico = v.NumOMV
	WHERE Dono=@OwnerNIF
	ORDER BY p.[Data] DESC;
END
GO

CREATE PROCEDURE SP_GetSpecialtyTable
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM PETDB_Especialidade
	ORDER BY Descricao;
END
GO

CREATE PROCEDURE SP_GetClinicByNIF
	@ClinicNIF int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM PETDB_ClinicaVeterinaria WHERE NIF=@ClinicNIF;
END
GO

CREATE PROCEDURE SP_GetMedicByOMV
	@MedicOMV int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM PETDB_MedicoVeterinario WHERE NumOMV=@MedicOMV;
END
GO

CREATE PROCEDURE SP_GetOwnerByNIF
	@OwnerNIF int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM PETDB_Dono WHERE NIF=@OwnerNIF;
END
GO

CREATE PROCEDURE SP_GetPaymentAppointment
	@PaymentId int
AS 
BEGIN 
	SET NOCOUNT ON; 
	SELECT Consulta FROM PETDB_Pagamento WHERE Id = @PaymentId; 
END 
GO

CREATE PROCEDURE SP_GetPaymentMethods
AS 
BEGIN 
	SET NOCOUNT ON; 
	SELECT * FROM PETDB_MetodoPagamento; 
END 
GO 
	