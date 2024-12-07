using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web.bueno.crm.aplication.Common;
using web.bueno.crm.aplication.UsesCases.UseCaseUsuario.LoginUsuario;

using ApplicationException = web.bueno.crm.aplication.Common.ApplicationException;

namespace web.bueno.crm.lia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {

        [HttpPost("TestLogin")]
        public async Task<IActionResult> TestLogin([FromBody] LoginUsuarioRequest request)
        {
            var response = await mediator.Send(request);

            if (response.HasSucceeded)
            {
                return Ok(response);
            }
            else if (response.GetType() == typeof(FailureResult<ValidationException>))
            {

                return BadRequest(response);
            }
            else if (response.GetType() == typeof(FailureResult<ApplicationException>))
            {
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
