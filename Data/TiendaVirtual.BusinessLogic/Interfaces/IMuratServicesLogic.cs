using TiendaVirtual.Models;
using System.Threading.Tasks;

namespace TiendaVirtual.BusinessLogic.Interfaces
{
    public interface IMuratServicesLogic
    {
        Task<object> GetMenuBar(int tipo, int id1, int id2);
        Task<object> ListSlider(int tipo, int id1, int id2);
        Task<object> ListPublProducto(FiltroProducto filtroProducto);
        Task<object> ListPublProductoID(int idProducto);
        Task<object> ListFiltros(int tipo);
        Task<object> UpdClientes(MuratClientes clientes);
        Task<object> UpdPedido(MuratPedidos pedidos);
        Task<object> ListarCombo(int TIPO, string PARM1, string PARM2, string PARM3, string PARM4, int VALOR);
        Task<object> LoginUsuario(Login login);
        Task<object> ValidaCliente(Validacion validacion);
        Task<object> ListOperacionID(int idDetalle);
        Task<object> ListOperacion(OperacionRequest request);
        Task<object> ListClienteID(int idCliente);
        Task<object> ListCliente(ClienteRequest cliente);
        Task<object> ListUsuarioLog(UsuarioLogRequest logRequest);
    }
}
