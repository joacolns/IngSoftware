using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Usuario
    {
		private int id_Usuario;

		public int ID_Usuario
		{
			get { return id_Usuario; }
			set { id_Usuario = value; }
		}

		private  string nombre;

		public  string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private string password;

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		private int logeado;

		public int Logeado
		{
			get { return logeado; }
			set { logeado = value; }
		}


	}
}