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
    public partial class Menu_Principal : Form
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

       


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelUSER_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Principal_Load_1(object sender, EventArgs e)
        {

            if (BLL.GestorDeSesiones.Instancia.EstaLogeado)
            {

                labelUSER.Text = BLL.GestorDeSesiones.Instancia.UsuarioActual.Nombre;


            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
