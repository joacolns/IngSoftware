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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtNuevoUsuario.Text;
            string nuevaClave = txtNuevaPassword.Text; 
            BLL.UsuarioBLL gestorUsuario = new BLL.UsuarioBLL();

            bool registrado = gestorUsuario.RegistrarUsuario(nuevoNombre,nuevaClave);

            if (registrado)
                MessageBox.Show("UsuarioBLL creado y encriptado con éxito");
            else
                MessageBox.Show("Error al registrar");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BLL.UsuarioBLL gestorUsuario = new BLL.UsuarioBLL();
            gestorUsuario.Logout();
            Application.Restart();
        }
    }
}
