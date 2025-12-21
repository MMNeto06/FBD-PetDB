CREATE NONCLUSTERED INDEX IX_PETDB_Animal_Dono ON PETDB_Animal(Dono) INCLUDE (Nome, IsActive);
CREATE NONCLUSTERED INDEX IX_PETDB_Animal_Especie ON PETDB_Animal(Especie) INCLUDE (Nome, IsActive);
CREATE NONCLUSTERED INDEX IX_PETDB_Medico_Clinica ON PETDB_MedicoVeterinario(Clinica) INCLUDE (Nome, Especialidade, IsActive);
CREATE NONCLUSTERED INDEX IX_PETDB_Medico_Especialidade ON PETDB_MedicoVeterinario(Especialidade) INCLUDE (Nome, IsActive);
CREATE NONCLUSTERED INDEX IX_PETDB_Consulta_Animal ON PETDB_Consulta(Animal) INCLUDE ([Data], Medico, IsActive);
CREATE NONCLUSTERED INDEX IX_PETDB_Consulta_Medico ON PETDB_Consulta(Medico) INCLUDE ([Data], Animal, IsActive);
CREATE NONCLUSTERED INDEX IX_PETDB_Dono_Nome ON PETDB_Dono(Nome) WHERE IsActive = 1;
CREATE NONCLUSTERED INDEX IX_PETDB_Clinica_Nome ON PETDB_ClinicaVeterinaria(Nome) WHERE IsActive = 1;
CREATE NONCLUSTERED INDEX IX_PETDB_ConsultaTratamento_Codigo ON PETDB_ConsultaTratamento(CodigoTratamento);
CREATE NONCLUSTERED INDEX IX_PETDB_PrescricaoMed_Codigo ON PETDB_PrescricaoMedicamento(CodigoMedicamento);
CREATE NONCLUSTERED INDEX IX_PETDB_Pagamento_Ativo_Estado 
ON PETDB_Pagamento(Estado, [Data]) 
INCLUDE (Custo, Consulta)
WHERE IsActive = 1;
CREATE NONCLUSTERED INDEX IX_PETDB_Pagamento_BuscaRelatorio
ON PETDB_Pagamento (Consulta, MetodoPagamento)
INCLUDE (Custo, Estado, [Data])
WHERE IsActive = 1;
CREATE NONCLUSTERED INDEX IX_PETDB_Prescricao_Animal 
ON PETDB_Prescricao(Animal) 
INCLUDE ([Data], IsActive);
CREATE NONCLUSTERED INDEX IX_PETDB_Prescricao 
ON PETDB_Prescricao(VetOMV)
INCLUDE ([Data], IsActive); 
