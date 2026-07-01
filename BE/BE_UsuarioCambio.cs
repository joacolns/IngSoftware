using System;

namespace BE
{
    public class BE_UsuarioCambio
    {
        public int ID_Cambio { get; set; }
        public int ID_Usuario { get; set; }
        public int Version { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public DateTime Fecha { get; set; }
        public string Modificado_Por { get; set; }
        public string Tipo_Cambio { get; set; }
    }
}
