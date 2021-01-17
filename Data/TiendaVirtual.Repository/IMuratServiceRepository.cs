using TiendaVirtual.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaVirtual.Repository
{
    public interface IMuratServiceRepository
    {
        Task<List<MenuBar>> GetMenuBar(object Tipo, object Id1, object Id2);
        Task<List<Main>> ListSlider(int Tipo, int Id1, int Id2);
        Task<List<PublicadoProductoServ>> ListPublProducto(FiltroProducto filtroProducto);
        Task<List<ProductoIDServ>> ListPublProductoID(int idProducto);
        Task<object> ListFiltros(int tipo);
        Task<ResponseSql> UpdClientes(MuratClientes clientes);
        Task<ResponseSql> UpdPedido(string xml);
        Task<List<Combo>> ListarCombo(int TIPO, string PARM1, string PARM2, string PARM3, string PARM4, int VALOR);
        Task<List<LoginOut>> LoginUsuario(Login login);
        Task<Validacion> ValidaCliente(Validacion validacion);
        Task<Operacion> ListOperacionID(int idDetalle);
        Task<List<OperacionResponse>> ListOperacion(OperacionRequest request);
        Task<Cliente> ListClienteID(int idCliente);
        Task<List<ClienteResponse>> ListCliente(ClienteRequest cliente);
        Task<List<UsuarioLogResponse>> ListUsuarioLog(UsuarioLogRequest logRequest);
    }
}
