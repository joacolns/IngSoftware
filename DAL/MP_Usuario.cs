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
        public override int Insertar(Usuario objeto)
        {
            throw new NotImplementedException();
        }

        public BE.Usuario Login(string nombreUsuario, string password)
        {
            BE.Usuario usuarioValidado = null;
            
            try
            {
                acceso.Abrir();

                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Nombre", nombreUsuario),
                    acceso.CrearParametro("@Password", password)
                };

                DataTable dt = acceso.Leer("SP_LoginUsuario", parametros);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    usuarioValidado = new BE.Usuario();

                    usuarioValidado.ID_Usuario = Convert.ToInt32(fila["id_Usuario"]);
                    usuarioValidado.Nombre = fila["nombre"].ToString();
                    usuarioValidado.Password = fila["password"].ToString();
                    usuarioValidado.Logeado = 1;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                acceso.Cerrar();
            }

            return usuarioValidado;
        }
    }
}