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

            // 3. Le pasamos el trabajo a la BLL y esperamos la respuesta booleana
            bool ingresoExitoso = BLLusuario.Login(user, pass);

            // 4. Evaluamos el resultado
            if (ingresoExitoso)
            {
                // ¡LA MAGIA DEL SINGLETON!
                // Como el login fue exitoso, la BLL ya guardó al usuario en el Singleton.
                // Aquí lo llamamos desde la UI para comprobar que funciona en toda la app:
                string nombreLogeado = BLL.GestorDeSesiones.Instancia.UsuarioActual.Nombre;

                MessageBox.Show($"¡Login exitoso! Bienvenido al sistema, {nombreLogeado}.");

                // --- Aquí iría la navegación real ---
                // FormMenuPrincipal menu = new FormMenuPrincipal();
                // menu.Show();
                // this.Hide(); // Ocultamos el login
            }
            else
            {
                // Si la BLL devolvió false, es porque la base de datos no encontró al usuario
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
