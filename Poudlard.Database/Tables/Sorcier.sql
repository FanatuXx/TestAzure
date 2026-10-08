CREATE TABLE [dbo].[Sorcier]
(
	[Id] INT NOT NULL IDENTITY, 
    [Nom] NVARCHAR(50) NOT NULL, 
    [Prenom] NVARCHAR(50) NOT NULL, 
    [MaisonId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_Sorcier] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Sorcier_Maison] FOREIGN KEY ([MaisonId]) REFERENCES [Maison]([Id]) 
)
