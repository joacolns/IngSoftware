using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Bitacora
    {
        public bool RegistrarBitacora(int ID_Usuario, string username, string actividad, string detalle, DateTime fechahora)
        {

            BE.BE_Bitacora nuevaBitacora = new BE.BE_Bitacora();
            nuevaBitacora.ID_Usuario = ID_Usuario;
            nuevaBitacora.Username = username;
            nuevaBitacora.Actividad = actividad;
            nuevaBitacora.Detalle = detalle;
            nuevaBitacora.FechaHora = fechahora;
            DAL.MP_Bitacora mp_bitacora = new DAL.MP_Bitacora();

            int filas = mp_bitacora.Insertar(nuevaBitacora);

            return filas > 0;  
        }

        public bool LimpiarBitacora()
        {

            BE.BE_Bitacora nuevaBitacora = new BE.BE_Bitacora();
            DAL.MP_Bitacora mp_bitacora = new DAL.MP_Bitacora();

            int filas = mp_bitacora.Limpiar(nuevaBitacora);

            return filas > 0;
        }

        public System.Data.DataTable ObtenerBitacora()
        {
            DAL.MP_Bitacora mpBitacora = new DAL.MP_Bitacora();
            return mpBitacora.ListarBitacora();
        }
    }
}
