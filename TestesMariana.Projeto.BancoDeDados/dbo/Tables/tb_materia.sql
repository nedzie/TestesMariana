CREATE TABLE [dbo].[tb_materia] (
    [Numero]        INT           IDENTITY (1, 1) NOT NULL,
    [Nome]          VARCHAR (MAX) NOT NULL,
    [Serie]         INT           NOT NULL,
    [Disciplina_id] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Numero] ASC),
    CONSTRAINT [FK_Disciplina_id] FOREIGN KEY ([Disciplina_id]) REFERENCES [dbo].[tb_disciplina] ([Numero])
);

