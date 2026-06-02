using BLL;
using BE;
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
                BEUsuario = BLL_GestorDeSesion.Instancia.UsuarioActual;

                BLLBitacora.RegistrarBitacora(BEUsuario.ID_Usuario, BEUsuario.Nombre, "Login", "El usuario ha inicado sesion", DateTime.Now);

                VerificarRol();
            }
            else
            {
                intentosFallidos++;
                GestionarBloqueo();


            }
        }

        private void VerificarRol()
        {
            if (BEUsuario.Role == "admin")
            {
                PanelAdmin panel_admin = new PanelAdmin();
                panel_admin.Show();
                this.Hide();
            }
            else if (BEUsuario.Role == "usuario")
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
                intentosFallidos = 0;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearAdminConPermisos()
        {
            try
            {
                BLL_Permiso bllPermiso = new BLL_Permiso();
                var todos = bllPermiso.ObtenerTodos();

                if (todos.Count == 0)
                {
                    // Create leaves
                    BE_Hoja h1 = new BE_Hoja { Nombre = "Ver Bitacora" };
                    BE_Hoja h2 = new BE_Hoja { Nombre = "Limpiar Bitacora" };
                    BE_Hoja h3 = new BE_Hoja { Nombre = "Registrar Usuario" };
                    BE_Hoja h4 = new BE_Hoja { Nombre = "Gestionar Permisos" };

                    bllPermiso.GuardarComponente(h1);
                    bllPermiso.GuardarComponente(h2);
                    bllPermiso.GuardarComponente(h3);
                    bllPermiso.GuardarComponente(h4);

                    // Create composites
                    BE_Composite rAdmin = new BE_Composite { Nombre = "Rol Admin" };
                    BE_Composite rUser = new BE_Composite { Nombre = "Rol Usuario" };

                    bllPermiso.GuardarComponente(rAdmin);
                    bllPermiso.GuardarComponente(rUser);

                    // Add children
                    rAdmin.Agregar(h1);
                    rAdmin.Agregar(h2);
                    rAdmin.Agregar(h3);
                    rAdmin.Agregar(h4);

                    rUser.Agregar(h1);

                    // Save relationships
                    bllPermiso.GuardarComponente(rAdmin);
                    bllPermiso.GuardarComponente(rUser);
                }

                // Seed Admin User if not exists
                var usuarios = BLLusuario.ObtenerUsuarios();
                if (!usuarios.Any(u => u.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase)))
                {
                    BLLusuario.RegistrarUsuario("admin", "123", "admin");

                    usuarios = BLLusuario.ObtenerUsuarios();
                    var adminUser = usuarios.FirstOrDefault(u => u.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase));

                    if (adminUser != null)
                    {
                        var allPerms = bllPermiso.ObtenerTodos();
                        var rolAdmin = allPerms.FirstOrDefault(p => p.Nombre == "Rol Admin");
                        if (rolAdmin != null)
                        {
                            bllPermiso.GuardarPermisosUsuario(adminUser, new List<BE_Componente> { rolAdmin });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar base de datos de seguridad: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CrearAdminConPermisos();
        }
    }
}
