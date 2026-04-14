using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Usuario
    {
        public int Login(BE.Usuario usuario)
        {
            DAL.MP_Usuario mp_usuario = new DAL.MP_Usuario();
            int resultado = mp_usuario.Login(usuario);

            return resultado;
        }
    }
}
