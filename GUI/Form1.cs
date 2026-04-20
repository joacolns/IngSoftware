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
    public partial class Form1 : Form
    {

        public BLL.Usuario BLLusuario = new BLL.Usuario();
        public BE.Usuario BEUsuario;


        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
          
            string user = txtBox_usuario.Text;
            string pass = txtBox_password.Text;

            bool ingresoExitoso = BLLusuario.Login(user, pass);

            if (ingresoExitoso)
            {
                // 1. Instanciamos el nuevo formulario
                Menu_Principal menu = new Menu_Principal();

                // 2. Lo mostramos en pantalla
                menu.Show();

                // 3. Ocultamos la ventana de Login
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

