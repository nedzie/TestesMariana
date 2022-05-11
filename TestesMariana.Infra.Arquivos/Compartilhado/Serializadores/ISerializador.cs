namespace TestesMariana.Infra.Arquivos.Compartilhado.Serializadores
{
    public interface ISerializador
    {
        DataContext CarregarDadosDoArquivo();
        void GravarDadosEmArquivo(DataContext dados);
    }
}
