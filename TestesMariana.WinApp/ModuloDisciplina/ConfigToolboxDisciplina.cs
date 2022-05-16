using TestesMariana.WinApp.Compartilhado;

namespace TestesMariana.WinApp.ModuloDisciplina
{
    public class ConfigToolboxDisciplina : ConfigToolboxBase
    {
        public override string TipoCadastro => "Controle de Disciplinas";
        public override string toolStripButtonInserir { get { return "Inserir uma nova disciplina"; } }
        public override string toolStripButtonEditar { get { return "Editar uma disciplina existente"; } }
        public override string toolStripButtonExcluir { get { return "Excluir uma disciplina existente"; } }
        public override string toolStripButtonExportarPDF { get { return string.Empty; } }
        public override string toolStripButtonDuplicar { get { return string.Empty; } }
        public override bool statusPDF { get { return false; } }
        public override bool StatusDuplicar { get { return false; } }
    }
}
