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