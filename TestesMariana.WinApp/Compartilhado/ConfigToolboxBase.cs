namespace TestesMariana.WinApp.Compartilhado
{
    public abstract class ConfigToolboxBase
    {
        public abstract string TipoCadastro { get; }

        public abstract string toolStripButtonInserir { get; }

        public abstract string toolStripButtonEditar { get; }

        public abstract string toolStripButtonExcluir { get; }

        public virtual string? toolStripButtonExportarPDF { get; }



        public virtual bool StatusInserir { get { return true; } }
        public virtual bool StatusEditar { get { return true; } }
        public virtual bool StatusExcluir {  get { return true; } }
    }
}
