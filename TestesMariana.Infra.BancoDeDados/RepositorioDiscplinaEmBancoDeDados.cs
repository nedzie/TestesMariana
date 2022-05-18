using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesMariana.Dominio.ModuloDisciplina;

namespace TestesMariana.Infra.BancoDeDados
{
    public class RepositorioDiscplinaEmBancoDeDados
    {
        private const string enderecoBanco =
            "Data Source=MARCOS;Initial Catalog=mariana_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string sqlInserir =
            @"INSERT INTO [tb_disciplina]
                (
                    [NOME]
                )
                    VALUES
                (
                    @NOME
                ); SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [tb_disciplina]
                SET
                    [NOME] = @NOME
                WHERE 
                    [NUMERO] = @NUMERO";

        private const string sqlExcluir =
            @"DELETE FROM [tb_disciplina
                WHERE
                    [NUMERO] = @NUMERO";

        private const string sqlSelecionarTodos =
            @"SELECT [NUMERO], [NOME] FROM [tb_disciplina]";

        private const string sqlSelecionarPorNumero =
            @"SELECT [NUMERO], [NOME] FROM [tb_disciplina]
                WHERE
                    [NUMERO] = @NUMERO";


        public ValidationResult Inserir(Disciplina novaDisciplina)
        {
            var validador = new ValidadorDisciplina();

            var resultado = validador.Validate(novaDisciplina);

            if (!resultado.IsValid)
                return resultado;


            SqlConnection conexaoComBanco = new(enderecoBanco);

            SqlCommand comandoInsercao = new(sqlInserir, conexaoComBanco); // Aqui cria

            ConfigurarParametrosDisciplina(novaDisciplina, comandoInsercao);

            conexaoComBanco.Open();

            var id = comandoInsercao.ExecuteScalar(); // Aqui insere

            novaDisciplina.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultado;
        }

        public ValidationResult Editar(Disciplina disciplina)
        {
            var validador = new ValidadorDisciplina();

            var resultado = validador.Validate(disciplina);

            if (!resultado.IsValid)
                return resultado;

            SqlConnection conexaoComBanco = new(enderecoBanco);

            SqlCommand comandoEdicao = new(sqlEditar, conexaoComBanco);

            ConfigurarParametrosDisciplina(disciplina, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery(); // Edita aqui
            conexaoComBanco.Close();

            return resultado;
        }

        public ValidationResult Excluir(Disciplina disciplinaSelecionada)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", disciplinaSelecionada.Numero);

            conexaoComBanco.Open();

            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery(); // Exclui aqui

            var resultado = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultado.Errors.Add(new ValidationFailure("", "Não deu pra deletas"));

            conexaoComBanco.Close();

            return resultado;
        }

        public List<Disciplina> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();

            SqlDataReader leitor = comandoSelecao.ExecuteReader(); // Lê aqui

            List<Disciplina> disciplinas = new List<Disciplina>();

            while(leitor.Read())
            {
                Disciplina disciplina = ConverterParaDisciplina(leitor);
                disciplinas.Add(disciplina);
            }

            return disciplinas;
        }


        public Disciplina SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();

            SqlDataReader leitor = comandoSelecao.ExecuteReader(); // Lê aqui

            Disciplina disciplina = new();

            if(leitor.Read())
                disciplina = ConverterParaDisciplina(leitor);

            conexaoComBanco.Close();

            return disciplina;
        }
        private Disciplina ConverterParaDisciplina(SqlDataReader leitor)
        {
            int numero = Convert.ToInt32(leitor["NUMERO"]);
            string nome = Convert.ToString(leitor["NOME"]);

            return new Disciplina
            {
                Numero = numero,
                Nome = nome
            };
        }

        private void ConfigurarParametrosDisciplina(Disciplina disciplina, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", disciplina.Numero);
            comando.Parameters.AddWithValue("NOME", disciplina.Nome);
        }
    }
}
