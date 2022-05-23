using System.Windows.Forms;

namespace TestesMariana.WinApp.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract void Inserir();
        public abstract void Editar();
        public abstract void Excluir();
        public abstract UserControl ObtemListagem();
        public abstract ConfigToolboxBase ObtemConfiguracaoToolbox();
    }
}
