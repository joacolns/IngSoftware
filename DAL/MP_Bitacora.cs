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
                    acceso.CrearParametro("@Detalle", entidad.Detalle)
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
    }
}