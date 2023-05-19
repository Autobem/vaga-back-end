use CarrosVagaBackEnd;

INSERT INTO Proprietarios 
           (Id,EnderecoId,Nome,Documento,CNH)
     VALUES
           ('7748bbb4-08dc-4ab4-9502-4c2bed2c3c54','854241e0-c4c7-479d-b2d5-e4fc4585e9c4', 'Davisson', '44900102345', '012345678');

SELECT * FROM Proprietarios;
SELECT * FROM Carros;
SELECT * FROM Enderecos;
		   
INSERT INTO Enderecos
           (Id
           ,Logradouro
           ,Numero
           ,Complemento
           ,Cep
           ,Bairro
           ,Cidade
           ,Estado
           ,UF
           ,ProprietarioId)
     VALUES
           ('854241e0-c4c7-479d-b2d5-e4fc4585e9c4', 'Rua Angelo', '000', 'Casa', '09390555','Vila Nova Mauá',
		   'Mauá', 'São Paulo', 'SP', '7748bbb4-08dc-4ab4-9502-4c2bed2c3c54');


INSERT INTO Carros
           (Id,ProprietarioId,Fabricante,ModeloCarro,AnoModelo,Categoria ,Cor)
     VALUES
           ('9f780aa6-bd9d-41a9-a1fe-07237e5c0174', '78FABE0A-F9BB-4F38-8FC2-2E923E4D7252', 'Ford', 'Focus', '2023', 'Hatch', 'Branco');

INSERT INTO Carros
           (Id,ProprietarioId,Fabricante,ModeloCarro,AnoModelo,Categoria ,Cor)
     VALUES
           ('cf942bea-d3e0-40a1-8e47-91a564e08a9f', '78FABE0A-F9BB-4F38-8FC2-2E923E4D7252', 'Ford', 'Ka', '2023', 'Hatch', 'Vermelho');


INSERT INTO Carros
           (Id,ProprietarioId,Fabricante,ModeloCarro,AnoModelo,Categoria ,Cor)
     VALUES
           ('a482acab-c969-4659-ab00-b0ec197c1093', '7748BBB4-08DC-4AB4-9502-4C2BED2C3C54', 'Chevrolet', 'Onix', '2023', 'Hatch', 'Azul');

INSERT INTO Carros
           (Id,ProprietarioId,Fabricante,ModeloCarro,AnoModelo,Categoria ,Cor)
     VALUES
           ('85dba2ba-a586-440c-b6d0-128056ceac04', 'E874CCC4-563D-4CD8-8BB8-B9D0CA8145C6', 'Volkswagen', 'Jetta', '2023', 'Sedan', 'Amarelo');


UPDATE Proprietarios
SET Nome = 'João'
WHERE Id = 'E874CCC4-563D-4CD8-8BB8-B9D0CA8145C6';