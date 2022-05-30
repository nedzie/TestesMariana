CREATE TABLE [dbo].[tb_teste_questao] (
    [Numero]     INT IDENTITY (1, 1) NOT NULL,
    [Teste_id]   INT NOT NULL,
    [Questao_id] INT NOT NULL,
    CONSTRAINT [PK_tb_teste_questao] PRIMARY KEY CLUSTERED ([Numero] ASC)
);

