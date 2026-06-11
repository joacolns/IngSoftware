using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_DigitoVerificador
    {
        private Acceso acceso = new Acceso();


        /// Actualiza el Dígito Verificador Horizontal de un usuario

        public void ActualizarDVH(int idUsuario, string digVerH)
        {
            try
            {
                acceso.Abrir();

                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@ID_Usuario", idUsuario),
                    acceso.CrearParametro("@DigVerH", digVerH)
                };

                acceso.Escribir("SP_ActualizarDigVerH", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar DVH: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }


        /// Obtiene todos los usuarios con su DVH para verificación

        public DataTable ObtenerUsuariosConDVH()
        {
            try
            {
                acceso.Abrir();
                return acceso.Leer("SP_ListarUsuarios");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios con DVH: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        /// Actualiza el Dígito Verificador Vertical de una tabla
        public void ActualizarDVV(string nombreTabla, string hashVertical)
        {
            try
            {
                acceso.Abrir();

                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@NombreTabla", nombreTabla),
                    acceso.CrearParametro("@HashVertical", hashVertical)
                };

                acceso.Escribir("SP_ActualizarDigVerV", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar DVV: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        /// Obtiene el DVV almacenado para una tabla
        public string ObtenerDVV(string nombreTabla)
        {
            try
            {
                acceso.Abrir();

                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@NombreTabla", nombreTabla)
                };

                DataTable dt = acceso.Leer("SP_ObtenerDigVerV", parametros);

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["hashVertical"].ToString();
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener DVV: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }
    }
}
