using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesMariana.WinApp.Compartilhado;

namespace TestesMariana.WinApp.ModuloMateria
{
    public class ConfigToolboxMateria : ConfigToolboxBase
    {
        public override string TipoCadastro => "Controle de Matérias";

        public override string toolStripButtonInserir { get { return "Inserir uma nova matéria"; }}

        public override string toolStripButtonEditar { get { return "Editar uma matéria existente"; } }

        public override string toolStripButtonExcluir { get { return "Excluir uma matéria existente"; } }

        public override string? toolStripButtonExportarPDF { get { return string.Empty; } }

        public override bool statusPDF { get { return false; } }
    }
}
