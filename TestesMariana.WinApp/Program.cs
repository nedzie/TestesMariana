using System;
using System.Windows.Forms;
using TestesMariana.Infra.Arquivos.Compartilhado;
using TestesMariana.Infra.Arquivos.Compartilhado.Serializadores;

namespace TestesMariana.WinApp
{
    internal static class Program
    {
        static ISerializador serializador = new SerializadorJson();

        static DataContext contexto;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            contexto = new DataContext(serializador);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaPrincipalForm(contexto));

            contexto.GravarDados();
        }
    }
}
