CREATE PROCEDURE SP_AddClinic 
		@ClinicNIF int, 
		@ClinicName varchar(64),
		@ClinicPhone varchar(9), 
		@ClinicEmail varchar(64), 
		@ClinicAddress varchar(64)
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEINSERT
			INSERT INTO PETDB_ClinicaVeterinaria(NIF, Nome, Telefone, Email, Endereco)
			VALUES (@ClinicNIF, @ClinicName, @ClinicPhone, @ClinicEmail, @ClinicAddress);
		COMMIT TRANSACTION SCHEDULEINSERT
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEINSERT
	END CATCH
END
GO

CREATE PROCEDURE SP_AddVet
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
		BEGIN TRANSACTION SCHEDULEINSERT
			INSERT INTO PETDB_MedicoVeterinario(NumOMV, Nome, Telefone, Email, Especialidade, Clinica)
			VALUES (@VetOMV, @VetName, @VetPhone, @VetEmail, @VetSpecialty, @VetClinic);
		COMMIT TRANSACTION SCHEDULEINSERT
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEINSERT
	END CATCH
END
GO

CREATE PROCEDURE SP_AddSpecialty
		@SpecialtyDescription varchar(64)
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEINSERT
			INSERT INTO PETDB_Especialidade(Descricao)
			VALUES (@SpecialtyDescription);
		COMMIT TRANSACTION SCHEDULEINSERT
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEINSERT
	END CATCH
END
GO

CREATE PROCEDURE SP_AddOwner
		@OwnerNIF int, 
		@OwnerName varchar(64),
		@OwnerPhone varchar(9), 
		@OwnerEmail varchar(64), 
		@OwnerAddress varchar(64)
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEINSERT
			INSERT INTO PETDB_Dono(NIF, Nome, Telefone, Email, Endereco)
			VALUES (@OwnerNIF, @OwnerName, @OwnerPhone, @OwnerEmail, @OwnerAddress);
		COMMIT TRANSACTION SCHEDULEINSERT
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEINSERT
	END CATCH
END
GO

CREATE PROCEDURE SP_AddPet
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
		BEGIN TRANSACTION SCHEDULEINSERT
			INSERT INTO PETDB_Animal(Nome, DataNascimento, Peso, Sexo, Especie, Dono)
			VALUES (@PetName, @PetBirthDate, @PetWeight, @PetSex, @PetSpecie, @PetOwner);
		COMMIT TRANSACTION SCHEDULEINSERT
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEINSERT
	END CATCH
END
GO

CREATE PROCEDURE SP_AddSpecie
		@SpecieDescription varchar(64)
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEINSERT
			INSERT INTO PETDB_Especie(Descricao)
			VALUES (@SpecieDescription);
		COMMIT TRANSACTION SCHEDULEINSERT
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEINSERT
	END CATCH
END
GO

CREATE PROCEDURE SP_AddMedicine
		@MedicineCode int, 
		@MedicineDescription varchar(64), 
		@MedicineDose varchar(10)
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEINSERT
			INSERT INTO PETDB_Medicamento(Codigo, Descricao, Dose)
			VALUES (@MedicineCode, @MedicineDescription, @MedicineDose);
		COMMIT TRANSACTION SCHEDULEINSERT
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEINSERT
	END CATCH
END
GO

CREATE PROCEDURE SP_AddAppointment
		@AppointmentDate datetime, 
		@AppointmentPet int, 
		@AppointmentVet int
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEINSERT
			INSERT INTO PETDB_Consulta([Data], Animal, Medico)
			VALUES (@AppointmentDate, @AppointmentPet, @AppointmentVet);
		COMMIT TRANSACTION SCHEDULEINSERT
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEINSERT
	END CATCH
END
GO

CREATE PROCEDURE SP_AddPayment
		@PaymentDate datetime, 
		@PaymentValue float, 
		@PaymentStatus varchar(8),
		@PaymentMethod int, 
		@PaymentAppointment int
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEINSERT
			INSERT INTO PETDB_Pagamento([Data], Custo, Estado, MetodoPagamento, Consulta)
			VALUES (@PaymentDate, @PaymentValue, @PaymentStatus, @PaymentMethod, @PaymentAppointment);
		COMMIT TRANSACTION SCHEDULEINSERT
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEINSERT
	END CATCH
END
GO

CREATE PROCEDURE SP_AddPrescription
		@PrescriptionNumber int, 
		@PrescriptionDate date, 
		@PrescriptionPet int
AS
BEGIN 
	SET NOCOUNT ON; 

	BEGIN TRY 
		BEGIN TRANSACTION SCHEDULEINSERT
			INSERT INTO PETDB_Prescricao(Numero, [Data], Animal)
			VALUES (@PrescriptionNumber, @PrescriptionDate, @PrescriptionPet);
		COMMIT TRANSACTION SCHEDULEINSERT
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEINSERT
	END CATCH
END
GO



