using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_DigitoVerificador
    {
        private MP_DigitoVerificador mpDigVer = new MP_DigitoVerificador();

        /// Calcula el DVH de un registro de usuario concatenando sus campos
        public string CalcularDVH(int idUsuario, string nombre, string password)
        {
            string cadena = idUsuario.ToString() + nombre + password;
            return Servicio.S_Seguridad.GenerarHashSHA256(cadena);
        }

        /// Actualiza el DVH de un usuario específico
        public void ActualizarDVH(int idUsuario, string nombre, string password)
        {
            string dvh = CalcularDVH(idUsuario, nombre, password);
            mpDigVer.ActualizarDVH(idUsuario, dvh);
        }

        /// Recalcula y actualiza los DVH de todos los usuarios y luego el DVV

        public void RecalcularTodo()
        {
            DataTable dt = mpDigVer.ObtenerUsuariosConDVH();

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id_Usuario"]);
                string nombre = row["nombre"].ToString();
                string password = row["password"].ToString();

                string dvh = CalcularDVH(id, nombre, password);
                mpDigVer.ActualizarDVH(id, dvh);
            }

            ActualizarDVV();
        }


        /// Calcula y almacena el DVV de la tabla Usuarios.
        /// Concatena todos los DVH y genera un hash del conjunto.

        public void ActualizarDVV()
        {
            DataTable dt = mpDigVer.ObtenerUsuariosConDVH();
            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                string dvh = row["DigVerH"] != DBNull.Value ? row["DigVerH"].ToString() : "";
                sb.Append(dvh);
            }

            string dvv = Servicio.S_Seguridad.GenerarHashSHA256(sb.ToString());
            mpDigVer.ActualizarDVV("Usuarios", dvv);
        }


        /// Verifica la integridad de un usuario específico (DVH)

        public bool VerificarDVH(int idUsuario, string nombre, string password, string dvhAlmacenado)
        {
            string dvhCalculado = CalcularDVH(idUsuario, nombre, password);
            return dvhCalculado == dvhAlmacenado;
        }


        /// Verifica la integridad de TODA la tabla Usuarios.
        /// Devuelve true si tanto los DVH individuales como el DVV son válidos.

        public bool VerificarIntegridad(out List<string> errores)
        {
            errores = new List<string>();
            bool integridadOk = true;

            DataTable dt = mpDigVer.ObtenerUsuariosConDVH();
            StringBuilder sbDvhConcatenados = new StringBuilder();

            // 1. Verificar cada DVH
            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id_Usuario"]);
                string nombre = row["nombre"].ToString();
                string password = row["password"].ToString();
                string dvhAlmacenado = row["DigVerH"] != DBNull.Value ? row["DigVerH"].ToString() : "";

                string dvhCalculado = CalcularDVH(id, nombre, password);

                if (dvhCalculado != dvhAlmacenado)
                {
                    errores.Add($"DVH inválido para usuario '{nombre}' (ID: {id}). El registro fue alterado.");
                    integridadOk = false;
                }

                sbDvhConcatenados.Append(dvhCalculado);
            }

            // 2. Verificar DVV
            string dvvCalculado = Servicio.S_Seguridad.GenerarHashSHA256(sbDvhConcatenados.ToString());
            string dvvAlmacenado = mpDigVer.ObtenerDVV("Usuarios");

            if (dvvAlmacenado == null)
            {
                errores.Add("No existe DVV almacenado para la tabla Usuarios.");
                integridadOk = false;
            }
            else if (dvvCalculado != dvvAlmacenado)
            {
                errores.Add("DVV inválido para la tabla Usuarios. La tabla fue alterada (posible inserción o eliminación de registros).");
                integridadOk = false;
            }

            return integridadOk;
        }
    }
}
