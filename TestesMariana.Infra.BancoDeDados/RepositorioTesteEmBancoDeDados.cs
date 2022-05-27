using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesMariana.Infra.BancoDeDados
{
    public class RepositorioTesteEmBancoDeDados
    {
        //public ValidationResult Inserir(Materia novaMateria)
        //{
        //    var validador = new ValidadorMateria();

        //    var resultado = validador.Validate(novaMateria);

        //    if (!resultado.IsValid)
        //        return resultado;


        //    SqlConnection conexaoComBanco = new(enderecoBanco);

        //    SqlCommand comandoInsercao = new(sqlInserir, conexaoComBanco); // Aqui cria

        //    ConfigurarParametrosMateria(novaMateria, comandoInsercao);

        //    conexaoComBanco.Open();

        //    var id = comandoInsercao.ExecuteScalar(); // Aqui insere

        //    novaMateria.Numero = Convert.ToInt32(id);

        //    conexaoComBanco.Close();

        //    return resultado;
        //}

        //public ValidationResult Editar(Materia materia)
        //{
        //    var validador = new ValidadorMateria();

        //    var resultado = validador.Validate(materia);

        //    if (!resultado.IsValid)
        //        return resultado;

        //    SqlConnection conexaoComBanco = new(enderecoBanco);

        //    SqlCommand comandoEdicao = new(sqlEditar, conexaoComBanco);

        //    ConfigurarParametrosMateria(materia, comandoEdicao);

        //    conexaoComBanco.Open();
        //    comandoEdicao.ExecuteNonQuery(); // Edita aqui
        //    conexaoComBanco.Close();

        //    return resultado;
        //}

        //public ValidationResult Excluir(Materia materiaSelecionada)
        //{
        //    SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

        //    SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

        //    comandoExclusao.Parameters.AddWithValue("NUMERO", materiaSelecionada.Numero);

        //    conexaoComBanco.Open();

        //    int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery(); // Exclui aqui

        //    var resultado = new ValidationResult();

        //    if (numeroRegistrosExcluidos == 0)
        //        resultado.Errors.Add(new ValidationFailure("", "Não deu pra deletar"));

        //    conexaoComBanco.Close();

        //    return resultado;
        //}

        //public List<Materia> SelecionarTodos()
        //{
        //    SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

        //    SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

        //    conexaoComBanco.Open();

        //    SqlDataReader leitor = comandoSelecao.ExecuteReader(); // Lê aqui

        //    List<Materia> materias = new List<Materia>();

        //    while (leitor.Read())
        //    {
        //        Materia materia = ConverterParaDisciplina(leitor);
        //        materias.Add(materia);
        //    }

        //    return materias;
        //}


        //public Materia SelecionarPorNumero(int numero)
        //{
        //    SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

        //    SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

        //    comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

        //    conexaoComBanco.Open();

        //    SqlDataReader leitor = comandoSelecao.ExecuteReader(); // Lê aqui

        //    Materia materia = new();

        //    if (leitor.Read())
        //        materia = ConverterParaDisciplina(leitor);

        //    conexaoComBanco.Close();

        //    return materia;
        //}
    }
}
