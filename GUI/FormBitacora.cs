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
    public partial class FormBitacora : Form
    {
        private BLL.BLL_Bitacora BLLBitacora;

        // Evento para notificar al PanelAdmin que hubo cambios
        public event EventHandler DatosModificados;

        public FormBitacora(BLL.BLL_Bitacora bllBitacora)
        {
            InitializeComponent();
            this.BLLBitacora = bllBitacora;
        }

        private void FormBitacora_Load(object sender, EventArgs e)
        {
            EnlazarBitacora();
            ConfigurarPermisos();
            ActualizarLenguaje();

            if (BLL_GestorDeSesion.Instancia.EstaLogeado)
            {
                BLL_GestorDeSesion.Instancia.UsuarioActual.IdiomaCambiado += UsuarioActual_IdiomaCambiado;
            }
        }

        private void FormBitacora_FormClosing(object sender, FormClosingEventArgs e)
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

        public void EnlazarBitacora()
        {
            try
            {
                BLL.BLL_Bitacora gestorBitacora = new BLL.BLL_Bitacora();
                dataGridViewBitacora.DataSource = "";
                dataGridViewBitacora.DataSource = gestorBitacora.ObtenerBitacora();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_LimpiarBitacora_Click(object sender, EventArgs e)
        {
            BLLBitacora.LimpiarBitacora();

            var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;

            if (usuarioSesion != null)
            {
                BLLBitacora.RegistrarBitacora(usuarioSesion.ID_Usuario, usuarioSesion.Nombre, "Bitacora", "El administrador ha limpiado la bitacora", DateTime.Now);
            }

            EnlazarBitacora();
            NotificarCambios();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            FiltrarBitacora();
        }

        private void FiltrarBitacora()
        {
            try
            {
                DateTime fechaInicio = dateTimePickerFechaInicio.Value.Date;
                DateTime fechaFin = dateTimePickerFechaFinal.Value.Date.AddDays(1).AddTicks(-1);
                string filtroUsuario = textBoxUsuarioBuscar.Text.Trim().ToLower();

                DataTable dtCompleto = BLLBitacora.ObtenerBitacora();

                if (dtCompleto != null)
                {
                    // Consulta LINQ 
                    var consultaFiltro =
                        from row in dtCompleto.AsEnumerable()
                        let fecha = Convert.ToDateTime(row["FechaHora"])
                        let usuario = row["Username"].ToString().ToLower()
                        where fecha >= fechaInicio && fecha <= fechaFin && usuario.Contains(filtroUsuario)
                        select row;

                    dataGridViewBitacora.DataSource = consultaFiltro.Any() ? consultaFiltro.CopyToDataTable() : dtCompleto.Clone();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar la bitácora: " + ex.Message);
            }
        }

        // --- Configurar permisos ---
        public void ConfigurarPermisos()
        {
            var usuarioSesion = BLL_GestorDeSesion.Instancia.UsuarioActual;
            if (usuarioSesion != null)
            {
                BLL_Permiso bllPermisoEval = new BLL_Permiso();

                // Limpiar Bitacora
                btn_LimpiarBitacora.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Limpiar Bitacora");

                // Ver Bitacora
                dataGridViewBitacora.Visible = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
                buttonBuscar.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
                textBoxUsuarioBuscar.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
                dateTimePickerFechaInicio.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
                dateTimePickerFechaFinal.Enabled = bllPermisoEval.TienePermiso(usuarioSesion, "Ver Bitacora");
            }
        }

        // --- Traducción ---
        public void ActualizarLenguaje()
        {
            string tBitacora = BLL_Multilenguaje.Instancia.Traducir("tabPageBitacora", "PanelAdmin");
            this.Text = tBitacora.StartsWith("[Default:") ? "Bitácora" : tBitacora;

            labelBitacora.Text = BLL_Multilenguaje.Instancia.Traducir("labelBitacora", "PanelAdmin");
            btn_LimpiarBitacora.Text = BLL_Multilenguaje.Instancia.Traducir("btn_LimpiarBitacora", "PanelAdmin");
            buttonBuscar.Text = BLL_Multilenguaje.Instancia.Traducir("buttonBuscar", "PanelAdmin");
            labelFechaInicio.Text = BLL_Multilenguaje.Instancia.Traducir("labelFechaInicio", "PanelAdmin");
            labelFechaFinal.Text = BLL_Multilenguaje.Instancia.Traducir("labelFechaFinal", "PanelAdmin");
            labelNombredeusuario.Text = BLL_Multilenguaje.Instancia.Traducir("labelNombredeusuario", "PanelAdmin");
        }
    }
}
