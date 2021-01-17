using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaVirtual.Models
{
    public class UsuarioLogRequest
    {
        public string Fecha_Ini { get; set; }
        public string Fecha_Fin { get; set; }
        public int IdUsuario { get; set; }

    }
    public class UsuarioLogResponse
    {
        public int IDUSUARIO_UDP { get; set; }
        public string SLOGIN { get; set; }
        public int CANT { get; set; }
        public string FECHA { get; set; }
    }
}
