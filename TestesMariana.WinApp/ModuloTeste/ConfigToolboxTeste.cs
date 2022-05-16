using TestesMariana.WinApp.Compartilhado;

namespace TestesMariana.WinApp.ModuloTeste
{
    public class ConfigToolboxTeste : ConfigToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Testes";
        public override string toolStripButtonInserir { get { return "Inserir um novo teste"; } }
        public override string toolStripButtonEditar { get { return "Editar um teste existente"; } }
        public override string toolStripButtonExcluir { get { return "Excluir um teste existente"; } }
        public override string? toolStripButtonExportarPDF { get { return "Exportar um teste para PDF"; } }
        public override string toolStripButtonDuplicar { get { return "Duplicar um teste existente"; } }
        public override bool statusPDF { get { return true; } }
        public override bool StatusDuplicar { get { return true; } }
    }
}
