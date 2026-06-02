using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace DAL
{
    public class Acceso
    {
        public SqlConnection conexion;
        
        public void Abrir()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = "Integrated Security=SSPI;Initial Catalog=IngDeSoftDB;Data Source=ADMIN3E0A\\SQLEXPRESS";
            conexion.Open();
        }

        public void Cerrar()
        {
            conexion.Close();
            conexion = null;
            GC.Collect();
        }

        public SqlCommand CrearComando (string nombre, List<SqlParameter> parametros = null)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = nombre;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            if(parametros != null)
            {
                cmd.Parameters.AddRange(parametros.ToArray());
            }

            return cmd;
        }

        public int Escribir(string nombre, List<SqlParameter> parametros = null)
        {
            SqlCommand cmd = CrearComando(nombre, parametros);
            int filas = 0;

            try
            {
                filas = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BD: " + ex.Message);
            }

            cmd.Parameters.Clear();
        
            cmd = null;
            return filas;
        }

        public DataTable Leer(string nombre, List<SqlParameter> parametros = null)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();

            DataTable dt = new DataTable();

            adaptador.SelectCommand = CrearComando(nombre, parametros);
            adaptador.Fill(dt);

            return dt;
        }

        public SqlParameter CrearParametro(string nombre, string valor)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor;
            parametro.DbType = DbType.String;

            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, int valor)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor;
            parametro.DbType = DbType.Int32;

            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, DateTime valor)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor;
            parametro.DbType = DbType.DateTime;

            return parametro;
        }
    }
}