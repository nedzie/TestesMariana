using FluentValidation.Results;
using SautinSoft.Document;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TestesMariana.Dominio.ModuloDisciplina;
using TestesMariana.Dominio.ModuloMateria;
using TestesMariana.Dominio.ModuloQuestao;
using TestesMariana.Dominio.ModuloTeste;
using TestesMariana.Infra.BancoDeDados.ModuloQuestao;

namespace TestesMariana.Infra.BancoDeDados.ModuloTeste
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

        private const string sqlEditarTeste =
            @"UPDATE TB_TESTE
                SET
                    NOME = @NOME,
                    QUANTIDADE_QUESTOES = @QUANTIDADE_QUESTOES,
                    DISCIPLINA_ID = @DISCIPLINA_ID,
                    MATERIA_ID = @MATERIA_ID,
                    DATA_CRIACAO = DATA_CRIACAO
                WHERE
                    NUMERO = @ESCOLHA";

        private const string sqlExcluir =
            @"DELETE FROM TB_TESTE
                WHERE
                    NUMERO = @NUMERO";

        private const string sqlExcluirTabelaNN =
            @"DELETE FROM TB_TESTE_QUESTAO
                WHERE
                    TESTE_ID = @NUMERO";

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
	            INNER JOIN TB_DISCIPLINA AS D
	            ON T.DISCIPLINA_ID = D.NUMERO
	            INNER JOIN TB_MATERIA AS M
	            ON T.MATERIA_ID = M.NUMERO";

        private const string sqlSelecionarPorNumero =
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
	            INNER JOIN TB_DISCIPLINA AS D
	            ON T.DISCIPLINA_ID = D.Numero
	            INNER JOIN TB_MATERIA AS M
	            ON T.MATERIA_ID = M.NUMERO
            WHERE
                T.NUMERO = @NUMERO";

        private const string sqlSelecionarAlternativasDaQuestao =
            @"SELECT
                    A.NUMERO AS NUMERO,
	                A.OPCAO AS OPCAO,
	                A.ESTA_CERTA AS CORRETA,
                    Q.NUMERO AS NUMEROQUESTAO
                FROM 
	                TB_QUESTAO AS Q
                INNER JOIN TB_ALTERNATIVA AS A
	                ON A.QUESTAO_ID = Q.NUMERO
                WHERE
                    QUESTAO_ID = @NUMERO";

        private const string sqlIDsQuestoesDoTeste =
            @"SELECT
                    TQ.QUESTAO_ID AS NUMEROQUESTAO
                FROM
                    TB_TESTE_QUESTAO AS TQ
                WHERE
                    TQ.TESTE_ID = @NUMERO";

        private const string sqlSelecionarQuestoesPorNumero =
            @"SELECT
	                Q.NUMERO AS NUMERO,
	                Q.ENUNCIADO AS ENUNCIADO
                FROM
	                TB_QUESTAO AS Q
	                INNER JOIN TB_TESTE_QUESTAO AS TQ
	                ON Q.NUMERO = TQ.QUESTAO_ID
                WHERE
		                TQ.TESTE_ID = @NUMERO";

        private const string sqlSelecionarIdMaximo =
                    @"SELECT MAX(NUMERO) AS ID
                        FROM TB_TESTE";

        private RepositorioQuestaoEmBancoDeDados repositorioQuestao;

        public RepositorioTesteEmBancoDeDados(RepositorioQuestaoEmBancoDeDados repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao;
        }

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

        public ValidationResult Editar(Teste teste)
        {
            var validador = new ValidadorTeste();

            var resultado = validador.Validate(teste);

            if (!resultado.IsValid)
                return resultado;

            SqlConnection conexaoComBanco = new(enderecoBanco);

            SqlCommand comandoEdicao = new(sqlEditarTeste, conexaoComBanco);

            comandoEdicao.Parameters.AddWithValue("ESCOLHA", teste.Numero);

            ConfigurarParametrosTeste(teste, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery(); // Edita aqui
            conexaoComBanco.Close();

            return resultado;
        }

        public ValidationResult Excluir(Teste materiaSelecionada)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusaoTeste = new SqlCommand(sqlExcluir, conexaoComBanco);

            SqlCommand comandoExclusaoNN = new(sqlExcluirTabelaNN, conexaoComBanco);

            comandoExclusaoTeste.Parameters.AddWithValue("NUMERO", materiaSelecionada.Numero);

            comandoExclusaoNN.Parameters.AddWithValue("NUMERO", materiaSelecionada.Numero);

            conexaoComBanco.Open();

            int numeroRegistrosExcluidos = comandoExclusaoTeste.ExecuteNonQuery(); // Exclui aqui

            var resultado = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultado.Errors.Add(new ValidationFailure("", "Não deu pra deletar"));
            else
                comandoExclusaoNN.ExecuteNonQuery();

            conexaoComBanco.Close();

            return resultado;
        }

        public void Duplicar(Teste testeParaDuplicar)
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);

            SqlCommand comandoInsercao = new(sqlInserir, conexaoComBanco); // Aqui cria

            ConfigurarParametrosTeste(testeParaDuplicar, comandoInsercao);

            conexaoComBanco.Open();

            comandoInsercao.ExecuteNonQuery();

            SqlCommand comandoAtualizarID = new(sqlSelecionarIdMaximo, conexaoComBanco);

            var id = comandoAtualizarID.ExecuteScalar();

            testeParaDuplicar.Numero = Convert.ToInt32(id);

            SqlCommand comandoInserirNParaN = new(sqlInserirQuestoesTabelaNN, conexaoComBanco);

            foreach (var questao in testeParaDuplicar.Questoes)
            {
                comandoInserirNParaN.Parameters.Clear();
                ConfigurarRegistroMultivalorado(questao, testeParaDuplicar, comandoInserirNParaN);
                comandoInserirNParaN.ExecuteNonQuery();
            }

        }

        public void PDF(Teste teste2PDF)
        {
            DocumentCore doc = new();

            doc.Content.End.Insert(teste2PDF.Nome + "\n");
            int i = 1;
            int z = 1;
            foreach (var questao in teste2PDF.Questoes)
            {
                doc.Content.End.Insert($"{i}. {questao.Enunciado}\n");
                i++;
                foreach (var alternativa in questao.Alternativas)
                {
                    doc.Content.End.Insert($"{z}. {alternativa.Opcao}\n");
                    z++;
                }
                z = 1;
            }

            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Teste"
                + teste2PDF.Numero.ToString() + ".pdf";

            doc.Save(caminho, new PdfSaveOptions()
            {
                Compliance = PdfCompliance.PDF_A1a,
                PreserveFormFields = true
            });

            string arquivoGerado = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            System.Diagnostics.Process.Start("Explorer", arquivoGerado);
        }

        public void Gabarito(Teste teste2PDF)
        {
            DocumentCore doc = new();

            doc.Content.End.Insert($"{teste2PDF.Nome} - GABARITO\n");
            int i = 1;
            int z = 1;
            foreach (var questao in teste2PDF.Questoes)
            {
                doc.Content.End.Insert($"{i}. {questao.Enunciado}\n");
                i++;
                foreach (var alternativa in questao.Alternativas)
                {
                    if (alternativa.EstaCerta == true)
                        doc.Content.End.Insert($"{z}. {alternativa.Opcao} (CORRETA)\n");
                    else
                        doc.Content.End.Insert($"{z}. {alternativa.Opcao}\n");

                    z++;
                }
                z = 1;
            }

            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Teste"
                + teste2PDF.Numero.ToString() + "GABARITO.pdf";

            doc.Save(caminho, new PdfSaveOptions()
            {
                Compliance = PdfCompliance.PDF_A1a,
                PreserveFormFields = true
            });

            string arquivoGerado = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            System.Diagnostics.Process.Start("Explorer", arquivoGerado);
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


            List<Questao> questoes = AdicionarQuestoes(numero);

            return new Teste
            {
                Numero = numero,
                Nome = nome,
                QtdeQuestoes = qtdQuestoes,
                Data = dataCriacao,

                Disciplina = d,
                Materia = m,
                Questoes = questoes
            };
        }

        private Questao ConverterParaQuestao(SqlDataReader leitor)
        {
            int numero = Convert.ToInt32(leitor["NUMERO"]);
            string enunciado = Convert.ToString(leitor["ENUNCIADO"]);

            List<Alternativa> alternativas = AdicionarAlternativas(numero);

            return new Questao
            {
                Numero = numero,
                Enunciado = enunciado,
                Alternativas = alternativas
            };
        }

        public List<Questao> AdicionarQuestoes(int numero)
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);

            SqlCommand comandoSelecaoQuestoes = new(sqlIDsQuestoesDoTeste, conexaoComBanco);

            comandoSelecaoQuestoes.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();

            SqlDataReader leitor = comandoSelecaoQuestoes.ExecuteReader();

            List<int> idsQuestoes = new();

            int i = 0;
            while (leitor.Read())
            {
                idsQuestoes.Add(leitor.GetInt32(i));
                i++;
            }

            conexaoComBanco.Close();

            conexaoComBanco.Open();

            List<Questao> questoes = new();

            SqlCommand comandoSelecionarQuestoesDoTeste = new(sqlSelecionarQuestoesPorNumero, conexaoComBanco);

            comandoSelecionarQuestoesDoTeste.Parameters.AddWithValue("NUMERO", numero);

            SqlDataReader leitorQuestoes = comandoSelecionarQuestoesDoTeste.ExecuteReader();

            while (leitorQuestoes.Read())
            {
                questoes.Add(ConverterParaQuestao(leitorQuestoes));
            }

            return questoes;
        }

        public List<Alternativa> AdicionarAlternativas(int numero)
        {
            SqlConnection conexaoComBanco = new(enderecoBanco);

            SqlCommand comandoSelecaoAlternativas = new(sqlSelecionarAlternativasDaQuestao, conexaoComBanco);

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

        private void ConfigurarParametrosTeste(Teste teste, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", teste.Numero);
            comando.Parameters.AddWithValue("NOME", teste.Nome);
            comando.Parameters.AddWithValue("QUANTIDADE_QUESTOES", teste.QtdeQuestoes);
            comando.Parameters.AddWithValue("DATA_CRIACAO", teste.Data);

            comando.Parameters.AddWithValue("DISCIPLINA_ID", teste.Disciplina.Numero);
            comando.Parameters.AddWithValue("MATERIA_ID", teste.Materia.Numero);
        }

        private void ConfigurarRegistroMultivalorado(Questao questao, Teste novoTeste, SqlCommand comandoInserirNParaN)
        {
            comandoInserirNParaN.Parameters.AddWithValue("TESTE_ID", novoTeste.Numero);
            comandoInserirNParaN.Parameters.AddWithValue("QUESTAO_ID", questao.Numero);
        }
    }
}
