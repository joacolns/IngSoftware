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
    public partial class Form1 : Form
    {

        public BLL.BLL_Usuario BLLusuario = new BLL.BLL_Usuario();
        public BE.Usuario BEUsuario;
        public BLL.BLL_Bitacora BLLBitacora = new BLL.BLL_Bitacora();

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
                BEUsuario = BLL_GestorDeSesiones.Instancia.UsuarioActual;

                BLLBitacora.RegistrarBitacora(BEUsuario.ID_Usuario, BEUsuario.Nombre, "Login", "El usuario ha inicado sesion", DateTime.Now);

                Menu_Principal menu = new Menu_Principal();
                menu.Show();
                this.Hide();
               
            }
            else
            {
                MessageBox.Show("UsuarioBLL o contraseña incorrectos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Usamos 0 como ID genérico y el string 'user' del textbox porque no hay BEUsuario válido logueado
                //BLLBitacora.RegistrarBitacora(0, user, "Login", "El usuario ha intentdo iniciar sesion", DateTime.Now);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*BLL.BLL_Usuario gestorUsuario = new BLL.BLL_Usuario();

             gestorUsuario.RegistrarUsuario("admin", "1234567");
            */
        }
    }
    }

