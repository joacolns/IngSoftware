using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_Permiso : Mapper<BE_Componente>
    {
        private Acceso acceso = new Acceso();

        public override int Insertar(BE_Componente entidad)
        {
            return GuardarComponente(entidad);
        }

        public int GuardarComponente(BE_Componente componente)
        {
            int id = 0;
            try
            {
                acceso.Abrir();

                SqlCommand cmd = new SqlCommand("SP_GuardarComponente", acceso.conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", componente.Nombre);
                cmd.Parameters.AddWithValue("@Tipo", componente.Tipo);

                SqlParameter paramId = new SqlParameter("@ID", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramId);

                cmd.ExecuteNonQuery();

                id = Convert.ToInt32(paramId.Value);
                componente.ID_Componente = id;

                if (componente.Tipo == "Composite")
                {
                    // Limpiar relaciones viejas
                    SqlCommand cmdClean = new SqlCommand("SP_LimpiarRelacionesComponente", acceso.conexion);
                    cmdClean.CommandType = CommandType.StoredProcedure;
                    cmdClean.Parameters.AddWithValue("@ID_Padre", id);
                    cmdClean.ExecuteNonQuery();

                    // Guardar nuevas relaciones
                    foreach (var hijo in componente.Hijos)
                    {
                        SqlCommand cmdRel = new SqlCommand("SP_GuardarRelacion", acceso.conexion);
                        cmdRel.CommandType = CommandType.StoredProcedure;
                        cmdRel.Parameters.AddWithValue("@ID_Padre", id);
                        cmdRel.Parameters.AddWithValue("@ID_Hijo", hijo.ID_Componente);
                        cmdRel.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar componente: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
            return id;
        }

        public List<BE_Componente> ObtenerTodos()
        {
            List<BE_Componente> todos = new List<BE_Componente>();
            Dictionary<int, BE_Componente> componentesDict = new Dictionary<int, BE_Componente>();
            HashSet<int> hijosIds = new HashSet<int>();

            try
            {
                acceso.Abrir();

                DataTable dtComp = acceso.Leer("SP_ListarComponentes");
                foreach (DataRow row in dtComp.Rows)
                {
                    int id = Convert.ToInt32(row["id_Componente"]);
                    string nombre = row["nombre"].ToString();
                    string tipo = row["tipo"].ToString();

                    BE_Componente comp = new BE_Componente();
                    comp.Tipo = tipo;

                    comp.ID_Componente = id;
                    comp.Nombre = nombre;

                    componentesDict[id] = comp;
                    todos.Add(comp);
                }

                // 2. Leer todas las relaciones y armar la estructura
                DataTable dtRel = acceso.Leer("SP_ListarRelaciones");
                foreach (DataRow row in dtRel.Rows)
                {
                    int idPadre = Convert.ToInt32(row["id_Padre"]);
                    int idHijo = Convert.ToInt32(row["id_Hijo"]);

                    if (componentesDict.ContainsKey(idPadre) && componentesDict.ContainsKey(idHijo))
                    {
                        BE_Componente padre = componentesDict[idPadre];
                        BE_Componente hijo = componentesDict[idHijo];

                        if (padre.Tipo.Equals("Composite", StringComparison.OrdinalIgnoreCase))
                        {
                            bool existe = false;
                            foreach (var h in padre.Hijos)
                            {
                                if (h.ID_Componente == hijo.ID_Componente)
                                {
                                    existe = true;
                                    break;
                                }
                            }
                            if (!existe)
                            {
                                padre.Hijos.Add(hijo);
                            }
                            hijosIds.Add(idHijo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener componentes: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }

            return todos;
        }

        public List<BE_Componente> ObtenerPermisosUsuario(int idUsuario, List<BE_Componente> todosComponentes)
        {
            List<BE_Componente> permisosUsuario = new List<BE_Componente>();
            try
            {
                acceso.Abrir();

                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@ID_Usuario", idUsuario)
                };

                DataTable dt = acceso.Leer("SP_ListarPermisosUsuario", parametros);
                foreach (DataRow row in dt.Rows)
                {
                    int idComp = Convert.ToInt32(row["id_Componente"]);

                    BE_Componente comp = null;
                    foreach (var c in todosComponentes)
                    {
                        if (c.ID_Componente == idComp)
                        {
                            comp = c;
                            break;
                        }
                    }

                    if (comp != null)
                    {
                        permisosUsuario.Add(comp);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener permisos de usuario: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
            return permisosUsuario;
        }

        public void GuardarPermisosUsuario(int idUsuario, List<BE_Componente> permisos)
        {
            try
            {
                acceso.Abrir();

                // Limpiar permisos anteriores
                SqlCommand cmdClean = new SqlCommand("SP_LimpiarUsuarioPermisos", acceso.conexion);
                cmdClean.CommandType = CommandType.StoredProcedure;
                cmdClean.Parameters.AddWithValue("@ID_Usuario", idUsuario);
                cmdClean.ExecuteNonQuery();

                // Guardar los nuevos
                foreach (var permiso in permisos)
                {
                    SqlCommand cmdRel = new SqlCommand("SP_GuardarUsuarioPermiso", acceso.conexion);
                    cmdRel.CommandType = CommandType.StoredProcedure;
                    cmdRel.Parameters.AddWithValue("@ID_Usuario", idUsuario);
                    cmdRel.Parameters.AddWithValue("@ID_Componente", permiso.ID_Componente);
                    cmdRel.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar permisos de usuario: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }
    }
}
