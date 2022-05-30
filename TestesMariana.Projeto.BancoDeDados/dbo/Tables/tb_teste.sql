CREATE TABLE [dbo].[tb_teste] (
    [Numero]              INT           IDENTITY (1, 1) NOT NULL,
    [Nome]                VARCHAR (MAX) NOT NULL,
    [Quantidade_Questoes] INT           NOT NULL,
    [Disciplina_id]       INT           NOT NULL,
    [Materia_id]          INT           NOT NULL,
    [Data_Criacao]        DATETIME      NOT NULL,
    CONSTRAINT [PK_tb_teste] PRIMARY KEY CLUSTERED ([Numero] ASC)
);

