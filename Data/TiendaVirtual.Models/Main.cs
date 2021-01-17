using System.Collections.Generic;

namespace TiendaVirtual.Models
{
    public class Etiqueta
    {
        public int IdEtiqueta { get; set; }
        public string SEtiqueta { get; set; }
    }
    public class Configuracion
    {
        public int IdConfiguracion { get; set; }
        public string Publicidad { get; set; }
        public string Encendido { get; set; }
    }
    public class MainTag
    {
        public string STag { get; set; }
    }
    public class Main
    {
        public List<Slider> Sliders { get; set; }
        public List<Etiqueta> Etiquetas { get; set; }
        public List<Configuracion> Configuracion { get; set; }
        public List<MainTag> Tag { get; set; }
    }
}
