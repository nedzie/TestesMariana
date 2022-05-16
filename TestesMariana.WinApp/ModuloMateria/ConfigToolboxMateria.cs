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
        public override string toolStripButtonDuplicar { get { return string.Empty; } }
        public override bool statusPDF { get { return false; } }
        public override bool StatusDuplicar { get { return false; } }
    }
}
