using Azure.Core;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using ApplicationException = web.bueno.crm.aplication.Common.ApplicationException;

using web.bueno.crm.aplication.UsesCases.UseCaseToken.LeerToken;
using web.bueno.crm.aplication.Common;
using web.bueno.crm.aplication.UsesCases.UseCaseUsuario.LoginUsuario;
using MediatR;
using web.bueno.crm.aplication.Services;
using web.bueno.crm.aplication.UsesCases.UseCaseToken.RefreshToken;

namespace web.bueno.crm.lia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {

        [AllowAnonymous]
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

        [Authorize]
        [ProducesResponseType(typeof(FailureResult<Exception>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(FailureResult<ApplicationException>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(FailureResult<ValidationException>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SuccessResult<LeerTokenResponse>), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        [HttpPost("LeerToken")]
        public async Task<ActionResult> LeerToken([FromBody] LeerTokenRequest req)
        {
            try
            {
                var response = await mediator.Send(req);
                return Ok(response);
            }

            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new FailureResult<ValidationException>(ex.Message));
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new FailureResult<ApplicationException>(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new FailureResult<Exception>(ex.Message));
            }
        }

        [Authorize]
        [ProducesResponseType(typeof(FailureResult<Exception>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(FailureResult<ApplicationException>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(FailureResult<ValidationException>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SuccessResult<RefreshTokenResponse>), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        [HttpPut("RefreshToken")]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest req)
        {
            try
            {
                var response = await mediator.Send(req);
                return Ok(response);
            }

            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new FailureResult<ValidationException>(ex.Message));
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new FailureResult<ApplicationException>(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new FailureResult<Exception>(ex.Message));
            }
        }

    }
}
