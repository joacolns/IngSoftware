using BE;
using Servicio;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class PanelAdmin : Form
    {

        public BLL.BLL_Bitacora BLLBitacora = new BLL.BLL_Bitacora();
        public BLL.BLL_Usuario BLLusuario = new BLL.BLL_Usuario();
        public BE.BE_Usuario BEUsuario;
        private BLL.BLL_Permiso bllPermiso = new BLL.BLL_Permiso();

        private bool _integridadValida = true;
        private List<string> _erroresIntegridad = new List<string>();

        // Referencias a los formularios hijos abiertos
        private FormUsuarios _formUsuarios;
        private FormBitacora _formBitacora;
        private FormControlCambios _formControlCambios;
        private FormIdiomas _formIdiomas;

        public PanelAdmin() : this(true, new List<string>())
        {
        }

        public PanelAdmin(bool integridadValida, List<string> errores)
        {
            InitializeComponent();
            this._integridadValida = integridadValida;
            this._erroresIntegridad = errores;
        }

        private void Menu_Principal_Load_1(object sender, EventArgs e)
        {
            if (BLL.BLL_GestorDeSesion.Instancia.EstaLogeado)
            {
                labelUSER.Text = BLL.BLL_GestorDeSesion.Instancia.UsuarioActual.Nombre;
            }

            InicializarPermisosYAdministrador();

            if (BLL_GestorDeSesion.Instancia.EstaLogeado)
            {
                BLL_GestorDeSesion.Instancia.UsuarioActual.IdiomaCambiado += UsuarioActual_IdiomaCambiado;
            }

            CargarIdiomasMostrar();
            ActualizarLenguaje();

            // Recalcular dígitos verificadores al iniciar solo si la integridad es correcta
            if (_integridadValida)
            {
                try
                {
                    BLL.BLL_DigitoVerificador bllDigVer = new BLL.BLL_DigitoVerificador();
                    bllDigVer.RecalcularTodo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al recalcular dígitos verificadores: " + ex.Message);
                }
            }
            else
            {
                // Ofrecer al admin la opción de recalcular o investigar
                DialogResult result = MessageBox.Show(
                    "¡ATENCIÓN ADMINISTRADOR!\n\nSe han detectado fallas en la integridad de la base de datos (dígitos verificadores rotos):\n\n" + 
                    string.Join("\n", _erroresIntegridad) + 
                    "\n\n¿Desea recalcular los dígitos verificadores?\n\n" +
                    "• Sí: Recalcular (si los cambios fueron realizados desde la aplicación)\n" +
                    "• No: Investigar mediante Control de Cambios (si sospecha manipulación externa)", 
                    "Falla de Integridad Detectada", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        BLL.BLL_DigitoVerificador bllDigVer = new BLL.BLL_DigitoVerificador();
                        bllDigVer.RecalcularTodo();
                        _integridadValida = true;
                        MessageBox.Show("Dígitos verificadores recalculados exitosamente. La integridad ha sido restaurada.", 
                                        "Integridad Restaurada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al recalcular dígitos verificadores: " + ex.Message);
                    }
                }
                else
                {
                    AbrirFormControlCambios();
                }
            }
        }

        private void UsuarioActual_IdiomaCambiado(object sender, EventArgs e)
        {
            ActualizarLenguaje();
        }

        private void CerrarSesion()
        {
            BLL.BLL_Usuario gestorUsuario = new BLL.BLL_Usuario();
                    
            var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;

            if (usuarioSesion != null)
            {
                BLLBitacora.RegistrarBitacora(usuarioSesion.ID_Usuario, usuarioSesion.Nombre, "Logout", "El administrador ha cerrado sesión", DateTime.Now);
            }
            
            gestorUsuario.Logout();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            CerrarSesion();
            Application.Restart();
        }

        private void PanelAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BLL_GestorDeSesion.Instancia.EstaLogeado)
            {
                BLL_GestorDeSesion.Instancia.UsuarioActual.IdiomaCambiado -= UsuarioActual_IdiomaCambiado;
            }

            // Cerrar todos los formularios hijos abiertos
            if (_formUsuarios != null && !_formUsuarios.IsDisposed)
                _formUsuarios.Close();
            if (_formBitacora != null && !_formBitacora.IsDisposed)
                _formBitacora.Close();
            if (_formControlCambios != null && !_formControlCambios.IsDisposed)
                _formControlCambios.Close();
            if (_formIdiomas != null && !_formIdiomas.IsDisposed)
                _formIdiomas.Close();

            CerrarSesion();
        }

        private void Menu_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        // --- Botones para abrir cada ventana ---

        private void buttonAbrirUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormUsuarios();
        }

        private void buttonAbrirBitacora_Click(object sender, EventArgs e)
        {
            AbrirFormBitacora();
        }

        private void buttonAbrirControlCambios_Click(object sender, EventArgs e)
        {
            AbrirFormControlCambios();
        }

        private void buttonAbrirIdiomas_Click(object sender, EventArgs e)
        {
            AbrirFormIdiomas();
        }

        // --- Métodos para abrir/activar cada formulario ---

        private void AbrirFormUsuarios()
        {
            if (_formUsuarios == null || _formUsuarios.IsDisposed)
            {
                _formUsuarios = new FormUsuarios(BLLBitacora, BLLusuario, bllPermiso);
                _formUsuarios.DatosModificados += FormHijo_DatosModificados;
                _formUsuarios.Show();
            }
            else
            {
                _formUsuarios.BringToFront();
                _formUsuarios.Focus();
            }
        }

        private void AbrirFormBitacora()
        {
            if (_formBitacora == null || _formBitacora.IsDisposed)
            {
                _formBitacora = new FormBitacora(BLLBitacora);
                _formBitacora.DatosModificados += FormHijo_DatosModificados;
                _formBitacora.Show();
            }
            else
            {
                _formBitacora.BringToFront();
                _formBitacora.Focus();
            }
        }

        private void AbrirFormControlCambios()
        {
            if (_formControlCambios == null || _formControlCambios.IsDisposed)
            {
                _formControlCambios = new FormControlCambios(BLLBitacora, BLLusuario);
                _formControlCambios.DatosModificados += FormHijo_DatosModificados;
                _formControlCambios.Show();
            }
            else
            {
                _formControlCambios.BringToFront();
                _formControlCambios.Focus();
            }
        }

        private void AbrirFormIdiomas()
        {
            if (_formIdiomas == null || _formIdiomas.IsDisposed)
            {
                _formIdiomas = new FormIdiomas();
                _formIdiomas.DatosModificados += FormHijo_DatosModificados;
                _formIdiomas.Show();
            }
            else
            {
                _formIdiomas.BringToFront();
                _formIdiomas.Focus();
            }
        }

        // --- Evento que recibe notificaciones de cambios de los formularios hijos ---
        private void FormHijo_DatosModificados(object sender, EventArgs e)
        {
            // Cuando un formulario hijo hace cambios, refrescar los otros que estén abiertos
            if (sender is FormUsuarios)
            {
                // Refrescar bitácora si está abierta
                if (_formBitacora != null && !_formBitacora.IsDisposed)
                    _formBitacora.EnlazarBitacora();
            }
            else if (sender is FormBitacora)
            {
                // La bitácora fue limpiada
            }
            else if (sender is FormControlCambios)
            {
                // Refrescar bitácora si está abierta
                if (_formBitacora != null && !_formBitacora.IsDisposed)
                    _formBitacora.EnlazarBitacora();
            }
            else if (sender is FormIdiomas)
            {
                // Los idiomas cambiaron - refrescar idiomas del panel y actualizar lenguaje
                CargarIdiomasMostrar();
                ActualizarLenguaje();
            }
        }

        // --- Idioma de visualización (se mantiene en el PanelAdmin principal) ---

        private void CargarIdiomasMostrar()
        {
            try
            {
                var idiomas = BLL_Multilenguaje.Instancia.ObtenerIdiomas();

                // Filtrar por idiomas agregados (activos) para la visualización
                List<BE_Idioma> idiomasActivos = new List<BE_Idioma>();
                foreach (var idm in idiomas)
                {
                    if (idm.Agregado)
                    {
                        idiomasActivos.Add(idm);
                    }
                }

                comboBoxIdiomaMostrar.DataSource = null;
                comboBoxIdiomaMostrar.DataSource = idiomasActivos;
                comboBoxIdiomaMostrar.DisplayMember = "Nombre";

                // Seleccionar el idioma actual
                var actual = BLL_Multilenguaje.Instancia.IdiomaActual;
                if (actual != null)
                {
                    foreach (var idm in idiomasActivos)
                    {
                        if (idm.ID_Idioma == actual.ID_Idioma)
                        {
                            comboBoxIdiomaMostrar.SelectedItem = idm;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar idiomas de visualización: " + ex.Message);
            }
        }

        private void buttonActualizarIdiomaMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedIdioma = comboBoxIdiomaMostrar.SelectedItem as BE_Idioma;
                if (selectedIdioma != null)
                {
                    BLL_Multilenguaje.Instancia.IdiomaActual = selectedIdioma; //cada vez que se setea, llama a notificar()
                    MessageBox.Show("Idioma de visualización actualizado con éxito.");
                }
                else
                {
                    MessageBox.Show("Seleccione un idioma válido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el idioma de visualización: " + ex.Message);
            }
        }

        // --- Helpers de gestión de permisos y renderizado del Composite ---

        private S_Componente BuscarComponentePorNombre(List<S_Componente> lista, string nombre)
        {
            foreach (var item in lista)
            {
                if (item.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }

        private void InicializarPermisosYAdministrador()
        {
            try
            {
                var todos = bllPermiso.ObtenerTodos();

                // Buscar o crear hojas
                S_Componente h1 = BuscarComponentePorNombre(todos, "Ver Bitacora");
                if (h1 == null)
                {
                    h1 = new S_Hoja { Nombre = "Ver Bitacora" };
                }
                if (h1.ID_Componente == 0) bllPermiso.GuardarComponente(h1);

                S_Componente h2 = BuscarComponentePorNombre(todos, "Limpiar Bitacora");
                if (h2 == null)
                {
                    h2 = new S_Hoja { Nombre = "Limpiar Bitacora" };
                }
                if (h2.ID_Componente == 0) bllPermiso.GuardarComponente(h2);

                S_Componente h3 = BuscarComponentePorNombre(todos, "Registrar Usuario");
                if (h3 == null)
                {
                    h3 = new S_Hoja { Nombre = "Registrar Usuario" };
                }
                if (h3.ID_Componente == 0) bllPermiso.GuardarComponente(h3);

                S_Componente h4 = BuscarComponentePorNombre(todos, "Gestionar Permisos");
                if (h4 == null)
                {
                    h4 = new S_Hoja { Nombre = "Gestionar Permisos" };
                }
                if (h4.ID_Componente == 0) bllPermiso.GuardarComponente(h4);

                S_Componente h5 = BuscarComponentePorNombre(todos, "Ver control de cambios");
                if (h5 == null)
                {
                    h5 = new S_Hoja { Nombre = "Ver control de cambios" };
                }
                if (h5.ID_Componente == 0) bllPermiso.GuardarComponente(h5);

                S_Componente h6 = BuscarComponentePorNombre(todos, "Gestionar idiomas");
                if (h6 == null)
                {
                    h6 = new S_Hoja { Nombre = "Gestionar idiomas" };
                }
                if (h6.ID_Componente == 0) bllPermiso.GuardarComponente(h6);

                // Buscar o crear composites
                S_Componente rAdmin = BuscarComponentePorNombre(todos, "Rol Admin");
                if (rAdmin == null)
                {
                    rAdmin = new S_Composite { Nombre = "Rol Admin" };
                }
                if (rAdmin.ID_Componente == 0) bllPermiso.GuardarComponente(rAdmin);

                S_Componente rUser = BuscarComponentePorNombre(todos, "Rol Usuario");
                if (rUser == null)
                {
                    rUser = new S_Composite { Nombre = "Rol Usuario" };
                }
                if (rUser.ID_Componente == 0) bllPermiso.GuardarComponente(rUser);

                // Asegurar relaciones
                // Rol Usuario debe tener como hijo a Ver Bitacora (h1)
                bool tieneH1 = false;
                foreach (var x in rUser.Hijos)
                {
                    if (x.ID_Componente == h1.ID_Componente)
                    {
                        tieneH1 = true;
                        break;
                    }
                }
                if (!tieneH1)
                {
                    rUser.Hijos.Add(h1);
                    bllPermiso.GuardarComponente(rUser);
                }

                // Rol Admin debe tener como hijos a rUser, h2, h3, h4, h5, h6
                bool modificadoAdmin = false;
                
                // Si Rol Admin tenía asignado directamente Ver Bitacora (h1), quitarlo para que no esté repetido, ya que lo heredará por rUser
                S_Componente duplicado = null;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == h1.ID_Componente)
                    {
                        duplicado = x;
                        break;
                    }
                }
                if (duplicado != null)
                {
                    rAdmin.Hijos.Remove(duplicado);
                    modificadoAdmin = true;
                }

                bool tieneRUser = false;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == rUser.ID_Componente)
                    {
                        tieneRUser = true;
                        break;
                    }
                }
                if (!tieneRUser)
                {
                    rAdmin.Hijos.Add(rUser);
                    modificadoAdmin = true;
                }

                bool tieneH2 = false;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == h2.ID_Componente)
                    {
                        tieneH2 = true;
                        break;
                    }
                }
                if (!tieneH2)
                {
                    rAdmin.Hijos.Add(h2);
                    modificadoAdmin = true;
                }

                bool tieneH3 = false;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == h3.ID_Componente)
                    {
                        tieneH3 = true;
                        break;
                    }
                }
                if (!tieneH3)
                {
                    rAdmin.Hijos.Add(h3);
                    modificadoAdmin = true;
                }

                bool tieneH4 = false;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == h4.ID_Componente)
                    {
                        tieneH4 = true;
                        break;
                    }
                }
                if (!tieneH4)
                {
                    rAdmin.Hijos.Add(h4);
                    modificadoAdmin = true;
                }

                bool tieneH5 = false;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == h5.ID_Componente)
                    {
                        tieneH5 = true;
                        break;
                    }
                }
                if (!tieneH5)
                {
                    rAdmin.Hijos.Add(h5);
                    modificadoAdmin = true;
                }

                bool tieneH6 = false;
                foreach (var x in rAdmin.Hijos)
                {
                    if (x.ID_Componente == h6.ID_Componente)
                    {
                        tieneH6 = true;
                        break;
                    }
                }
                if (!tieneH6)
                {
                    rAdmin.Hijos.Add(h6);
                    modificadoAdmin = true;
                }

                if (modificadoAdmin)
                {
                    bllPermiso.GuardarComponente(rAdmin);
                }

                // Crear el usuario administrador semilla si no existe
                var usuarios = BLLusuario.ObtenerUsuarios();
                bool existeAdmin = false;
                foreach (var u in usuarios)
                {
                    if (u.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase))
                    {
                        existeAdmin = true;
                        break;
                    }
                }
                if (!existeAdmin)
                {
                    BLLusuario.RegistrarUsuario("admin", "1234567");
                    
                    usuarios = BLLusuario.ObtenerUsuarios();
                    BE_Usuario adminUser = null;
                    foreach (var u in usuarios)
                    {
                        if (u.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase))
                        {
                            adminUser = u;
                            break;
                        }
                    }
                    
                    if (adminUser != null)
                    {
                        var allPerms = bllPermiso.ObtenerTodos();
                        S_Componente rolAdmin = null;
                        foreach (var p in allPerms)
                        {
                            if (p.Nombre.Equals("Rol Admin", StringComparison.OrdinalIgnoreCase))
                            {
                                rolAdmin = p;
                                break;
                            }
                        }
                        if (rolAdmin != null)
                        {
                            bllPermiso.GuardarPermisosUsuario(adminUser, new List<S_Componente> { rolAdmin });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error seeding default data: " + ex.Message);
            }
        }

        // --- Traducción ---
        public void ActualizarLenguaje()
        {
            labelBienvenido.Text = BLL_Multilenguaje.Instancia.Traducir("labelBienvenido", "PanelAdmin");
            buttonCerrarSesion.Text = BLL_Multilenguaje.Instancia.Traducir("buttonCerrarSesion", "PanelAdmin");
            this.Text = BLL_Multilenguaje.Instancia.Traducir("PanelAdmin", "PanelAdmin");

            string tBtnActualizar = BLL_Multilenguaje.Instancia.Traducir("buttonActualizarIdiomaMostrar", "PanelAdmin");
            buttonActualizarIdiomaMostrar.Text = tBtnActualizar.StartsWith("[Default:") ? "Actualizar" : tBtnActualizar;

            // Traducir botones de navegación
            string tUsuarios = BLL_Multilenguaje.Instancia.Traducir("tabPageUsuarios", "PanelAdmin");
            buttonAbrirUsuarios.Text = tUsuarios.StartsWith("[Default:") ? "Usuarios y Permisos" : tUsuarios;

            string tBitacora = BLL_Multilenguaje.Instancia.Traducir("tabPageBitacora", "PanelAdmin");
            buttonAbrirBitacora.Text = tBitacora.StartsWith("[Default:") ? "Bitácora" : tBitacora;

            string tControlCambios = BLL_Multilenguaje.Instancia.Traducir("tabPageControlCambios", "PanelAdmin");
            buttonAbrirControlCambios.Text = tControlCambios.StartsWith("[Default:") ? "Control de Cambios" : tControlCambios;

            string tIdiomas = BLL_Multilenguaje.Instancia.Traducir("tabPageIdiomas", "PanelAdmin");
            buttonAbrirIdiomas.Text = tIdiomas.StartsWith("[Default:") ? "Idiomas" : tIdiomas;
        }
    }
}
