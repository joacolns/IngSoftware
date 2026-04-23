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

        public BLL.UsuarioBLL BLLusuario = new BLL.UsuarioBLL();
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
               
                Menu_Principal menu = new Menu_Principal();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("UsuarioBLL o contraseña incorrectos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        /*    BLL.UsuarioBLL gestorUsuario = new BLL.UsuarioBLL();

             gestorUsuario.RegistrarUsuario("admin", "1234567");*/
        }
    }
    }

