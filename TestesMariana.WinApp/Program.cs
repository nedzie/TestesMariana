using System;
using System.Windows.Forms;
using TestesMariana.Infra.Arquivos.Compartilhado;
using TestesMariana.Infra.Arquivos.Compartilhado.Serializadores;

namespace TestesMariana.WinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaPrincipalForm());

        }
    }
}
