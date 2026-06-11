using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MP_Multilenguaje
    {
        private Acceso acceso = new Acceso();

        public List<BE_Idioma> ObtenerIdiomas()
        {
            List<BE_Idioma> lista = new List<BE_Idioma>();
            try
            {
                acceso.Abrir();
                SqlCommand cmd = new SqlCommand("SELECT id_Idioma, Nombre, Agregado FROM Idioma", acceso.conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BE_Idioma idioma = new BE_Idioma();
                    idioma.ID_Idioma = reader.GetInt32(0);
                    idioma.Nombre = reader.GetString(1);
                    idioma.Agregado = reader.GetBoolean(2);
                    lista.Add(idioma);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener idiomas: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
            return lista;
        }

        public int ObtenerSiguienteIdIdioma()
        {
            int nextId = 1;
            try
            {
                acceso.Abrir();
                SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(id_Idioma), 0) + 1 FROM Idioma", acceso.conexion);
                nextId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener siguiente ID de idioma: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
            return nextId;
        }

        public void InsertarIdioma(BE_Idioma idioma)
        {
            try
            {
                int nextId = ObtenerSiguienteIdIdioma();
                acceso.Abrir();
                SqlCommand cmd = new SqlCommand("INSERT INTO Idioma (id_Idioma, Nombre, Agregado) VALUES (@ID, @Nombre, @Agregado)", acceso.conexion);
                cmd.Parameters.AddWithValue("@ID", nextId);
                cmd.Parameters.AddWithValue("@Nombre", idioma.Nombre);
                cmd.Parameters.AddWithValue("@Agregado", idioma.Agregado);
                cmd.ExecuteNonQuery();
                idioma.ID_Idioma = nextId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar idioma: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public void ActualizarIdioma(BE_Idioma idioma)
        {
            try
            {
                acceso.Abrir();
                SqlCommand cmd = new SqlCommand("UPDATE Idioma SET Nombre = @Nombre, Agregado = @Agregado WHERE id_Idioma = @ID", acceso.conexion);
                cmd.Parameters.AddWithValue("@ID", idioma.ID_Idioma);
                cmd.Parameters.AddWithValue("@Nombre", idioma.Nombre);
                cmd.Parameters.AddWithValue("@Agregado", idioma.Agregado);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar idioma: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public List<BE_Control> ObtenerControles()
        {
            List<BE_Control> lista = new List<BE_Control>();
            try
            {
                acceso.Abrir();
                SqlCommand cmd = new SqlCommand("SELECT id_Control, nombre_control, form FROM Control", acceso.conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BE_Control ctrl = new BE_Control();
                    ctrl.ID_Control = reader.GetInt32(0);
                    ctrl.NombreControl = reader.GetString(1);
                    ctrl.Form = reader.GetString(2);
                    lista.Add(ctrl);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener controles: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
            return lista;
        }

        public string ObtenerTextoTraduccion(int idIdioma, string nombreControl, string form)
        {
            string texto = null;
            try
            {
                acceso.Abrir();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT t.texto 
                    FROM Traduccion t
                    INNER JOIN Control c ON t.id_Control = c.id_Control
                    WHERE t.id_Idioma = @idIdioma AND c.nombre_control = @nombreControl AND c.form = @form", acceso.conexion);
                cmd.Parameters.AddWithValue("@idIdioma", idIdioma);
                cmd.Parameters.AddWithValue("@nombreControl", nombreControl);
                cmd.Parameters.AddWithValue("@form", form);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    texto = result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener traducción: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
            return texto;
        }

        public void GuardarTraduccion(int idIdioma, int idControl, string texto)
        {
            try
            {
                acceso.Abrir();
                // Verificar si ya existe
                SqlCommand cmdCheck = new SqlCommand("SELECT id_Traduccion FROM Traduccion WHERE id_Idioma = @idIdioma AND id_Control = @idControl", acceso.conexion);
                cmdCheck.Parameters.AddWithValue("@idIdioma", idIdioma);
                cmdCheck.Parameters.AddWithValue("@idControl", idControl);
                object res = cmdCheck.ExecuteScalar();

                if (res != null)
                {
                    // Actualizar
                    int idTrad = Convert.ToInt32(res);
                    SqlCommand cmdUpd = new SqlCommand("UPDATE Traduccion SET texto = @texto WHERE id_Traduccion = @idTrad", acceso.conexion);
                    cmdUpd.Parameters.AddWithValue("@texto", texto);
                    cmdUpd.Parameters.AddWithValue("@idTrad", idTrad);
                    cmdUpd.ExecuteNonQuery();
                }
                else
                {
                    // Obtener siguiente ID
                    SqlCommand cmdNext = new SqlCommand("SELECT ISNULL(MAX(id_Traduccion), 0) + 1 FROM Traduccion", acceso.conexion);
                    int nextId = Convert.ToInt32(cmdNext.ExecuteScalar());

                    // Insertar
                    SqlCommand cmdIns = new SqlCommand("INSERT INTO Traduccion (id_Traduccion, id_Idioma, id_Control, texto) VALUES (@idTrad, @idIdioma, @idControl, @texto)", acceso.conexion);
                    cmdIns.Parameters.AddWithValue("@idTrad", nextId);
                    cmdIns.Parameters.AddWithValue("@idIdioma", idIdioma);
                    cmdIns.Parameters.AddWithValue("@idControl", idControl);
                    cmdIns.Parameters.AddWithValue("@texto", texto);
                    cmdIns.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar traducción: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public DataTable ObtenerTablaTraducciones(int idIdioma)
        {
            DataTable dt = new DataTable();
            try
            {
                acceso.Abrir();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT c.id_Control, c.nombre_control, c.form, ISNULL(t.texto, '') AS texto
                    FROM Control c
                    LEFT JOIN Traduccion t ON c.id_Control = t.id_Control AND t.id_Idioma = @idIdioma", acceso.conexion);
                cmd.Parameters.AddWithValue("@idIdioma", idIdioma);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener tabla de traducción: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
            return dt;
        }
    }
}
