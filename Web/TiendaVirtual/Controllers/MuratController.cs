using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TiendaVirtual.BusinessLogic.Interfaces;
using TiendaVirtual.Models;
using TiendaVirtual.Utilities;

namespace TiendaVirtual.Controllers
{
    [EnableCors]
    [Produces("application/json")]
    [Route("api/[controller]/Services")]
    [AllowAnonymous]
    [ApiController]
    public class MuratController : Controller
    {
        private readonly IMuratServicesLogic _muratserviceslogic;
        private readonly IWriteOperationLogic _writeoperationlogic;
        public MuratController(IMuratServicesLogic muratserviceslogic, IWriteOperationLogic writeoperationlogic)
        {
            _muratserviceslogic = muratserviceslogic;
            _writeoperationlogic = writeoperationlogic;
        }

        [HttpGet]
        [Route("GetMenuBar/{Tipo:int}/{Id1:int}/{Id2:int}")]
        public async Task<ActionResult<Response>> GetMenuBar(int Tipo, int Id1, int Id2)
        {
            object rpta = new object();
            try
            {
                rpta = await _muratserviceslogic.GetMenuBar(Tipo, Id1, Id2);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpGet]
        [Route("ListSlider/{Tipo:int}/{Id1:int}/{Id2:int}")]
        public async Task<ActionResult<Response>> ListSlider(int Tipo, int Id1, int Id2)
        {
            object rpta = new object();
            try
            {
                rpta = await _muratserviceslogic.ListSlider(Tipo, Id1, Id2);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpPost]
        [Route("UpdClientes")]
        public async Task<ActionResult<Response>> UpdClientes(MuratClientes clientes)
        {
            object rpta = new object();
            try
            {
                rpta = await _muratserviceslogic.UpdClientes(clientes);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpPost]
        [Route("UpdPedido")]
        public async Task<ActionResult<Response>> UpdPedido(MuratPedidos pedidos)
        {
            object rpta = new object();
            try
            {
                rpta = await _muratserviceslogic.UpdPedido(pedidos);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpPost]
        [Route("ListPublProducto")]
        public async Task<ActionResult<Response>> ListPublProducto(FiltroProducto filtroProducto)
        {
            object rpta = new object();
            try
            {
                filtroProducto = (FiltroProducto)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(filtroProducto, filtroProducto.GetType());
                rpta = await _muratserviceslogic.ListPublProducto(filtroProducto);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpGet]
        [Route("ListPublProductoID/{IdProducto:int}")]
        public async Task<ActionResult<Response>> ListPublProductoID(int IdProducto)
        {
            object rpta = new object();
            try
            {
                rpta = await _muratserviceslogic.ListPublProductoID(IdProducto);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpGet]
        [Route("ListFiltros/{Tipo:int}")]
        public async Task<ActionResult<Response>> ListFiltros(int Tipo)
        {
            object rpta = new object();
            try
            {
                rpta = await _muratserviceslogic.ListFiltros(Tipo);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }


        [HttpGet]
        [Route("ListarCombo/{TIPO:int}/{PARM1:maxlength(50)}/{PARM2:maxlength(50)}/{PARM3:maxlength(50)}/{PARM4:maxlength(50)}/{VALOR:int}")]
        public async Task<ActionResult<Response>> ListarCombo(int TIPO, string PARM1, string PARM2, string PARM3, string PARM4, int VALOR)
        {
            object rpta = new object();
            try
            {
                rpta = await _muratserviceslogic.ListarCombo(TIPO, PARM1, PARM2, PARM3, PARM4, VALOR);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpPost]
        [Route("WriteOperation")]
        public async Task<ActionResult<Response>> WriteOperation([FromBody] WriteOperation writeOperation)
        {
            object rpta = new object();
            try
            {
                writeOperation = (WriteOperation)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(writeOperation, writeOperation.GetType());
                rpta = await _writeoperationlogic.WriteOperation(writeOperation);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpPost]
        [Route("LoginUsuarios")]
        public async Task<ActionResult<Response>> LoginUsuario([FromBody] Login login)
        {
            object rpta = new object();
            try
            {
                login = (Login)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(login, login.GetType());
                rpta = await _muratserviceslogic.LoginUsuario(login);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpPost]
        [Route("ValidaCliente")]
        public async Task<ActionResult<Response>> ValidaCliente([FromBody] Validacion validacion)
        {
            object rpta = new object();
            try
            {
                validacion = (Validacion)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(validacion, validacion.GetType());
                rpta = await _muratserviceslogic.ValidaCliente(validacion);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpGet]
        [Route("ListOperacionID/{IDDETALLE:int}")]
        public async Task<ActionResult<Response>> ListOperacionID(int IdDetalle)
        {
            object rpta = new object();
            try
            {
                IdDetalle = (int)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(IdDetalle, IdDetalle.GetType());
                rpta = await _muratserviceslogic.ListOperacionID(IdDetalle);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpPost]
        [Route("ListOperacion")]
        public async Task<ActionResult<Response>> ListOperacion(OperacionRequest request)
        {
            object rpta = new object();
            try
            {
                request = (OperacionRequest)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(request, request.GetType());
                rpta = await _muratserviceslogic.ListOperacion(request);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpGet]
        [Route("ListClienteID/{IDCLIENTE:int}")]
        public async Task<ActionResult<Response>> ListClienteID(int IdCliente)
        {
            object rpta = new object();
            try
            {
                IdCliente = (int)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(IdCliente, IdCliente.GetType());
                rpta = await _muratserviceslogic.ListClienteID(IdCliente);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpPost]
        [Route("ListCliente")]
        public async Task<ActionResult<Response>> ListCliente(ClienteRequest cliente)
        {
            object rpta = new object();
            try
            {
                cliente = (ClienteRequest)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(cliente, cliente.GetType());
                rpta = await _muratserviceslogic.ListCliente(cliente);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }

        [HttpPost]
        [Route("ListUsuarioLog")]
        public async Task<ActionResult<Response>> ListUsuarioLog(UsuarioLogRequest logRequest)
        {
            object rpta = new object();
            try
            {
                logRequest = (UsuarioLogRequest)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(logRequest, logRequest.GetType());
                rpta = await _muratserviceslogic.ListUsuarioLog(logRequest);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                Response response = new Response();
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }
    }
}
