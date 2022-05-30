CREATE TABLE [dbo].[tb_questao] (
    [Numero]        INT           IDENTITY (1, 1) NOT NULL,
    [Enunciado]     VARCHAR (MAX) NOT NULL,
    [Disciplina_id] INT           NOT NULL,
    [Materia_id]    INT           NOT NULL,
    CONSTRAINT [PK_tb_questao] PRIMARY KEY CLUSTERED ([Numero] ASC)
);

