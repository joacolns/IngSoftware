using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Bitacora
    {

		

        public int ID_Bitacora { get; set; }
        public int ID_Usuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string Modulo { get; set; }
        public string Accion { get; set; }


    }
}