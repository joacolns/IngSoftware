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
    public class MP_Usuario : Mapper<BE.BE_Usuario>
    {
        Acceso acceso = new Acceso();
        public BE.BE_Usuario BuscarUsuarioPorNombre(string nombreUsuario)
        {
            BE.BE_Usuario usuarioEncontrado = null;

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
                    usuarioEncontrado = new BE.BE_Usuario();

                    usuarioEncontrado.ID_Usuario = Convert.ToInt32(fila["id_Usuario"]);
                    usuarioEncontrado.Nombre = fila["nombre"].ToString();
                    usuarioEncontrado.Password = fila["password"].ToString();
                    usuarioEncontrado.DigVerH = fila["DigVerH"] != DBNull.Value ? fila["DigVerH"].ToString() : null;
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

       
        public override int Insertar(BE.BE_Usuario entidad)
        {
            int filasAfectadas = 0;
            try
            {
                acceso.Abrir();

                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Nombre", entidad.Nombre),
                    acceso.CrearParametro("@Password", entidad.Password),
                    acceso.CrearParametro("@DigVerH", entidad.DigVerH ?? "")
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

        public List<BE.BE_Usuario> ObtenerUsuarios()
        {
            List<BE.BE_Usuario> usuarios = new List<BE.BE_Usuario>();
            try
            {
                acceso.Abrir();
                DataTable dt = acceso.Leer("SP_ListarUsuarios");
                foreach (DataRow row in dt.Rows)
                {
                    BE.BE_Usuario u = new BE.BE_Usuario();
                    u.ID_Usuario = Convert.ToInt32(row["id_Usuario"]);
                    u.Nombre = row["nombre"].ToString();
                    u.Password = row["password"].ToString();
                    u.DigVerH = row["DigVerH"] != DBNull.Value ? row["DigVerH"].ToString() : null;
                    u.Logeado = 0;
                    usuarios.Add(u);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
            return usuarios;
        }
    }
}