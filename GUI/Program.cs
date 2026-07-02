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
            bool integridadValida = bllDV.VerificarIntegridad(out errores);

            Application.Run(new Login(integridadValida, errores));
        }
    }
}
