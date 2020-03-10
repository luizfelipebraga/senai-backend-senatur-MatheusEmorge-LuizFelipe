Use Senatur_Tarde

INSERT INTO TiposUsuario(Titulo)
VALUES ('Administrador'), ('Cliente');

INSERT INTO Usuarios(Email, Senha, IdTipoUsuario)
VALUES ('admin@admin.com','admin',1),('cliente@cliente.com','cliente',2);

INSERT INTO Pacotes (NomePacote,Descricao,DataIda,DataVolta,Valor,NomeCidade,Ativo)
VALUES ('Salvador - 5 dias / 4 diárias','O que não falta em Salvador são atrações.','06/08/2020','10/08/2020',854.00,'Salvador',1),
		('RESORTS NA BAHIA - LITORAL NORTE - 5 DIAS /4 DIAS','O Litoral Norte da Bahia conta com inúmeras praias emolduradas por coqueiros.','14/05/2020','18/05/2020',1826.00,'Salvadoro',1);