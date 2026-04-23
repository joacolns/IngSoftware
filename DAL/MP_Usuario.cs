using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace DAL
{
    public class MP_Usuario : Mapper<BE.Usuario>
    {
        Acceso acceso = new Acceso();
        public BE.Usuario BuscarUsuarioPorNombre(string nombreUsuario)
        {
            BE.Usuario usuarioEncontrado = null;

            try
            {
                acceso.Abrir();

                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Nombre", nombreUsuario)
                };

               
                DataTable dt = acceso.Leer("SP_LoginUsuario", parametros);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    usuarioEncontrado = new BE.Usuario();

                    usuarioEncontrado.ID_Usuario = Convert.ToInt32(fila["id_Usuario"]);
                    usuarioEncontrado.Nombre = fila["nombre"].ToString();

                  
                    usuarioEncontrado.Password = fila["password"].ToString();
                    usuarioEncontrado.Logeado = 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }

            return usuarioEncontrado;
        }

       
        public override int Insertar(BE.Usuario entidad)
        {
            int filasAfectadas = 0;
            try
            {
                acceso.Abrir();

                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Nombre", entidad.Nombre),
                  
                    acceso.CrearParametro("@Password", entidad.Password)
                };

            
                filasAfectadas = acceso.Escribir("SP_InsertarUsuario", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el usuario: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }

            return filasAfectadas;
        }
    }
}