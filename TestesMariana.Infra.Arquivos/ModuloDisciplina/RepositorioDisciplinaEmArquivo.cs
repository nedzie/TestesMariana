using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesMariana.Dominio;
using TestesMariana.Infra.Arquivos.Compartilhado;

namespace TestesMariana.Infra.Arquivos.ModuloDisciplina
{
    public class RepositorioDisciplinaEmArquivo : RepositorioEmArquivoBase<Disciplina>
    {
        private DataContext contextoDados;

        public RepositorioDisciplinaEmArquivo(DataContext contextoDados) : base(contextoDados)
        {

        }
    }
}
