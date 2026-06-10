using System;
using System.Collections.Generic;

namespace BE
{
    public class BE_Componente
    {
        private int id_Componente;

        public int ID_Componente
        {
            get { return id_Componente; }
            set { id_Componente = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private List<BE_Componente> _hijos = new List<BE_Componente>();
        public List<BE_Componente> Hijos
        {
            get { return _hijos; }
            set { _hijos = value; }
        }
    }
}