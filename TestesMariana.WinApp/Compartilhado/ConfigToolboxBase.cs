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

        public abstract string toolStripButtonExportarGabarito { get; }

        // Botões
        public virtual bool StatusInserir { get { return true; } }
        public virtual bool StatusEditar { get { return true; } }
        public virtual bool StatusExcluir {  get { return true; } }
        public virtual bool statusPDF { get { return false; } }
        public virtual bool StatusGabarito { get { return false; } }
        public abstract bool StatusDuplicar { get; }
    }
}
