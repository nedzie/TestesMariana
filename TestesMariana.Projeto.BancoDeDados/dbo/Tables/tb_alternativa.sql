CREATE TABLE [dbo].[tb_alternativa] (
    [Numero]     INT           IDENTITY (1, 1) NOT NULL,
    [Opcao]      VARCHAR (MAX) NOT NULL,
    [Esta_Certa] BIT           NOT NULL,
    [Questao_id] INT           NOT NULL,
    CONSTRAINT [PK_tb_alternativa] PRIMARY KEY CLUSTERED ([Numero] ASC)
);

