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
        public override int Insertar(Usuario objeto)
        {
            throw new NotImplementedException();
        }

        public override int Login(Usuario objeto)
        {
            acceso = new Acceso();
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@Nombre", objeto.ToString()));
            parametros.Add(acceso.CrearParametro("@Password", objeto.ToString()));
            //parametros.Add(acceso.CrearParametro("@Logeado", int.Parse(objeto.ToString())));
            int resultado = acceso.Escribir("Login", parametros);
            objeto.Logeado = resultado;

            return resultado;
        }
    }
}