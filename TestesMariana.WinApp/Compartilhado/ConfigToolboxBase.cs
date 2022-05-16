namespace TestesMariana.WinApp.Compartilhado
{
    public abstract class ConfigToolboxBase
    {
        public abstract string TipoCadastro { get; }

        public abstract string toolStripButtonInserir { get; }

        public abstract string toolStripButtonEditar { get; }

        public abstract string toolStripButtonExcluir { get; }

        public abstract string? toolStripButtonExportarPDF { get; }

        public abstract string toolStripButtonDuplicar { get; }

        // Botões
        public virtual bool StatusInserir { get { return true; } }
        public virtual bool StatusEditar { get { return true; } }
        public virtual bool StatusExcluir {  get { return true; } }
        public abstract bool statusPDF { get; }

        public abstract bool StatusDuplicar { get; }
    }
}
