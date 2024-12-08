using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using web.bueno.crm.aplication.Common;
using web.bueno.crm.aplication.UsesCases.UseCaseContacto.ListarContactoPorGestor;
using ApplicationException = web.bueno.crm.aplication.Common.ApplicationException;

namespace web.bueno.crm.lia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController(IMediator mediator) : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces(MediaTypeNames.Application.Json)]
        [HttpGet("ListarContactoPorIdGestor")]
        public async Task<IActionResult> ListarContactoPorIdGestor(
            [FromQuery]
            ListarContactoPorGestorRequest request)
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
