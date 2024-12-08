using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using web.bueno.crm.aplication.Common;
using web.bueno.crm.aplication.UsesCases.UseCaseUsuario.LoginUsuario;

using ApplicationException = web.bueno.crm.aplication.Common.ApplicationException;

namespace web.bueno.crm.lia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {

        [ProducesResponseType(typeof(FailureResult<Exception>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(FailureResult<ApplicationException>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(FailureResult<ValidationException>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SuccessResult<LoginUsuarioResponse>), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        [HttpPost("Token")]
        public async Task<IActionResult> Token([FromBody] LoginUsuarioRequest request)
        {
            var response = await mediator.Send(request);

            if (response.HasSucceeded)
            {
                return Ok(response);
            }
            else if (response.GetType() == typeof(FailureResult<ValidationException>))
            {

                return StatusCode(StatusCodes.Status400BadRequest, response);
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
