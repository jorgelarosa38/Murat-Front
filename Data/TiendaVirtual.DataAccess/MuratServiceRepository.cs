using Dapper;
using TiendaVirtual.Models;
using TiendaVirtual.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TiendaVirtual.DataAccess
{
    public class MuratServiceRepository : IMuratServiceRepository
    {
        protected string _connectionString;
        public MuratServiceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<MenuBar>> GetMenuBar(object Tipo, object Id1, object Id2)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TIPO", Tipo);
            parameters.Add("@ID1", Id1);
            parameters.Add("@ID2", Id2);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<MenuBar>("[dbo].[SPE_LIST_MENU]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<object> ListFiltros(int Tipo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TIPO", Tipo);

            using (var connection = new SqlConnection(_connectionString))
            {
                if (Tipo == 1)
                {
                    return (await connection.QueryAsync<ListMarcas>("[dbo].[SPE_LIST_FILTRO]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
                if (Tipo == 2)
                {
                    return (await connection.QueryAsync<ListCategorias>("[dbo].[SPE_LIST_FILTRO]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
                if (Tipo == 3)
                {
                    return (await connection.QueryAsync<ListArrPrecios>("[dbo].[SPE_LIST_FILTRO]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
                return null;
            }
        }

        public async Task<List<PublicadoProductoServ>> ListPublProducto(FiltroProducto filtroProducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TIPO", filtroProducto.Tipo);
            parameters.Add("@STAG", filtroProducto.STag);
            parameters.Add("@IDCATEGORIA", filtroProducto.IdCategoria);
            parameters.Add("@IDMARCA", filtroProducto.IdMarca);
            parameters.Add("@PRECIO_INI", filtroProducto.Precio_Ini);
            parameters.Add("@PRECIO_FIN", filtroProducto.Precio_Fin);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<PublicadoProductoServ>("[dbo].[SPE_LIST_PUB_PRODUCTO]", parameters, commandType: System.Data.CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<List<ProductoIDServ>> ListPublProductoID(int idProducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IDPRODUCTO", idProducto);

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlMapper.GridReader reader = await connection.QueryMultipleAsync("[dbo].[SPE_LIST_PUB_PRODUCTO_ID]", parameters, commandType: CommandType.StoredProcedure);
                List<ProductoIDServ> productos = reader.Read<ProductoIDServ>().ToList();
                List<ColorIDServ> colores = reader.Read<ColorIDServ>().ToList();
                List<ImagenIDServ> imagenes = reader.Read<ImagenIDServ>().ToList();
                List<TallaIDServ> tallas = reader.Read<TallaIDServ>().ToList();
                List<StockIDServ> stock = reader.Read<StockIDServ>().ToList();
                foreach (var item in productos)
                {
                    item.Color = colores;
                    item.Imagen = imagenes;
                    item.Talla = tallas;
                    item.Stock = stock;
                }

                return productos;
            }
        }

        public async Task<List<Main>> ListSlider(int Tipo, int Id1, int Id2)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TIPO", Tipo);
            parameters.Add("@ID1", Id1);
            parameters.Add("@ID2", Id2);

            using (var connection = new SqlConnection(_connectionString))
            {
                List<Main> LstMain = new List<Main>();
                Main main = new Main();
                SqlMapper.GridReader reader = await connection.QueryMultipleAsync("[dbo].[SPE_LIST_SLIDER]", parameters, commandType: System.Data.CommandType.StoredProcedure);
                List<Slider> ListSlider = reader.Read<Slider>().ToList();
                List<Etiqueta> ListEtiqueta = reader.Read<Etiqueta>().ToList();
                List<Configuracion> ListConfig = reader.Read<Configuracion>().ToList();
                List<MainTag> ListTag = reader.Read<MainTag>().ToList();

                if (ListSlider.Count > 0)
                {
                    main.Sliders = ListSlider;
                    main.Etiquetas = ListEtiqueta;
                    main.Configuracion = ListConfig;
                    main.Tag = ListTag;
                    LstMain.Add(main);
                    return LstMain;
                }

                return null;
            }
        }

        public async Task<ResponseSql> UpdClientes(MuratClientes clientes)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IDCLIENTE", clientes.IdCliente);
            parameters.Add("@SCORREO", clientes.SCorreo);
            parameters.Add("@SNOMBRE", clientes.SNombre);
            parameters.Add("@SAPELLIDO", clientes.SApellido);
            parameters.Add("@SNOMBRE_LARGO", clientes.SNombre_Largo);
            parameters.Add("@SNRO_TELEFONO", clientes.SNro_Telefono);
            parameters.Add("@CONTRASENA", clientes.Contrasena);

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<ResponseSql>("[dbo].[SPE_UDP_EXT_CLIENTE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<ResponseSql> UpdPedido(string xml)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@XmlDocument", xml);

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<ResponseSql>("[dbo].[SPE_UDP_EXT_PEDIDO]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<List<Combo>> ListarCombo(int TIPO, string PARM1, string PARM2, string PARM3, string PARM4, int VALOR)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TIPO", TIPO);
            parameters.Add("@PARM1", PARM1);
            parameters.Add("@PARM2", PARM2);
            parameters.Add("@PARM3", PARM3);
            parameters.Add("@PARM4", PARM4);
            parameters.Add("@VALOR", VALOR);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<Combo>("[dbo].[SPE_LIST_COMBO]", parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<List<LoginOut>> LoginUsuario(Login login)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SLOGIN", login.SLogin);
            parameters.Add("@SCONTRASENA", login.SContrasena);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<LoginOut>("[dbo].[SPE_LOGIN_USUARIO]", parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<Validacion> ValidaCliente(Validacion validacion)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TIPO", validacion.Tipo);
            parameters.Add("@IDCLIENTE", validacion.IdCliente);
            parameters.Add("@SCLIENTE", validacion.SCliente);
            parameters.Add("@NRODOCTO", validacion.NroDocto);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryFirstAsync<Validacion>("[dbo].[SPE_VALIDA_CLIENTE]", parameters, commandType: CommandType.StoredProcedure));
            }
        }

        public async Task<Operacion> ListOperacionID(int idDetalle)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IDDETALLE", idDetalle);
            Operacion operacion = new Operacion();

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlMapper.GridReader reader = await connection.QueryMultipleAsync("[dbo].[SPE_LIST_OPERACION_ID]", parameters, commandType: CommandType.StoredProcedure);
                List<OperacionDatos> detalle1= reader.Read<OperacionDatos>().ToList();
                List<OperacionDatos> detalle2 = reader.Read<OperacionDatos>().ToList();
                List<Cliente> cliente = reader.Read<Cliente>().ToList();

                if(detalle1.Count > 0)
                {
                    operacion.Detalle1 = detalle1;
                    operacion.Detalle2 = detalle2;
                    operacion.Cliente = cliente;
                }
                return operacion;
            }
        }

        public async Task<List<OperacionResponse>> ListOperacion(OperacionRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DFECHA_INI", request.DFecha_Ini);
            parameters.Add("@DFECHA_FIN", request.DFecha_Fin);
            parameters.Add("@IDOPERACION", request.IdOperacion);
            parameters.Add("@IDUSUARIO", request.IdUsuario);
            parameters.Add("@SCLIENTE", request.SCliente);
            parameters.Add("@NESTADO", request.Estado);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<OperacionResponse>("[dbo].[SPE_LIST_OPERACION]", parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<Cliente> ListClienteID(int idCliente)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IDCLIENTE", idCliente);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryFirstAsync<Cliente>("[dbo].[SPE_LIST_CLIENTE_ID]", parameters, commandType: CommandType.StoredProcedure));
            }
        }

        public async Task<List<ClienteResponse>> ListCliente(ClienteRequest cliente)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SCLIENTE", cliente.SCliente);
            parameters.Add("@SRUC", cliente.SRuc);
            parameters.Add("@CATEGORIA", cliente.Categoria);
            parameters.Add("@IDUSUARIO", cliente.IdUsuario);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<ClienteResponse>("[dbo].[SPE_LIST_CLIENTE]", parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<List<UsuarioLogResponse>> ListUsuarioLog(UsuarioLogRequest logRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FECHA_INI", logRequest.Fecha_Ini);
            parameters.Add("@FECHA_FIN", logRequest.Fecha_Fin);
            parameters.Add("@IDUSUARIO", logRequest.IdUsuario);

            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<UsuarioLogResponse>("[dbo].[SPE_LIST_USUARIO_LOG]", parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }
    }
}
