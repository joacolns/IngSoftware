using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio;

namespace BE
{
    public class BE_Usuario : IObserver
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

		public List<BE_Componente> Permisos { get; set; } = new List<BE_Componente>();

		private string digVerH;

		public string DigVerH
		{
			get { return digVerH; }
			set { digVerH = value; }
		}

		public BE_Idioma Idioma { get; set; }

		public event EventHandler IdiomaCambiado;

		public static Func<BE_Idioma> ObtenerIdiomaActual;
		public static Action<int, int> GuardarIdiomaUsuarioBD;

		public void ActualizarLenguaje()
		{
			if (ObtenerIdiomaActual != null)
			{
				this.Idioma = ObtenerIdiomaActual();
				if (this.Idioma != null && GuardarIdiomaUsuarioBD != null)
				{
					GuardarIdiomaUsuarioBD(this.id_Usuario, this.Idioma.ID_Idioma);
				}
			}
			IdiomaCambiado?.Invoke(this, EventArgs.Empty);
		}
	}
}