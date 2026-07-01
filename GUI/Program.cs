using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BLL.BLL_DigitoVerificador bllDV = new BLL.BLL_DigitoVerificador();
            System.Collections.Generic.List<string> errores;
            if (!bllDV.VerificarIntegridad(out errores))
            {
                MessageBox.Show("Error de integridad de datos. La aplicación se cerrará.\n" + string.Join("\n", errores), "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
                return;
            }

            Application.Run(new Login());
        }
    }
}
