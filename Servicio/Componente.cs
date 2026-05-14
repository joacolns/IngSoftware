using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public abstract class Componente
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

        public abstract void Agregar(Componente permiso);
        public abstract void Quitar(Componente permiso);
        public abstract List<Componente> ObtenerHijos();
    }
}