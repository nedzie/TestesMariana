﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private const string sqlEditar =
            @"";

        private const string sqlExcluir =
            @"";

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

            SqlCommand comandoEdicao = new(sqlEditar, conexaoComBanco);

            ConfigurarParametrosQuestao(Questao, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery(); // Edita aqui
            conexaoComBanco.Close();

            return resultado;
        }

        public ValidationResult Excluir(Questao QuestaoSelecionada)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", QuestaoSelecionada.Numero);

            conexaoComBanco.Open();

            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery(); // Exclui aqui

            var resultado = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultado.Errors.Add(new ValidationFailure("", "Não deu pra deletar"));

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

            return new Questao
            {
                Numero = numero,
                Enunciado = enunciado,
                Disciplina = d,
                Materia = m
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