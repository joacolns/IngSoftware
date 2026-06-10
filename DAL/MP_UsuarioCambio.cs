using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MP_UsuarioCambio
    {
        private Acceso acceso = new Acceso();

        public int Insertar(BE_UsuarioCambio cambio)
        {
            try
            {
                acceso.Abrir();

                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(acceso.CrearParametro("@ID_Usuario", cambio.ID_Usuario));
                parametros.Add(acceso.CrearParametro("@Version", cambio.Version));
                parametros.Add(acceso.CrearParametro("@Nombre", cambio.Nombre));
                parametros.Add(acceso.CrearParametro("@Password", cambio.Password));
                parametros.Add(acceso.CrearParametro("@Role", cambio.Role));
                parametros.Add(acceso.CrearParametro("@Fecha", cambio.Fecha));
                parametros.Add(acceso.CrearParametro("@ModificadoPor", cambio.Modificado_Por));
                parametros.Add(acceso.CrearParametro("@TipoCambio", cambio.Tipo_Cambio));

                return acceso.Escribir("SP_InsertarCambioUsuario", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cambio de usuario: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public int ObtenerUltimaVersionUsuario(int idUsuario)
        {
            try
            {
                acceso.Abrir();

                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(acceso.CrearParametro("@ID_Usuario", idUsuario));

                DataTable dt = acceso.Leer("SP_ObtenerUltimaVersionUsuario", parametros);

                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["UltimaVersion"]);
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener última versión de usuario: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public List<BE_UsuarioCambio> ObtenerCambiosUsuario(int idUsuario)
        {
            List<BE_UsuarioCambio> lista = new List<BE_UsuarioCambio>();
            try
            {
                acceso.Abrir();

                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(acceso.CrearParametro("@ID_Usuario", idUsuario));

                DataTable dt = acceso.Leer("SP_ListarCambiosUsuario", parametros);

                foreach (DataRow row in dt.Rows)
                {
                    BE_UsuarioCambio cambio = new BE_UsuarioCambio();
                    cambio.ID_Cambio = Convert.ToInt32(row["id_Cambio"]);
                    cambio.ID_Usuario = Convert.ToInt32(row["id_Usuario"]);
                    cambio.Version = Convert.ToInt32(row["version"]);
                    cambio.Nombre = row["nombre"].ToString();
                    cambio.Password = row["password"].ToString();
                    cambio.Role = row["role"].ToString();
                    cambio.Fecha = Convert.ToDateTime(row["fecha"]);
                    cambio.Modificado_Por = row["modificado_por"].ToString();
                    cambio.Tipo_Cambio = row["tipo_cambio"].ToString();
                    lista.Add(cambio);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener cambios de usuario: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }

            return lista;
        }

        public int ActualizarUsuario(int idUsuario, string nombre, string password, string role)
        {
            try
            {
                acceso.Abrir();

                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(acceso.CrearParametro("@ID_Usuario", idUsuario));
                parametros.Add(acceso.CrearParametro("@Nombre", nombre));
                parametros.Add(acceso.CrearParametro("@Password", password));
                parametros.Add(acceso.CrearParametro("@Role", role));

                return acceso.Escribir("SP_ActualizarUsuario", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar usuario: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }
    }
}
