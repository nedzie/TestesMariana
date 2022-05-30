using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Dominio.ModuloQuestao;
using TestesMariana.Dominio.ModuloTeste;

namespace TestesMariana.Infra.BancoDeDados
{
    public class RepositorioTesteEmBancoDeDados
    {
        private const string enderecoBanco =
            "Data Source=MARCOS;Initial Catalog=mariana_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string sqlInserir =
            @"INSERT INTO TB_TESTE
                (
                    NOME,
                    QUANTIDADE_QUESTOES,
                    DISCIPLINA_ID,
                    MATERIA_ID,
                    DATA_CRIACAO
                )
                    VALUES
                (
                    @NOME,
                    @QUANTIDADE_QUESTOES,
                    @DISCIPLINA_ID,
                    @MATERIA_ID,
                    @DATA_CRIACAO
                ); SELECT SCOPE_IDENTITY();";

        private const string sqlInserirQuestoesTabelaNN =
            @"INSERT INTO TB_TESTE_QUESTAO
                (
                    TESTE_ID,
                    QUESTAO_ID
                )
                    VALUES
                (
                    @TESTE_ID,
                    @QUESTAO_ID
                )";

        private const string sqlEditar =
            @"";

        private const string sqlExcluir =
            @"";

        private const string sqlSelecionarTodos =
            @"SELECT
	            T.NOME AS NOME,
                T.NUMERO AS NUMERO,
	            D.NOME AS NOMEDISCIPLINA,
	            D.NUMERO AS NUMERODISCIPLINA,
	            M.NOME AS NOMEMATERIA,
	            M.NUMERO AS NUMEROMATERIA,
	            T.QUANTIDADE_QUESTOES AS QUANTIDADE_QUESTOES,
	            T.DATA_CRIACAO AS DATA_CRIACAO
            FROM
	            TB_TESTE AS T
	            INNER JOIN tb_disciplina AS D
	            ON T.DISCIPLINA_ID = D.Numero
	            INNER JOIN TB_MATERIA AS M
	            ON T.MATERIA_ID = M.NUMERO";

        private const string sqlSelecionarPorNumero =
            @"";


        public ValidationResult Inserir(Teste novoTeste)
        {
            var validador = new ValidadorTeste();

            var resultado = validador.Validate(novoTeste);

            if (!resultado.IsValid)
                return resultado;

            SqlConnection conexaoComBanco = new(enderecoBanco);

            SqlCommand comandoInsercao = new(sqlInserir, conexaoComBanco); // Aqui cria

            ConfigurarParametrosTeste(novoTeste, comandoInsercao);

            conexaoComBanco.Open();

            var id = comandoInsercao.ExecuteScalar(); // Aqui insere

            novoTeste.Numero = Convert.ToInt32(id);

            SqlCommand comandoInserirNParaN = new(sqlInserirQuestoesTabelaNN, conexaoComBanco);

            foreach (var questao in novoTeste.Questoes)
            {
                comandoInserirNParaN.Parameters.Clear();
                ConfigurarRegistroMultivalorado(questao, novoTeste, comandoInserirNParaN);
                comandoInserirNParaN.ExecuteNonQuery();
            }

            conexaoComBanco.Close();

            return resultado;
        }

        private void ConfigurarRegistroMultivalorado(Questao questao, Teste novoTeste, SqlCommand comandoInserirNParaN)
        {
            comandoInserirNParaN.Parameters.AddWithValue("TESTE_ID", novoTeste.Numero);
            comandoInserirNParaN.Parameters.AddWithValue("QUESTAO_ID", questao.Numero);
        }

        public ValidationResult Editar(Teste materia)
        {
            var validador = new ValidadorTeste();

            var resultado = validador.Validate(materia);

            if (!resultado.IsValid)
                return resultado;

            SqlConnection conexaoComBanco = new(enderecoBanco);

            SqlCommand comandoEdicao = new(sqlEditar, conexaoComBanco);

            ConfigurarParametrosTeste(materia, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery(); // Edita aqui
            conexaoComBanco.Close();

            return resultado;
        }

        public ValidationResult Excluir(Teste materiaSelecionada)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", materiaSelecionada.Numero);

            conexaoComBanco.Open();

            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery(); // Exclui aqui

            var resultado = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultado.Errors.Add(new ValidationFailure("", "Não deu pra deletar"));

            conexaoComBanco.Close();

            return resultado;
        }

        public List<Teste> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();

            SqlDataReader leitor = comandoSelecao.ExecuteReader(); // Lê aqui

            List<Teste> testes = new();

            while (leitor.Read())
            {
                Teste teste = ConverterParaTeste(leitor);
                testes.Add(teste);
            }

            return testes;
        }


        public Teste SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();

            SqlDataReader leitor = comandoSelecao.ExecuteReader(); // Lê aqui

            Teste teste = new();

            if (leitor.Read())
                teste = ConverterParaTeste(leitor);

            conexaoComBanco.Close();

            return teste;
        }

        private Teste ConverterParaTeste(SqlDataReader leitor)
        {
            int numero = Convert.ToInt32(leitor["NUMERO"]);
            string nome = Convert.ToString(leitor["NOME"]);
            int qtdQuestoes = Convert.ToInt32(leitor["QUANTIDADE_QUESTOES"]);
            DateTime dataCriacao = Convert.ToDateTime(leitor["DATA_CRIACAO"]);

            Disciplina d = new();
            d.Numero = Convert.ToInt32(leitor["NUMERODISCIPLINA"]);
            d.Nome = Convert.ToString(leitor["NOMEDISCIPLINA"]);

            Materia m = new();
            m.Numero = Convert.ToInt32(leitor["NUMEROMATERIA"]);
            m.Nome = Convert.ToString(leitor["NOMEMATERIA"]);



            return new Teste
            {
                Numero = numero,
                Nome = nome,
                QtdeQuestoes = qtdQuestoes,
                Data = dataCriacao,

                Disciplina = d,
                Materia = m
            };
        }

        private void ConfigurarParametrosTeste(Teste teste, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", teste.Numero);
            comando.Parameters.AddWithValue("NOME", teste.Nome);
            comando.Parameters.AddWithValue("QUANTIDADE_QUESTOES", teste.QtdeQuestoes);
            comando.Parameters.AddWithValue("DATA_CRIACAO", teste.Data);

            comando.Parameters.AddWithValue("DISCIPLINA_ID", teste.Disciplina.Numero);
            comando.Parameters.AddWithValue("MATERIA_ID", teste.Materia.Numero);
        }
    }
}
