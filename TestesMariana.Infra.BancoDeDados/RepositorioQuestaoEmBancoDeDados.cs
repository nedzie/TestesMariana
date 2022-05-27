using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Dominio.ModuloQuestao;

namespace TestesMariana.Infra.BancoDeDados
{
    public class RepositorioQuestaoEmBancoDeDados
    {
        private const string enderecoBanco =
            "Data Source=MARCOS;Initial Catalog=mariana_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string sqlInserirQuestao =
            @"INSERT INTO [TB_QUESTAO]
                (
                    [ENUNCIADO],
                    [MATERIA_ID],
                    [DISCIPLINA_ID]
                )
                    VALUES
                (
                    @ENUNCIADO,
                    @MATERIA_ID,
                    @DISCIPLINA_ID
                ); SELECT SCOPE_IDENTITY();"; // Configurar parâmetros

        private const string sqlInserirAlternativas =
            @"INSERT INTO TB_ALTERNATIVA
                (
                    OPCAO,
                    ESTA_CERTA,
                    QUESTAO_ID
                )
                    VALUES
                (
                    @OPCAO,
                    @ESTACERTA,
                    @QUESTAO_ID
                ); SELECT SCOPE_IDENTITY();";

        private const string sqlEditarQuestao =
            @"UPDATE TB_QUESTAO
                SET
                    ENUNCIADO = @ENUNCIADO,
                    MATERIA_ID = @MATERIA_ID,
                    DISCIPLINA_ID = @DISCIPLINA_ID
                WHERE
                    NUMERO = @NUMERO";

        private const string sqlEditarAlternativa =
            @"UPDATE TB_ALTERNATIVA
                SET
                    OPCAO = @OPCAO,
                    ESTA_CERTA = @ESTACERTA,
                    QUESTAO_ID = @QUESTAO_ID
                WHERE
                    NUMERO = @NUMERO";

        private const string sqlExcluirQuestao =
            @"DELETE FROM TB_QUESTAO
                WHERE
                    NUMERO = @NUMERO";

        private const string sqlExcluirAlternativas =
            @"DELETE FROM TB_ALTERNATIVA
                WHERE
                    QUESTAO_ID = @NUMERO";

        private const string sqlSelecionarTodos =
            @"SELECT 
	                Q.NUMERO AS NUMERO,
	                Q.ENUNCIADO AS ENUNCIADO,
                    D.NUMERO AS NUMERODISCIPLINA,
	                D.NOME AS NOMEDISCIPLINA,
	                M.NOME AS NOMEMATERIA,
                    M.NUMERO AS NUMEROMATERIA
                FROM
	                TB_QUESTAO AS Q
                INNER JOIN
	                TB_DISCIPLINA AS D
                ON
	                D.NUMERO = Q.DISCIPLINA_ID
                INNER JOIN
	                TB_MATERIA AS M
                ON
	                M.NUMERO = Q.MATERIA_ID";

        private const string sqlSelecionarPorNumero =
            @"SELECT 
	                Q.NUMERO AS NUMERO,
	                Q.ENUNCIADO AS ENUNCIADO,
                    D.NUMERO AS NUMERODISCIPLINA,
	                D.NOME AS NOMEDISCIPLINA,
	                M.NOME AS NOMEMATERIA,
                    M.NUMERO AS NUMEROMATERIA
                FROM
	                TB_QUESTAO AS Q
                INNER JOIN
	                TB_DISCIPLINA AS D
                ON
	                D.NUMERO = Q.DISCIPLINA_ID
                INNER JOIN
	                TB_MATERIA AS M
                ON
	                M.NUMERO = Q.MATERIA_ID
                WHERE
                    Q.NUMERO = @NUMERO";

        private const string sqlSelecionarAlternativasDaQuestao =
            @"SELECT
                    A.NUMERO AS NUMERO,
	                A.OPCAO AS OPCAO,
	                A.ESTA_CERTA AS CORRETA,
                    Q.NUMERO AS NUMEROQUESTAO
                FROM 
	                TB_QUESTAO AS Q
                INNER JOIN TB_ALTERNATIVA AS A
	                ON A.QUESTAO_ID = Q.NUMERO";

        public ValidationResult Inserir(Questao novaQuestao)
        {
            var validador = new ValidadorQuestao();

            var resultado = validador.Validate(novaQuestao);

            if (!resultado.IsValid)
                return resultado;

            SqlConnection conexaoComBanco = new(enderecoBanco);

            SqlCommand comandoInsercaoQuestao = new(sqlInserirQuestao, conexaoComBanco); // Aqui cria

            ConfigurarParametrosQuestao(novaQuestao, comandoInsercaoQuestao);

            conexaoComBanco.Open();

            var idQuestao = comandoInsercaoQuestao.ExecuteScalar(); // Aqui insere a questão
            novaQuestao.Numero = Convert.ToInt32(idQuestao);

            SqlCommand comandoInsercaoAlternativa = new(sqlInserirAlternativas, conexaoComBanco);

            int i = 0;
            foreach (var alternativa in novaQuestao.Alternativas)
            {
                comandoInsercaoAlternativa.Parameters.Clear();
                ConfirugarParametrosAlternativas(alternativa, novaQuestao, comandoInsercaoAlternativa);
                var idAlternativa = comandoInsercaoAlternativa.ExecuteScalar(); // Aqui insere as alternativas
                novaQuestao.Alternativas[i].Numero = Convert.ToInt32(idAlternativa);

                i++;
            }
            conexaoComBanco.Close();

            return resultado;
        }

