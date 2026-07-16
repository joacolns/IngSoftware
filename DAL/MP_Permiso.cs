using BE;
using Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_Permiso : Mapper<S_Componente>
    {
        private Acceso acceso = new Acceso();

        public override int Insertar(S_Componente entidad)
        {
            return GuardarComponente(entidad);
        }

        public int GuardarComponente(S_Componente componente)
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

                if (componente is S_Composite)
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

        public List<S_Componente> ObtenerTodos()
        {
            List<S_Componente> todos = new List<S_Componente>();
            Dictionary<int, S_Componente> componentesDict = new Dictionary<int, S_Componente>();
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

                    S_Componente comp;
                    if (tipo.Equals("Composite", StringComparison.OrdinalIgnoreCase))
                    {
                        comp = new S_Composite();
                    }
                    else
                    {
                        comp = new S_Hoja();
                    }

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
                        S_Componente padre = componentesDict[idPadre];
                        S_Componente hijo = componentesDict[idHijo];

                        if (padre is S_Composite)
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

        public List<S_Componente> ObtenerPermisosUsuario(int idUsuario, List<S_Componente> todosComponentes)
        {
            List<S_Componente> permisosUsuario = new List<S_Componente>();
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

                    S_Componente comp = null;
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

        public void GuardarPermisosUsuario(int idUsuario, List<S_Componente> permisos)
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
