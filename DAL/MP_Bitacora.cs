using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MP_Bitacora : Mapper<BE.BE_Bitacora>
    {

        Acceso acceso = new Acceso();

        public override int Insertar(BE.BE_Bitacora entidad)
        {
            int filasAfectadas = 0;

            try
            {
                acceso.Abrir();

                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@ID_Usuario", entidad.ID_Usuario),
                    acceso.CrearParametro("@Username", entidad.Username),
                    acceso.CrearParametro("@Actividad", entidad.Actividad),
                    acceso.CrearParametro("@Detalle", entidad.Detalle),
                    acceso.CrearParametro("@FechaHora", entidad.FechaHora),
                };

                filasAfectadas = acceso.Escribir("SP_InsertarBitacora", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el registro en la bitacora: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }

            return filasAfectadas;
        }

        public System.Data.DataTable ListarBitacora()
        {
            try
            {
                acceso.Abrir();
                return acceso.Leer("SP_ListarBitacora");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar bitácora: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public int Limpiar()
        {
            int filasAfectadas = 0;

            try
            {
                acceso.Abrir();

                filasAfectadas = acceso.Escribir("SP_LimpiarBitacora");
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la bitacora: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }

            return filasAfectadas;
        }
    }
}