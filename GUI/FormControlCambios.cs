using BE;
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
    public partial class FormControlCambios : Form
    {
        private BLL.BLL_Bitacora BLLBitacora;
        private BLL.BLL_Usuario BLLusuario;

        // Evento para notificar al PanelAdmin que hubo cambios
        public event EventHandler DatosModificados;

        public FormControlCambios(BLL.BLL_Bitacora bllBitacora, BLL.BLL_Usuario bllUsuario)
        {
            InitializeComponent();
            this.BLLBitacora = bllBitacora;
            this.BLLusuario = bllUsuario;
        }

        private void FormControlCambios_Load(object sender, EventArgs e)
        {
            dataGridViewControldecambios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewControldecambios.MultiSelect = false;

            CargarUsuariosCambios();
            FiltrarControlCambios();
            ConfigurarPermisos();
            ActualizarLenguaje();

            if (BLL_GestorDeSesion.Instancia.EstaLogeado)
            {
                BLL_GestorDeSesion.Instancia.UsuarioActual.IdiomaCambiado += UsuarioActual_IdiomaCambiado;
            }
        }

        private void FormControlCambios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BLL_GestorDeSesion.Instancia.EstaLogeado)
            {
                BLL_GestorDeSesion.Instancia.UsuarioActual.IdiomaCambiado -= UsuarioActual_IdiomaCambiado;
            }
        }

        private void UsuarioActual_IdiomaCambiado(object sender, EventArgs e)
        {
            ActualizarLenguaje();
        }

        private void NotificarCambios()
        {
            DatosModificados?.Invoke(this, EventArgs.Empty);
        }

        // --- Recomponer estado anterior ---
        private void buttonRecomponerEstadoAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewControldecambios.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una versión en la tabla de control de cambios para recomponer.");
                    return;
                }

                var cambio = dataGridViewControldecambios.SelectedRows[0].DataBoundItem as BE_UsuarioCambio;
                if (cambio == null)
                {
                    MessageBox.Show("No se pudo obtener el cambio seleccionado.");
                    return;
                }

                var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;
                string modificadoPor = usuarioSesion != null ? usuarioSesion.Nombre : "admin";

                BLL_UsuarioCambio bllCambio = new BLL_UsuarioCambio();
                bool exito = bllCambio.RecomponerEstadoAnterior(cambio, modificadoPor);

                if (exito)
                {
                    MessageBox.Show("El estado del usuario ha sido recompuesto a la versión " + cambio.Version + " con éxito.");
                    if (usuarioSesion != null)
                    {
                        BLLBitacora.RegistrarBitacora(usuarioSesion.ID_Usuario, usuarioSesion.Nombre, "Recomponer", $"Recompuso al usuario '{cambio.Nombre}' a versión {cambio.Version}", DateTime.Now);
                    }
                    FiltrarControlCambios();
                    NotificarCambios();
                }
                else
                {
                    MessageBox.Show("No se pudo recomponer el estado del usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recomponer el estado: " + ex.Message);
            }
        }

        // --- Cargar usuarios para el combo de cambios ---
        private void CargarUsuariosCambios()
        {
            try
            {
                comboBoxUsuarioCambio.SelectedIndexChanged -= comboBoxUsuarioCambio_SelectedIndexChanged;

                int idSeleccionado = 0;
                if (comboBoxUsuarioCambio.SelectedItem is BE_Usuario prevSelected)
                {
                    idSeleccionado = prevSelected.ID_Usuario;
                }

                var usuarios = BLLusuario.ObtenerUsuarios();
                List<BE_Usuario> listaUsuarios = new List<BE_Usuario>();

                BE_Usuario todos = new BE_Usuario();
                todos.ID_Usuario = 0;
                string txtTodos = BLL_Multilenguaje.Instancia.Traducir("Todos", "PanelAdmin");
                todos.Nombre = txtTodos.StartsWith("[Default:") ? "Todos" : txtTodos;

                listaUsuarios.Add(todos);
                listaUsuarios.AddRange(usuarios);

                comboBoxUsuarioCambio.DataSource = null;
                comboBoxUsuarioCambio.DataSource = listaUsuarios;
                comboBoxUsuarioCambio.DisplayMember = "Nombre";

                if (idSeleccionado > 0)
                {
                    var found = listaUsuarios.FirstOrDefault(u => u.ID_Usuario == idSeleccionado);
                    if (found != null)
                    {
                        comboBoxUsuarioCambio.SelectedItem = found;
                    }
                    else
                    {
                        comboBoxUsuarioCambio.SelectedIndex = 0;
                    }
                }
                else
                {
                    comboBoxUsuarioCambio.SelectedIndex = 0;
                }

                comboBoxUsuarioCambio.SelectedIndexChanged += comboBoxUsuarioCambio_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios en control de cambios: " + ex.Message);
            }
        }

        // --- Filtrar control de cambios ---
        private void FiltrarControlCambios()
        {
            try
            {
                dataGridViewControldecambios.DataSource = null;
                if (comboBoxUsuarioCambio.SelectedItem == null) return;

                var usuarioSelected = comboBoxUsuarioCambio.SelectedItem as BE_Usuario;
                if (usuarioSelected != null)
                {
                    BLL_UsuarioCambio bllCambio = new BLL_UsuarioCambio();
                    var listaCambios = bllCambio.ObtenerCambiosUsuario(usuarioSelected.ID_Usuario);

                    DateTime fechaInicio = dateTimePickerInicioCambio.Value.Date;
                    DateTime fechaFin = dateTimePickerFinCambio.Value.Date.AddDays(1).AddTicks(-1);
                    string tipoSeleccionado = comboBoxTipoCambio.SelectedItem?.ToString() ?? "Todos";

                    var consulta = listaCambios.AsEnumerable();

                    // Filtrar por rango de fechas
                    consulta = consulta.Where(c => c.Fecha >= fechaInicio && c.Fecha <= fechaFin);

                    // Filtrar por Tipo de Cambio
                    if (tipoSeleccionado != "Todos")
                    {
                        if (tipoSeleccionado == "Recomposicion")
                        {
                            consulta = consulta.Where(c => c.Tipo_Cambio != null && c.Tipo_Cambio.Contains("Recomposicion"));
                        }
                        else
                        {
                            consulta = consulta.Where(c => c.Tipo_Cambio != null && c.Tipo_Cambio.Equals(tipoSeleccionado, StringComparison.OrdinalIgnoreCase));
                        }
                    }

                    dataGridViewControldecambios.DataSource = consulta.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar el control de cambios: " + ex.Message);
            }
        }

        private void comboBoxUsuarioCambio_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarControlCambios();
        }

        private void comboBoxTipoCambio_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarControlCambios();
        }

        private void btnFiltrarCambio_Click(object sender, EventArgs e)
        {
            FiltrarControlCambios();
        }

        private void btnLimpiarFiltrosCambio_Click(object sender, EventArgs e)
        {
            dateTimePickerInicioCambio.Value = DateTime.Now.AddDays(-30);
            dateTimePickerFinCambio.Value = DateTime.Now;
            comboBoxTipoCambio.SelectedIndex = 0;
            comboBoxUsuarioCambio.SelectedIndex = 0;
            FiltrarControlCambios();
        }

        // --- Configurar permisos ---
        public void ConfigurarPermisos()
        {
            var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;
            if (usuarioSesion != null)
            {
                BLL_Permiso bllPermisoEval = new BLL_Permiso();
                bool tienePermiso = bllPermisoEval.TienePermiso(usuarioSesion, "Ver control de cambios");
                // Se habilita/deshabilita todo el form
                foreach (Control c in this.Controls)
                {
                    c.Enabled = tienePermiso;
                }
            }
        }

        // --- Traducción ---
        public void ActualizarLenguaje()
        {
            string tControlCambios = BLL_Multilenguaje.Instancia.Traducir("tabPageControlCambios", "PanelAdmin");
            this.Text = tControlCambios.StartsWith("[Default:") ? "Control de Cambios" : tControlCambios;

            labelControldecambios.Text = BLL_Multilenguaje.Instancia.Traducir("labelControldecambios", "PanelAdmin");
            buttonRecomponerEstadoAnterior.Text = BLL_Multilenguaje.Instancia.Traducir("buttonRecomponerEstadoAnterior", "PanelAdmin");

            if (labelSelectUsuarioCambio != null)
            {
                string tLblUsuarioCambio = BLL_Multilenguaje.Instancia.Traducir("labelSelectUsuarioCambio", "PanelAdmin");
                labelSelectUsuarioCambio.Text = tLblUsuarioCambio.StartsWith("[Default:") ? "Usuario:" : tLblUsuarioCambio;

                string tLblFechaInicio = BLL_Multilenguaje.Instancia.Traducir("labelFechaInicioCambio", "PanelAdmin");
                labelFechaInicioCambio.Text = tLblFechaInicio.StartsWith("[Default:") ? "Desde:" : tLblFechaInicio;

                string tLblFechaFin = BLL_Multilenguaje.Instancia.Traducir("labelFechaFinCambio", "PanelAdmin");
                labelFechaFinCambio.Text = tLblFechaFin.StartsWith("[Default:") ? "Hasta:" : tLblFechaFin;

                string tLblTipoCambio = BLL_Multilenguaje.Instancia.Traducir("labelTipoCambio", "PanelAdmin");
                labelTipoCambio.Text = tLblTipoCambio.StartsWith("[Default:") ? "Tipo:" : tLblTipoCambio;

                string tBtnFiltrar = BLL_Multilenguaje.Instancia.Traducir("btnFiltrarCambio", "PanelAdmin");
                btnFiltrarCambio.Text = tBtnFiltrar.StartsWith("[Default:") ? "Filtrar" : tBtnFiltrar;

                string tBtnLimpiar = BLL_Multilenguaje.Instancia.Traducir("btnLimpiarFiltrosCambio", "PanelAdmin");
                btnLimpiarFiltrosCambio.Text = tBtnLimpiar.StartsWith("[Default:") ? "Limpiar" : tBtnLimpiar;

                CargarUsuariosCambios();
            }
        }
    }
}
