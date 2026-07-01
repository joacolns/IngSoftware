using BE;
using DAL;
using Servicio;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class BLL_Multilenguaje : ISujeto
    {
        private static BLL_Multilenguaje _instancia;
        public static BLL_Multilenguaje Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new BLL_Multilenguaje();
                }
                return _instancia;
            }
        }

        private BLL_Multilenguaje()
        {
            BE_Usuario.ObtenerIdiomaActual = () => this.IdiomaActual;
            BE_Usuario.GuardarIdiomaUsuarioBD = (userId, langId) => {
                DAL.MP_Usuario mp = new DAL.MP_Usuario();
                mp.ActualizarUsuarioIdioma(userId, langId);
            };

            // Cargar idioma por defecto (Espanol) si existe en la base de datos
            List<BE_Idioma> idiomas = mpMultilang.ObtenerIdiomas();
            foreach (var idm in idiomas)
            {
                if (idm.Nombre.Equals("Espanol", StringComparison.OrdinalIgnoreCase) && idm.Agregado)
                {
                    _idiomaActual = idm;
                    break;
                }
            }
        }

        private MP_Multilenguaje mpMultilang = new MP_Multilenguaje();
        private List<IObserver> _observers = new List<IObserver>();
        private BE_Idioma _idiomaActual;

        public BE_Idioma IdiomaActual
        {
            get { return _idiomaActual; }
            set
            {
                _idiomaActual = value;
                Notificar();
            }
        }

        public void Registrar(IObserver observer)
        {
            if (observer != null)
            {
                // Evitar duplicados
                bool existe = false;
                foreach (var obs in _observers)
                {
                    if (obs == observer)
                    {
                        existe = true;
                        break;
                    }
                }
                if (!existe)
                {
                    _observers.Add(observer);
                }
            }
        }

        public void Desregistrar(IObserver observer)
        {
            if (observer != null)
            {
                IObserver aEliminar = null;
                foreach (var obs in _observers)
                {
                    if (obs == observer)
                    {
                        aEliminar = obs;
                        break;
                    }
                }
                if (aEliminar != null)
                {
                    _observers.Remove(aEliminar);
                }
            }
        }

        public void Notificar()
        {
            foreach (var obs in _observers)
            {
                obs.ActualizarLenguaje();
            }
        }

        public List<BE_Idioma> ObtenerIdiomas()
        {
            return mpMultilang.ObtenerIdiomas();
        }

        public void GuardarIdioma(BE_Idioma idioma)
        {
            if (idioma.ID_Idioma == 0)
            {
                mpMultilang.InsertarIdioma(idioma);
            }
            else
            {
                mpMultilang.ActualizarIdioma(idioma);
            }

            // Si el idioma editado es el actual, refrescar
            if (_idiomaActual != null && _idiomaActual.ID_Idioma == idioma.ID_Idioma)
            {
                _idiomaActual = idioma;
                Notificar();
            }
        }

        public string Traducir(string nombreControl, string form)
        {
            if (_idiomaActual != null && _idiomaActual.Agregado)
            {
                string traduccion = mpMultilang.ObtenerTextoTraduccion(_idiomaActual.ID_Idioma, nombreControl, form);
                if (!string.IsNullOrEmpty(traduccion))
                {
                    return traduccion;
                }
            }
            return "[Default: " + nombreControl + "]";
        }

        public DataTable ObtenerTablaTraducciones(int idIdioma)
        {
            return mpMultilang.ObtenerTablaTraducciones(idIdioma);
        }

        public void GuardarTraduccion(int idIdioma, int idControl, string texto)
        {
            mpMultilang.GuardarTraduccion(idIdioma, idControl, texto);
            // Si el idioma actual se modificó, notificar observadores
            if (_idiomaActual != null && _idiomaActual.ID_Idioma == idIdioma)
            {
                Notificar();
            }
        }

    }
}
