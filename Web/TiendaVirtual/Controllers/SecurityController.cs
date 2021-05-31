using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.BusinessLogic.Interfaces;
using TiendaVirtual.Models;
using TiendaVirtual.Utilities;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using static TiendaVirtual.Utilities.AESstring;

namespace TiendaVirtual.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        private readonly ISecurityLogic _securitylogic;

        public SecurityController(ISecurityLogic securitylogic)
        {
            _securitylogic = securitylogic;
        }

        [HttpPost]
        [Route("ValidarAccesos")]
        public async Task<ActionResult<Response>> ValidarAccesos(Credenciales credenciales)
        {
            object rpta = new object();
            try
            {
                credenciales = (Credenciales)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(credenciales, credenciales.GetType());
                rpta = await _securitylogic.ValidarAccesos(credenciales);

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
        [Route("encryptDecrypt")]
        public ActionResult<object> encryptDecrypt(Credenciales credenciales)
        {
            var cadena = new object();

            //usuario : cadena de conexion
            //contraseña: opcion
            if (credenciales.contraseña == "1")
            {
                cadena = EncryptAES(credenciales.usuario);
            }
            else {

                cadena = DecryptAES(credenciales.usuario);
            }

            return Ok(cadena);
        }
    }
}
