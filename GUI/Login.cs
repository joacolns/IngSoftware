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
    public partial class Login : Form, Servicio.IObserver
    {

        public BLL.BLL_Usuario BLLusuario = new BLL.BLL_Usuario();
        public BE.BE_Usuario BEUsuario;
        public BLL.BLL_Bitacora BLLBitacora = new BLL.BLL_Bitacora();
        public BLL.BLL_DigitoVerificador BLLDigitoVerificador =  new BLL.BLL_DigitoVerificador();
        public BE.BE_DigitoVerificador BEDigitoVerificador;

        int intentosFallidos = 0;

        public Login()
        {
            InitializeComponent();
            BLL_Multilenguaje.Instancia.Registrar(this);
            this.FormClosed += Login_FormClosed;
            CargarIdiomas();
            ActualizarLenguaje();
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
            BLL_Permiso bllPermiso = new BLL_Permiso();
            if (bllPermiso.TienePermiso(BEUsuario, "Gestionar Permisos"))
            {
                PanelAdmin panel_admin = new PanelAdmin();
                panel_admin.Show();
                this.Hide();
            }
            else
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
                btnLogin.Enabled = false;
                await Task.Delay(5000);
                btnLogin.Enabled = true;
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
                    BE_Componente h1 = new BE_Componente { Nombre = "Ver Bitacora", Tipo = "Hoja" };
                    BE_Componente h2 = new BE_Componente { Nombre = "Limpiar Bitacora", Tipo = "Hoja" };
                    BE_Componente h3 = new BE_Componente { Nombre = "Registrar Usuario", Tipo = "Hoja" };
                    BE_Componente h4 = new BE_Componente { Nombre = "Gestionar Permisos", Tipo = "Hoja" };

                    bllPermiso.GuardarComponente(h1);
                    bllPermiso.GuardarComponente(h2);
                    bllPermiso.GuardarComponente(h3);
                    bllPermiso.GuardarComponente(h4);

                    // Create composites
                    BE_Componente rAdmin = new BE_Componente { Nombre = "Rol Admin", Tipo = "Composite" };
                    BE_Componente rUser = new BE_Componente { Nombre = "Rol Usuario", Tipo = "Composite" };

                    bllPermiso.GuardarComponente(rAdmin);
                    bllPermiso.GuardarComponente(rUser);

                    // Add children
                    rAdmin.Hijos.Add(h1);
                    rAdmin.Hijos.Add(h2);
                    rAdmin.Hijos.Add(h3);
                    rAdmin.Hijos.Add(h4);

                    rUser.Hijos.Add(h1);

                    // Save relationships
                    bllPermiso.GuardarComponente(rAdmin);
                    bllPermiso.GuardarComponente(rUser);
                }

                // Seed Admin User if not exists
                var usuarios = BLLusuario.ObtenerUsuarios();
                if (!usuarios.Any(u => u.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase)))
                {
                    BLLusuario.RegistrarUsuario("admin", "123");

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
            //CrearAdminConPermisos();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            BLL_Multilenguaje.Instancia.Desregistrar(this);
        }

        private void CargarIdiomas()
        {
            try
            {
                List<BE_Idioma> idiomas = BLL_Multilenguaje.Instancia.ObtenerIdiomas();
                List<BE_Idioma> idiomasActivos = new List<BE_Idioma>();
                foreach (var idm in idiomas)
                {
                    if (idm.Agregado)
                    {
                        idiomasActivos.Add(idm);
                    }
                }

                comboBoxIdiomaLogin.SelectedIndexChanged -= comboBoxIdiomaLogin_SelectedIndexChanged;

                comboBoxIdiomaLogin.DataSource = null;
                comboBoxIdiomaLogin.DataSource = idiomasActivos;
                comboBoxIdiomaLogin.DisplayMember = "Nombre";

                var actual = BLL_Multilenguaje.Instancia.IdiomaActual;
                if (actual != null)
                {
                    foreach (var idm in idiomasActivos)
                    {
                        if (idm.ID_Idioma == actual.ID_Idioma)
                        {
                            comboBoxIdiomaLogin.SelectedItem = idm;
                            break;
                        }
                    }
                }

                comboBoxIdiomaLogin.SelectedIndexChanged += comboBoxIdiomaLogin_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar idiomas: " + ex.Message);
            }
        }

        private void comboBoxIdiomaLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedIdioma = comboBoxIdiomaLogin.SelectedItem as BE_Idioma;
                if (selectedIdioma != null)
                {
                    BLL_Multilenguaje.Instancia.IdiomaActual = selectedIdioma;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar de idioma: " + ex.Message);
            }
        }

        public void ActualizarLenguaje()
        {
            labelUsuario.Text = BLL_Multilenguaje.Instancia.Traducir("labelUsuario", "Login");
            labelPassword.Text = BLL_Multilenguaje.Instancia.Traducir("labelPassword", "Login");
            btnLogin.Text = BLL_Multilenguaje.Instancia.Traducir("btnLogin", "Login");
            this.Text = BLL_Multilenguaje.Instancia.Traducir("Login", "Login");

            string tLabelIdioma = BLL_Multilenguaje.Instancia.Traducir("labelIdiomaLogin", "Login");
            labelIdiomaLogin.Text = tLabelIdioma.StartsWith("[Default:") ? "Idioma" : tLabelIdioma;

            // Asegurarse de que el ComboBox muestre el idioma actual si cambió externamente
            var actual = BLL_Multilenguaje.Instancia.IdiomaActual;
            if (actual != null && comboBoxIdiomaLogin.SelectedItem != null)
            {
                var selected = comboBoxIdiomaLogin.SelectedItem as BE_Idioma;
                if (selected != null && selected.ID_Idioma != actual.ID_Idioma)
                {
                    comboBoxIdiomaLogin.SelectedIndexChanged -= comboBoxIdiomaLogin_SelectedIndexChanged;
                    foreach (BE_Idioma item in comboBoxIdiomaLogin.Items)
                    {
                        if (item.ID_Idioma == actual.ID_Idioma)
                        {
                            comboBoxIdiomaLogin.SelectedItem = item;
                            break;
                        }
                    }
                    comboBoxIdiomaLogin.SelectedIndexChanged += comboBoxIdiomaLogin_SelectedIndexChanged;
                }
            }
        }
    }
}
