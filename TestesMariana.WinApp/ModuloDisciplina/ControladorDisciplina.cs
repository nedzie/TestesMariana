using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesMariana.Infra.Arquivos.ModuloDisciplina;
using TestesMariana.WinApp.Compartilhado;

namespace TestesMariana.WinApp.ModuloDisciplina
{
    internal class ControladorDisciplina : ControladorBase
    {
        private RepositorioDisciplinaEmArquivo _repositorioDisciplina;
        public ControladorDisciplina(RepositorioDisciplinaEmArquivo repositorioDisciplina)
        {
            this._repositorioDisciplina = repositorioDisciplina;
        }
        public override void Inserir()
        {
            throw new NotImplementedException();
        }
        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override ConfigToolboxBase ObtemConfiguracaoToolbox()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObtemListagem()
        {
            throw new NotImplementedException();
        }
    }
}
