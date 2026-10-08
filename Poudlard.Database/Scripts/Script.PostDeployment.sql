/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


INSERT INTO Maison (Id, Nom, Fondateur, Couleur, Embleme) VALUES 
(N'28fe6773-670d-4ba8-bc19-3e59fc154a1e', N'Gryffondor', N'Godric Gryffondor', N'Rouge/Or', N'Lion'),
 -- Harry Potter, Hermione Granger, Ron Weasley, Neville Londubat 
(N'0603ca10-46aa-4aeb-ab9a-69a89e9e34cb', N'Serpentard', N'Salazar Serpentard', N'Vert/Argent', N'Serpent'),
 -- Draco Malefoy, Severus Rogue, Tom Jedusor
(N'19d6ca50-3f0b-42f2-9c7f-84a4438ce92d', N'Poufsouffle', N'Helga Poufsouffle', N'Jaune/Noir', N'Blaireau'),
 --Cedric Diggory, Nymphadora Tonks
(N'e68d1fa2-eceb-4284-b576-be5c37372896', N'Serdaigle', N'Rowena Serdaigle', N'Bleu/Argent', N'Aigle');
 --Luna Lovegood, Cho Chang

 INSERT INTO Sorcier (Prenom, Nom, MaisonId) VALUES
 (N'Harry', N'Potter', N'0603ca10-46aa-4aeb-ab9a-69a89e9e34cb'), 
 (N'Hermione', N'Granger', N'28fe6773-670d-4ba8-bc19-3e59fc154a1e'), 
 (N'Ron', N'Weasley', N'28fe6773-670d-4ba8-bc19-3e59fc154a1e'), 
 (N'Neville', N'Londubat', N'28fe6773-670d-4ba8-bc19-3e59fc154a1e'), 
 (N'Draco', N'Malefoy', N'0603ca10-46aa-4aeb-ab9a-69a89e9e34cb'), 
 (N'Severus', N'Rogue', N'0603ca10-46aa-4aeb-ab9a-69a89e9e34cb'), 
 (N'Tom', N'Jedusor', N'0603ca10-46aa-4aeb-ab9a-69a89e9e34cb'), 
 (N'Cedric', N'Diggory', N'19d6ca50-3f0b-42f2-9c7f-84a4438ce92d'), 
 (N'Nymphadora', N'Tonks', N'19d6ca50-3f0b-42f2-9c7f-84a4438ce92d'), 
 (N'Luna', N'Lovegood', N'e68d1fa2-eceb-4284-b576-be5c37372896'), 
 (N'Cho', N'Chang', N'e68d1fa2-eceb-4284-b576-be5c37372896');