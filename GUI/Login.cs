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
    public partial class Login : Form
    {

        public BLL.BLL_Usuario BLLusuario = new BLL.BLL_Usuario();
        public BE.BE_Usuario BEUsuario;
        public BLL.BLL_Bitacora BLLBitacora = new BLL.BLL_Bitacora();

        int intentosFallidos = 0;

        public Login()
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

                VerificarRol();
            }
            else
            {
                intentosFallidos++;
                GestionarBloqueo();
                // Usamos 0 como ID genérico y el string 'user' del textbox porque no hay BEUsuario válido logueado
                //BLLBitacora.RegistrarBitacora(0, user, "Login", "El usuario ha intentdo iniciar sesion", DateTime.Now);

            }
        }

        private void VerificarRol()
        {
            if(BEUsuario.Role == "admin")
            {
                PanelAdmin panel_admin = new PanelAdmin();
                panel_admin.Show();
                this.Hide();
            }
            else if(BEUsuario.Role == "usuario")
            {
                PanelUsuario panel_usuario = new PanelUsuario();
                panel_usuario.Show();
                this.Hide();
            }
            
        }

        private async Task GestionarBloqueo()
        {
            if (intentosFallidos >= 3)
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Usuario Bloqueado por 5 segundos", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Login.Enabled = false;
                await Task.Delay(5000);
                btn_Login.Enabled = true;

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            BLL.BLL_Usuario gestorUsuario = new BLL.BLL_Usuario();

            gestorUsuario.RegistrarUsuario("admin", "1234567", "admin");
            */
        }
    }
    }

