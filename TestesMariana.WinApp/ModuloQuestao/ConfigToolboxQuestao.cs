using TestesMariana.WinApp.Compartilhado;

namespace TestesMariana.WinApp.ModuloQuestao
{
    public class ConfigToolboxQuestao : ConfigToolboxBase
    {
        public override string TipoCadastro => "Controle de Questões";
        public override string toolStripButtonInserir { get { return "Inserir uma nova questão"; } }
        public override string toolStripButtonEditar { get { return "Editar uma questão existente"; } }
        public override string toolStripButtonExcluir { get { return "Excluir uma questão existente"; } }
        public override string? toolStripButtonExportarPDF { get { return string.Empty; } }
        public override string toolStripButtonDuplicar { get { return string.Empty; } }
        public override bool statusPDF { get { return false; } }
        public override bool StatusDuplicar { get { return false; } }
    }
}
