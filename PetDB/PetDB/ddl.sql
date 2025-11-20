CREATE TABLE PETDB_Dono(
	NIF int PRIMARY KEY CHECK (99999999 < NIF AND NIF < 1000000000), 
	Nome varchar(64) NOT NULL, 
	Telefone varchar(9) NOT NULL, 
	Email varchar(64) NOT NULL, 
	Endereco varchar(64) NOT NULL
);
GO

CREATE TABLE PETDB_Especie(
	Codigo int PRIMARY KEY, 
	Descricao varchar(64) NOT NULL
);
GO

CREATE TABLE PETDB_ClinicaVeterinaria(
	NIF int PRIMARY KEY CHECK (99999999 < NIF AND NIF < 1000000000), 
	Nome varchar(64) NOT NULL, 
	Telefone varchar(9) NOT NULL, 
	Email varchar(64) NOT NULL, 
	Endereco varchar(64) NOT NULL
);
GO 

CREATE TABLE PETDB_Especialidade(
	Codigo int PRIMARY KEY, 
	Descricao varchar(64) NOT NULL
); 
GO

CREATE TABLE PETDB_MedicoVeterinario(
	NumOMV int PRIMARY KEY,
	Nome varchar(64) NOT NULL, 
	Telefone varchar(9) NOT NULL, 
	Email varchar(64) NOT NULL, 
	Especialidade int NOT NULL, 
	Clinica int NOT NULL, 
	FOREIGN KEY (Especialidade) REFERENCES PETDB_Especialidade(Codigo),
	FOREIGN KEY (Clinica) REFERENCES PETDB_ClinicaVeterinaria(NIF)
);
GO 

CREATE TABLE PETDB_Animal(
	Numero int IDENTITY(1,1) PRIMARY KEY, 
	Nome varchar(64) NOT NULL, 
	DataNascimento date NOT NULL, 
	Peso float NOT NULL, 
	Sexo char(1) NOT NULL CHECK (Sexo IN ('M', 'F')), 
	Especie int NOT NULL, 
	Dono int NOT NULL,
	FOREIGN KEY (Especie) REFERENCES PETDB_Especie(Codigo), 
	FOREIGN KEY (Dono) REFERENCES PETDB_Dono(NIF)
);
GO

CREATE TABLE PETDB_Consulta(
	Id int IDENTITY(1,1) PRIMARY KEY, 
	[Data] date NOT NULL, 
	Animal int NOT NULL, 
	Medico int NOT NULL, 
	FOREIGN KEY (Animal) REFERENCES PETDB_Animal(Numero),
	FOREIGN KEY (Medico) REFERENCES PETDB_MedicoVeterinario(NumOMV)
);
GO 

CREATE TABLE PETDB_Tratamento(
	Codigo int IDENTITY(1,1) PRIMARY KEY, 
	Descricao varchar(64) NOT NULL
);
GO 

CREATE TABLE PETDB_ConsultaTratamento(
	IdConsulta int, 
	CodigoTratamento int, 
	PRIMARY KEY (IdConsulta, CodigoTratamento), 
	FOREIGN KEY (IdConsulta) REFERENCES PETDB_Consulta(Id), 
	FOREIGN KEY (CodigoTratamento) REFERENCES PETDB_Tratamento(Codigo)
);
GO

CREATE TABLE PETDB_Vacina(
	CodigoVacina int,
	Consulta int,
	Descricao varchar(64) NOT NULL, 
	PRIMARY KEY (CodigoVacina, Consulta), 
	FOREIGN KEY (Consulta) REFERENCES PETDB_Consulta(Id)
);
GO 

CREATE TABLE PETDB_Relatorio(
	CodigoRelatorio int, 
	Consulta int, 
	Conteudo varchar(MAX) NOT NULL, 
	PRIMARY KEY (CodigoRelatorio, Consulta),
	FOREIGN KEY (Consulta) REFERENCES PETDB_Consulta(Id)
);
GO 

CREATE TABLE PETDB_MetodoPagamento(
	Codigo int PRIMARY KEY, 
	Descricao varchar(64) NOT NULL
);
GO 

CREATE TABLE PETDB_Pagamento(
	Id int IDENTITY(1,1) PRIMARY KEY, 
	[Data] datetime NOT NULL, 
	Custo float NOT NULL CHECK (Custo > 0), 
	Estado varchar(8) NOT NULL CHECK (Estado IN ('Pago', 'Pendente')), 
	MetodoPagamento int NOT NULL, 
	Consulta int NOT NULL, 
	FOREIGN KEY (MetodoPagamento) REFERENCES PETDB_MetodoPagamento(Codigo),
	FOREIGN KEY (Consulta) REFERENCES PETDB_Consulta(Id)
); 
GO 

CREATE TABLE PETDB_Prescricao(
	Numero int PRIMARY KEY, 
	[Data] date NOT NULL, 
	Animal int NOT NULL, 
	FOREIGN KEY (Animal) REFERENCES PETDB_Animal(Numero)
);
GO 

CREATE TABLE PETDB_Medicamento(
	Codigo int PRIMARY KEY, 
	Descricao varchar(64) NOT NULL, 
	Dose varchar(10) NOT NULL
);
GO 

CREATE TABLE PETDB_PrescricaoMedicamento(
	NumeroPrescricao int, 
	CodigoMedicamento int, 
	PRIMARY KEY(NumeroPrescricao, CodigoMedicamento),
	FOREIGN KEY (NumeroPrescricao) REFERENCES PETDB_Prescricao(Numero),
	FOREIGN KEY (CodigoMedicamento) REFERENCES PETDB_Medicamento(Codigo)
);
GO