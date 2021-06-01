using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaVirtual.Models;
using TiendaVirtual.UnitOfWork;
using System;
using TiendaVirtual.BusinessLogic.Interfaces;
using TiendaVirtual.BusinessLogic.Utilities;
using Microsoft.Extensions.Configuration;

namespace TiendaVirtual.BusinessLogic.Implementations
{
    public class MuratServicesLogic : IMuratServicesLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public MuratServicesLogic(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<object> GetMenuBar(int Tipo, int Id1, int Id2)
        {
            Response response = new Response();
            try
            {
                List<MenuBar> list = await _unitOfWork.Murat.GetMenuBar(Tipo, Id1, Id2);

                if (list.Count > 0)
                {
                    List<MenuPadre> listP = new List<MenuPadre>();
                    var IdP = 0;

                    foreach (var item in list)
                    {
                        MenuPadre Padre = new MenuPadre();
                        Padre.SectionId = item.IdPadre;

                        if (!Padre.SectionId.Equals(IdP))
                        {
                            List<MenuDetalle> listD = new List<MenuDetalle>();
                            Padre.SectionName = item.SPadre;

                            foreach (var item2 in list)
                            {
                                if (Padre.SectionId == item2.IdPadre)
                                {
                                    MenuDetalle Detalle = new MenuDetalle();
                                    Detalle.DetailId = item2.IdDetalle;
                                    Detalle.DetailName = item2.SDetalle;
                                    listD.Add(Detalle);
                                }
                            }
                            Padre.DetailMenu = listD;
                            listP.Add(Padre);

                        }
                        IdP = Padre.SectionId;
                    }

                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = listP;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> ListFiltros(int Tipo)
        {
            Response response = new Response();
            try
            {
                object list = await _unitOfWork.Murat.ListFiltros(Tipo);

                if (list != null)
                {
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> ListPublProducto(FiltroProducto filtroProducto)
        {
            Response response = new Response();
            try
            {
                var validado = AuxiliarMethods.ValidarFiltros(filtroProducto);

                List<PublicadoProductoServ> list = await _unitOfWork.Murat.ListPublProducto(validado);

                if (list.Count() > 0)
                {
                    string directory = _config.GetSection("AppSettings").GetSection("url_imagenes").Value;
                    foreach (var item in list)
                    {
                        if (item.SArchivo_Producto != "")
                        {
                            item.Url_Producto = AuxiliarMethods.GenerarURL(directory, "Producto", item.SArchivo_Producto);
                        }
                    }
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> ListPublProductoID(int idProducto)
        {
            Response response = new Response();
            try
            {
                List<ProductoIDServ> list = await _unitOfWork.Murat.ListPublProductoID(idProducto);
                if (list.Count() > 0)
                {
                    string directory = _config.GetSection("AppSettings").GetSection("url_imagenes").Value;
                    foreach (var item in list)
                    {
                        if (item.Archivo_Marca != "")
                        {
                            item.Url_Marca = AuxiliarMethods.GenerarURL(directory,"Marca", item.Archivo_Marca);
                        }
                        if (item.Archivo_Producto != "")
                        {
                            item.Url_Producto = AuxiliarMethods.GenerarURL(directory, "Producto", item.Archivo_Producto);
                        }
                        if (item.Archivo_Talla != "")
                        {
                            item.Url_Talla = AuxiliarMethods.GenerarURL(directory, "Producto", item.Archivo_Talla);
                        }
                        foreach (var imagen in item.Imagen)
                        {
                            if (imagen.Archivo_Produccto_Color != "")
                            {
                                imagen.Url_Color = AuxiliarMethods.GenerarURL(directory, "Producto", imagen.Archivo_Produccto_Color);
                            }
                        }
                        foreach (var color in item.Color)
                        {
                            if (color.SArchivo_Imagen_0 != "")
                            {
                                color.Url_Imagen_0 = AuxiliarMethods.GenerarURL(directory, "Producto", color.SArchivo_Imagen_0);
                            }
                        }
                    }
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> ListSlider(int Tipo, int Id1, int Id2)
        {
            Response response = new Response();
            try
            {
                List<Main> list = await _unitOfWork.Murat.ListSlider(Tipo, Id1, Id2);

                if (list.Count > 0)
                {
                    string directory = _config.GetSection("AppSettings").GetSection("url_imagenes").Value;
                    foreach (var main in list)
                    {
                        foreach (var slider in main.Sliders)
                        {
                            if (slider.SArchivo != "")
                            {
                                slider.UrlImagen = AuxiliarMethods.GenerarURL(directory,"Slider", slider.SArchivo);
                            }
                        }
                    }
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> UpdClientes(MuratClientes clientes)
        {
            Response response = new Response();
            ResponseSql responsesql = new ResponseSql();

            try
            {

                responsesql = await _unitOfWork.Murat.UpdClientes(clientes);
                response.Status = responsesql.ID_ERR == 0 ? Constant.Status : responsesql.ID_ERR;
                response.Message = responsesql.DESCR_ERR;
                response.Data = responsesql.IDDATO;

            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> UpdPedido(MuratPedidos pedidos)
        {
            Response response = new Response();
            ResponseSql responsesql = new ResponseSql();

            try
            {
                var xml = AuxiliarMethods.ArmadoXML(pedidos, pedidos.GetType(), "Pedido");
                responsesql = await _unitOfWork.Murat.UpdPedido(xml);
                response.Status = responsesql.ID_ERR == 0 ? Constant.Status : responsesql.ID_ERR;
                response.Message = responsesql.DESCR_ERR;
                response.Data = responsesql.IDDATO;

            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> ListarCombo(int TIPO, string PARM1, string PARM2, string PARM3, string PARM4, int VALOR)
        {
            Response response = new Response();
            try
            {
                List<Combo> list = await _unitOfWork.Murat.ListarCombo(TIPO, PARM1, PARM2, PARM3, PARM4, VALOR);

                if (list.Count > 0)
                {
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<object> LoginUsuario(Login login)
        {
            Response response = new Response();
            try
            {
                List<LoginOut> list = await _unitOfWork.Murat.LoginUsuario(login);

                if (list != null)
                {
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> ValidaCliente(Validacion validacion)
        {
            Response response = new Response();
            try
            {
                Validacion list = await _unitOfWork.Murat.ValidaCliente(validacion);

                if (list != null)
                {
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> ListOperacionID(int idDetalle)
        {
            Response response = new Response();
            try
            {
                Operacion list = await _unitOfWork.Murat.ListOperacionID(idDetalle);

                if (list != null)
                {
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> ListOperacion(OperacionRequest request)
        {
            Response response = new Response();
            try
            {
                List<OperacionResponse> list = await _unitOfWork.Murat.ListOperacion(request);

                if (list != null)
                {
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> ListClienteID(int idCliente)
        {
            Response response = new Response();
            try
            {
                Cliente list = await _unitOfWork.Murat.ListClienteID(idCliente);

                if (list != null)
                {
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> ListCliente(ClienteRequest cliente)
        {
            Response response = new Response();
            try
            {
                List<ClienteResponse> list = await _unitOfWork.Murat.ListCliente(cliente);

                if (list != null)
                {
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<object> ListUsuarioLog(UsuarioLogRequest logRequest)
        {
            Response response = new Response();
            try
            {
                List<UsuarioLogResponse> list = await _unitOfWork.Murat.ListUsuarioLog(logRequest);

                if (list != null)
                {
                    response.Status = Constant.Status;
                    response.Message = Constant.Ok;
                    response.Data = list;
                }
                else
                {
                    response.Status = Constant.Error400;
                    response.Message = Constant.Consult;
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
            }
            return response;
        }
    }
}
