using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesMariana.WinApp.Compartilhado;

namespace TestesMariana.WinApp.ModuloDisciplina
{
    public class ConfigToolboxDisciplina : ConfigToolboxBase
    {
        public override string TipoCadastro => "Controle de Disciplinas";

        public override string toolStripButtonInserir { get { return "Inserir uma nova disciplina"; } }

        public override string toolStripButtonEditar { get { return "Editar uma disciplina existente"; } }

        public override string toolStripButtonExcluir { get { return "Excluir uma disciplina existente"; } }
    }
}
