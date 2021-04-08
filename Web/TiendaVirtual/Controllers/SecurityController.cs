using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.BusinessLogic.Interfaces;
using TiendaVirtual.Models;
using TiendaVirtual.Utilities;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace TiendaVirtual.WebApi.Controllers
{
    [EnableCors]
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
    }
}
