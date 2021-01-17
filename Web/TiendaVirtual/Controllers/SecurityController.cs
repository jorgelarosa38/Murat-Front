﻿using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.BusinessLogic.Interfaces;
using TiendaVirtual.Models;
using TiendaVirtual.Utilities;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

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
            Response response = new Response();
            object rpta = new object();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                credenciales = (Credenciales)BusinessLogic.Utilities.AuxiliarMethods.ValidateParameters(credenciales, credenciales.GetType());
                rpta = await _securitylogic.ValidarAccesos(credenciales);

                if (rpta == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                response.Status = Constant.Error500;
                response.Message = e.Message;
                return Ok(response);
            }
            return Ok(rpta);
        }
    }
}