        public ValidationResult Editar(Questao Questao)
        {
            var validador = new ValidadorQuestao();

            var resultado = validador.Validate(Questao);

            if (!resultado.IsValid)
                return resultado;

            SqlConnection conexaoComBanco = new(enderecoBanco);

            SqlCommand comandoEdicaoQuestao = new(sqlEditarQuestao, conexaoComBanco);

            SqlCommand comandoEdicaoAlternativa = new(sqlEditarAlternativa, conexaoComBanco);

            ConfigurarParametrosQuestao(Questao, comandoEdicaoQuestao);

            conexaoComBanco.Open();

            foreach (var alternativa in Questao.Alternativas)
            {
                comandoEdicaoAlternativa.Parameters.Clear();
                ConfirugarParametrosAlternativas(alternativa, Questao, comandoEdicaoAlternativa);
                comandoEdicaoAlternativa.ExecuteNonQuery();
            }

            comandoEdicaoQuestao.ExecuteNonQuery(); // Edita aqui
            conexaoComBanco.Close();

            return resultado;
        }

        public ValidationResult Excluir(Questao QuestaoSelecionada)
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);

            SqlCommand comandoExclusaoQuestao = new(sqlExcluirQuestao, conexaoComBanco);

            SqlCommand comandoExclusaoAlternativas = new(sqlExcluirAlternativas, conexaoComBanco);

            comandoExclusaoQuestao.Parameters.AddWithValue("NUMERO", QuestaoSelecionada.Numero);

            comandoExclusaoAlternativas.Parameters.AddWithValue("NUMERO", QuestaoSelecionada.Numero);

            conexaoComBanco.Open();

            int numeroRegistrosExcluidos = comandoExclusaoQuestao.ExecuteNonQuery(); // Exclui aqui

            var resultado = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultado.Errors.Add(new ValidationFailure("", "Não deu pra deletar"));
            else
                comandoExclusaoAlternativas.ExecuteNonQuery();

            conexaoComBanco.Close();

            return resultado;
        }

        public List<Questao> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();

            SqlDataReader leitor = comandoSelecao.ExecuteReader(); // Lê aqui

            List<Questao> questoes = new List<Questao>();

            while (leitor.Read())
            {
                Questao questao = ConverterParaQuestao(leitor);
                questoes.Add(questao);
            }

            return questoes;
        }


        public Questao SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();

            SqlDataReader leitor = comandoSelecao.ExecuteReader(); // Lê aqui

            Questao Questao = new();

            if (leitor.Read())
                Questao = ConverterParaQuestao(leitor);

            conexaoComBanco.Close();

            return Questao;
        }

        public List<Alternativa> AdicionarAlternativas(int numero)
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);

            SqlCommand comandoSelecaoAlternativas = new(sqlSelecionarAlternativasDaQuestao,conexaoComBanco);

            comandoSelecaoAlternativas.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();

            SqlDataReader leitor = comandoSelecaoAlternativas.ExecuteReader();

            List<Alternativa> alternativas = new();
            while (leitor.Read())
                alternativas.Add(ConverterParaAlternativas(leitor));

            conexaoComBanco.Close();

            return alternativas;
        }

        private Alternativa ConverterParaAlternativas(SqlDataReader leitor)
        {
            int numero = Convert.ToInt32(leitor["NUMERO"]);
            string opcao = Convert.ToString(leitor["OPCAO"]);
            bool estaCerta = Convert.ToBoolean(leitor["CORRETA"]);

            int numeroQuestao = Convert.ToInt32(leitor["NUMEROQUESTAO"]);

            return new Alternativa
            {
                Numero = numero,
                Opcao = opcao,
                EstaCerta = estaCerta,
                Questao = new Questao
                {
                    Numero = numeroQuestao,
                }
            };
        }

        private Questao ConverterParaQuestao(SqlDataReader leitor)
        {
            int numero = Convert.ToInt32(leitor["NUMERO"]); // Isso vem da área 'Select...' dos comando SQL Sel. Todos/Por número
            string enunciado = Convert.ToString(leitor["ENUNCIADO"]);

            Disciplina d = new();
            d.Numero = Convert.ToInt32(leitor["NUMERODISCIPLINA"]);
            d.Nome = Convert.ToString(leitor["NOMEDISCIPLINA"]);

            Materia m = new();
            m.Numero = Convert.ToInt32(leitor["NUMEROMATERIA"]);
            m.Nome = Convert.ToString(leitor["NOMEMATERIA"]);

            List<Alternativa> alternativas = AdicionarAlternativas(numero);

            return new Questao
            {
                Numero = numero,
                Enunciado = enunciado,
                Disciplina = d,
                Materia = m,
                Alternativas = alternativas
            };
        }

        private void ConfigurarParametrosQuestao(Questao questao, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", questao.Numero);
            comando.Parameters.AddWithValue("ENUNCIADO", questao.Enunciado);
            comando.Parameters.AddWithValue("DISCIPLINA_ID", questao.Disciplina.Numero);
            comando.Parameters.AddWithValue("MATERIA_ID", questao.Materia.Numero);
        }

        private void ConfirugarParametrosAlternativas(Alternativa alternativa, Questao questao, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", alternativa.Numero);
            comando.Parameters.AddWithValue("OPCAO", alternativa.Opcao);
            comando.Parameters.AddWithValue("ESTACERTA", alternativa.EstaCerta);
            comando.Parameters.AddWithValue("QUESTAO_ID", questao.Numero);
        }
    }
}
