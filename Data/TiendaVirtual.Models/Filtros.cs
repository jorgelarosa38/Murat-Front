namespace TiendaVirtual.Models
{
    public class ListCategorias
    {
        public int IdCategoria { get; set; }
        public string SCategoria { get; set; }
    }
    public class ListMarcas
    {
        public int IdMarca { get; set; }
        public string SMarca { get; set; }
    }
    public class ListArrPrecios
    {
        public string Inicio { get; set; }
        public string Fin { get; set; }
        public string SMoneda { get; set; }
    }
}
