CREATE PROCEDURE SP_GetMedInfo
AS 
BEGIN
	SET NOCOUNT ON; 

	SELECT Codigo, Descricao AS Nome, Dose FROM PETDB_Medicamento;
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
END 
GO 

CREATE PROCEDURE SP_GetClinicTable
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_ClinicaVeterinaria
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
END
GO

CREATE PROCEDURE SP_GetPetInfo
AS
BEGIN
	SET NOCOUNT ON; 

	SELECT a.Numero, a.Nome, a.DataNascimento, a.Peso, a.Sexo, e.Descricao as Especie, d.Nome as Dono
	FROM PETDB_Animal as a
	JOIN PETDB_Especie as e ON e.Codigo = a.Especie
	JOIN PETDB_Dono as d ON d.NIF = a.Dono;
END
GO


CREATE PROCEDURE SP_GetOwnerTable
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Dono
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
	WHERE Clinica=@ClinicNIF;
END
GO

CREATE PROCEDURE SP_GetAppointmentsByPet
		@PetNum int
AS
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Consulta
	WHERE Animal=@PetNum;
END
GO

CREATE PROCEDURE SP_GetAppointmentsByVet
		@VetOMV int
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Consulta
	WHERE Medico=@VetOMV;
END 
GO

CREATE PROCEDURE SP_GetPrescriptionsByPet
		@PetNum int
AS 
BEGIN 
	SET NOCOUNT ON; 

	SELECT * FROM PETDB_Prescricao
	WHERE Animal=@PetNum;
END 
GO

CREATE PROCEDURE SP_GetPaymentsByOwner
		@OwnerNIF int
AS
BEGIN
	SET NOCOUNT ON; 

	SELECT P.Id, P.[Data], P.Custo, P.Estado, P.MetodoPagamento, P.Consulta
	FROM PETDB_Pagamento AS P
	JOIN PETDB_Consulta AS C ON C.Id=Consulta
	JOIN PETDB_Animal ON Numero=C.Animal
	WHERE Dono=@OwnerNIF;
END
GO

CREATE PROCEDURE SP_GetSpecialtyTable
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM PETDB_Especialidade;
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