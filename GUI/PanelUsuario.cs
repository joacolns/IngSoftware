using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class PanelUsuario : Form
    {
        public PanelUsuario()
        {
            InitializeComponent();
        }

        private void PanelUsuario_Load(object sender, EventArgs e)
        {
            if (BLL.BLL_GestorDeSesiones.Instancia.EstaLogeado)
            {

                label1.Text = "Bienvenido, " + BLL.BLL_GestorDeSesiones.Instancia.UsuarioActual.Nombre;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CerrarSesion();
            Application.Restart();
        }

        private void CerrarSesion()
        {
            BLL.BLL_Usuario gestorUsuario = new BLL.BLL_Usuario();
            gestorUsuario.Logout();
        }
    }
}
