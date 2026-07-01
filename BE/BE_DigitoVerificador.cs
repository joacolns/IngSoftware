using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_DigitoVerificador
    {
        private int id_Tabla;

        public int ID_Tabla
        {
            get { return id_Tabla; }
            set { id_Tabla = value; }
        }

        private string nombreTabla;

        public string NombreTabla
        {
            get { return nombreTabla; }
            set { nombreTabla = value; }
        }

        private string hashVertical;

        public string HashVertical
        {
            get { return hashVertical; }
            set { hashVertical = value; }
        }
    }
}
