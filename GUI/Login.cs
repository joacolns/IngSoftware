using BLL;
using BE;
using Servicio;
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
        public BLL.BLL_DigitoVerificador BLLDigitoVerificador =  new BLL.BLL_DigitoVerificador();
        public BE.BE_DigitoVerificador BEDigitoVerificador;

        int intentosFallidos = 0;
        private bool _integridadValida = true;
        private List<string> _erroresIntegridad = new List<string>();

        public Login()
        {
            InitializeComponent();
            BLL.BLL_DigitoVerificador bllDV = new BLL.BLL_DigitoVerificador();
            this._integridadValida = bllDV.VerificarIntegridad(out this._erroresIntegridad);
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

                if (!_integridadValida)
                {
                    BLL.BLL_Permiso bllPermiso = new BLL.BLL_Permiso();
                    bool esAdmin = bllPermiso.TienePermiso(BEUsuario, "Rol Admin");
                    
                    if (!esAdmin)
                    {
                        MessageBox.Show("Falla de integridad en la base de datos. El acceso a usuarios comunes ha sido bloqueado. Contacte al administrador.", "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                BLLBitacora.RegistrarBitacora(BEUsuario.ID_Usuario, BEUsuario.Nombre, "Login", "El usuario ha inicado sesion", DateTime.Now);

                PanelAdmin panel_admin = new PanelAdmin(_integridadValida, _erroresIntegridad);
                panel_admin.Show();
                this.Hide();
            }
            else
            {
                intentosFallidos++;
                GestionarBloqueo();


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
            //Llamar solamente si no existe un admin en la bd
            try
            {
                BLL_Permiso bllPermiso = new BLL_Permiso();
                var todos = bllPermiso.ObtenerTodos();

                if (todos.Count == 0)
                {
                    // Crear permisos simples (hojas)
                    S_Componente h1 = new S_Hoja { Nombre = "Ver Bitacora" };
                    S_Componente h2 = new S_Hoja { Nombre = "Limpiar Bitacora" };
                    S_Componente h3 = new S_Hoja { Nombre = "Registrar Usuario" };
                    S_Componente h4 = new S_Hoja { Nombre = "Gestionar Permisos" };

                    bllPermiso.GuardarComponente(h1);
                    bllPermiso.GuardarComponente(h2);
                    bllPermiso.GuardarComponente(h3);
                    bllPermiso.GuardarComponente(h4);

                    // Crear roles compuestos
                    S_Componente rAdmin = new S_Composite { Nombre = "Rol Admin" };
                    S_Componente rUser = new S_Composite { Nombre = "Rol Usuario" };

                    bllPermiso.GuardarComponente(rAdmin);
                    bllPermiso.GuardarComponente(rUser);

                    // Agregar hijos
                    rAdmin.Hijos.Add(h1);
                    rAdmin.Hijos.Add(h2);
                    rAdmin.Hijos.Add(h3);
                    rAdmin.Hijos.Add(h4);

                    rUser.Hijos.Add(h1);

                    // Guardar relaciones
                    bllPermiso.GuardarComponente(rAdmin);
                    bllPermiso.GuardarComponente(rUser);
                }

                // Crear el usuario administrador semilla si no existe
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
                            bllPermiso.GuardarPermisosUsuario(adminUser, new List<S_Componente> { rolAdmin });
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
                    ActualizarLenguaje();
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
