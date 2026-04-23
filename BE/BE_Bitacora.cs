using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Bitacora
    {
        public int ID_Bitacora { get; set; }
        public int ID_Usuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string Actividad { get; set; }
        public string Detalle { get; set; }
        public string Username { get; set; }
    }
}