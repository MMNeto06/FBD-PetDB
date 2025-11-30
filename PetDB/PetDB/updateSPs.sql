CREATE PROCEDURE SP_UpdateClinic 
		@ClinicNIF int, 
		@ClinicName varchar(64),
		@ClinicPhone varchar(9), 
		@ClinicEmail varchar(64), 
		@ClinicAddress varchar(64)
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEUPDATE
			UPDATE PETDB_ClinicaVeterinaria 
			SET Nome=@ClinicName, Telefone=@ClinicPhone, Email=@ClinicEmail, Endereco=@ClinicAddress
			WHERE NIF=@ClinicNIF;
		COMMIT TRANSACTION SCHEDULEUPDATE
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEUPDATE
	END CATCH
END
GO

CREATE PROCEDURE SP_UpdateVet 
		@VetOMV int,
		@VetName varchar(64),
		@VetPhone varchar(9), 
		@VetEmail varchar(64), 
		@VetSpecialty int,
		@VetClinic int
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEUPDATE
			UPDATE PETDB_MedicoVeterinario 
			SET Nome=@VetName, Telefone=@VetPhone, Email=@VetEmail, Especialidade=@VetSpecialty, Clinica=@VetClinic
			WHERE NumOMV=@VetOMV;
		COMMIT TRANSACTION SCHEDULEUPDATE
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEUPDATE
	END CATCH
END
GO

CREATE PROCEDURE SP_UpdateSpecialty
		@SpecialtyCode int,
		@SpecialtyDescription varchar(64)
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEUPDATE
			UPDATE PETDB_Especialidade
			SET Descricao=@SpecialtyDescription
			WHERE Codigo=@SpecialtyCode;
		COMMIT TRANSACTION SCHEDULEUPDATE
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEUPDATE
	END CATCH
END
GO

CREATE PROCEDURE SP_UpdateOwner
		@OwnerNIF int, 
		@OwnerName varchar(64),
		@OwnerPhone varchar(9), 
		@OwnerEmail varchar(64), 
		@OwnerAddress varchar(64)
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEUPDATE
			UPDATE PETDB_Dono
			SET Nome=@OwnerName, 
				Telefone=@OwnerPhone, 
				Email=@OwnerEmail, 
				Endereco=@OwnerAddress
			WHERE NIF=@OwnerNIF;
		COMMIT TRANSACTION SCHEDULEUPDATE
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEUPDATE
	END CATCH
END
GO

CREATE PROCEDURE SP_UpdatePet
		@PetID int,
		@PetName varchar(64), 
		@PetBirthDate date,
		@PetWeight float, 
		@PetSex char(1), 
		@PetSpecie int, 
		@PetOwner int
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEUPDATE
			UPDATE PETDB_Animal
			SET Nome=@PetName,
				DataNascimento=@PetBirthDate,
				Peso=@PetWeight, 
				Sexo=@PetSex,
				Especie=@PetSpecie, 
				Dono=@PetOwner
			WHERE Numero=@PetID;
		COMMIT TRANSACTION SCHEDULEUPDATE
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEUPDATE
	END CATCH
END
GO

CREATE PROCEDURE SP_UpdateSpecie
		@SpecieCode int,
		@SpecieDescription varchar(64)
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEUPDATE	
			UPDATE PETDB_Especie
			SET Descricao=@SpecieDescription
			WHERE Codigo=@SpecieCode;
		COMMIT TRANSACTION SCHEDULEUPDATE
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEUPDATE
	END CATCH
END
GO

CREATE PROCEDURE SP_UpdateMedicine
		@MedicineCode int, 
		@MedicineDescription varchar(64), 
		@MedicineDose varchar(10)
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEUPDATE
			UPDATE PETDB_Medicamento
			SET Descricao=@MedicineDescription, 
				Dose=@MedicineDose
			WHERE Codigo=@MedicineCode;
		COMMIT TRANSACTION SCHEDULEUPDATE
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEUPDATE
	END CATCH
END
GO

CREATE PROCEDURE SP_UpdateAppointment
		@AppointmentID int,
		@AppointmentDate datetime, 
		@AppointmentPet int, 
		@AppointmentVet int
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEUPDATE
			UPDATE PETDB_Consulta
			SET [Data]=@AppointmentDate,
				Animal=@AppointmentPet, 
				Medico=@AppointmentVet
			WHERE Id=@AppointmentID;
		COMMIT TRANSACTION SCHEDULEUPDATE
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEUPDATE
	END CATCH
END
GO

CREATE PROCEDURE SP_UpdatePayment
		@PaymentID int,
		@PaymentDate datetime, 
		@PaymentValue float, 
		@PaymentStatus varchar(8),
		@PaymentMethod int, 
		@PaymentAppointment int
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEUPDATE
			UPDATE PETDB_Pagamento
			SET [Data]=@PaymentDate, 
				Custo=@PaymentValue, 
				Estado=@PaymentStatus, 
				MetodoPagamento=@PaymentMethod, 
				Consulta=@PaymentAppointment
			WHERE Id=@PaymentID
		COMMIT TRANSACTION SCHEDULEUPDATE
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEUPDATE
	END CATCH
END
GO

CREATE PROCEDURE SP_UpdatePrescription
		@PrescriptionNumber int, 
		@PrescriptionDate date, 
		@PrescriptionPet int
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEUPDATE
			UPDATE PETDB_Prescricao
			SET [Data]=@PrescriptionDate, 
				Animal=@PrescriptionPet
			WHERE Numero=@PrescriptionNumber;
		COMMIT TRANSACTION SCHEDULEUPDATE
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEUPDATE
	END CATCH
END
GO



