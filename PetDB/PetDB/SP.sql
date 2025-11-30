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
		BEGIN TRANSACTION 
			INSERT INTO PETDB_ClinicaVeterinaria(NIF, Nome, Telefone, Email, Endereco)
			VALUES (@ClinicNIF, @ClinicName, @ClinicPhone, @ClinicEmail, @ClinicAddress);
		COMMIT TRANSACTION SCHEDULEUPDATE
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION SCHEDULEUPDATE
	END CATCH
END
GO
