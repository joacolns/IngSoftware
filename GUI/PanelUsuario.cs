using BE;
using BLL;
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

        public BE.BE_Usuario BEUsuario;
        public BLL.BLL_Bitacora BLLBitacora = new BLL.BLL_Bitacora();

        private void PanelUsuario_Load(object sender, EventArgs e)
        {
            if (BLL.BLL_GestorDeSesion.Instancia.EstaLogeado)
            {

                label1.Text = "Bienvenido, " + BLL.BLL_GestorDeSesion.Instancia.UsuarioActual.Nombre;
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
            var usuarioSeison = BLL_GestorDeSesion.Instancia.UsuarioActual;
            BLLBitacora.RegistrarBitacora(usuarioSeison.ID_Usuario, usuarioSeison.Nombre, "Logout", "El usuario ha cerrado sesión", DateTime.Now);
            gestorUsuario.Logout();
        }

        private void PanelUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarSesion();
        }
    }
}
