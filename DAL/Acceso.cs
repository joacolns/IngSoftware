using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        public SqlConnection conexion;

        public void Abrir()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = "Integrated Security=SSPI;Initial Catalog=IngDeSoftDB;Data Source=.";
            //conexion.ConnectionString = "Integrated Security=SSPI;Initial Catalog=IngDeSoftDB;Data Source=ADMINB33C\\SQLEXPRESS";
            conexion.Open();
        }

        public void Cerrar()
        {
            if (conexion != null)
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                conexion.Dispose();
                conexion = null;
            }
        }

        public SqlCommand CrearComando(string nombre, List<SqlParameter> parametros = null)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = nombre;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            if (parametros != null)
            {
                cmd.Parameters.AddRange(parametros.ToArray());
            }

            return cmd;
        }

        public int Escribir(string nombre, List<SqlParameter> parametros = null)
        {
            using (SqlCommand cmd = CrearComando(nombre, parametros))
            {
                int filas = 0;
                try
                {
                    filas = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la BD: " + ex.Message, ex);
                }
                finally
                {
                    cmd.Parameters.Clear();
                }
                return filas;
            }
        }

        public DataTable Leer(string nombre, List<SqlParameter> parametros = null)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = CrearComando(nombre, parametros))
            {
                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        adaptador.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al leer de la BD: " + ex.Message, ex);
                    }
                }
            }
            return dt;
        }

        public SqlParameter CrearParametro(string nombre, string valor)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.Value = (object)valor ?? DBNull.Value;
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