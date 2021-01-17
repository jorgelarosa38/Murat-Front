using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaVirtual.Models
{
    public class Operacion
    {
        public List<OperacionDatos> Detalle1 { get; set; }
        public List<OperacionDatos> Detalle2 { get; set; }
        public List<Cliente> Cliente { get; set; }

    }
    public class OperacionDatos
    {
        public int IdOperacion { get; set; }
        public string Nro_Operacion { get; set; }
        public int Cod_Operacion { get; set; }
        public string Operacion { get; set; }
        public string DFecha { get; set; }
        public string SHora { get; set; }
        public string SLogin { get; set; }
        public int IdUsuario { get; set; }
        public string SComentario { get; set; }
    }
    public class OperacionRequest
    {
        public string DFecha_Ini { get; set; }
        public string DFecha_Fin { get; set; }
        public int IdOperacion { get; set; }
        public int IdUsuario { get; set; }
        public string SCliente { get; set; }
        public int Estado { get; set; }
    }

    public class OperacionResponse
    {
        public string Nro_Operacion { get; set; }
        public int Item { get; set; }
        public string SCliente { get; set; }
        public string Operacion { get; set; }
        public string DFecha { get; set; }
        public string SHora { get; set; }
        public string SLogin { get; set; }
        public string Estado { get; set; }
        public string SComentario { get; set; }
        public int IdDetalle { get; set; }
    }
}
