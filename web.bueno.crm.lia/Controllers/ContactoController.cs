﻿using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using MediatR;
using web.bueno.crm.aplication.Common;
using web.bueno.crm.aplication.UsesCases.UseCaseContacto.ListarContactoPorGestor;
using ApplicationException = web.bueno.crm.aplication.Common.ApplicationException;
using web.bueno.crm.aplication.UsesCases.UseCaseContacto.CrearContacto;

namespace web.bueno.crm.lia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController(IMediator mediator) : ControllerBase
    {
        [ProducesResponseType(typeof(FailureResult<Exception>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(FailureResult<ApplicationException>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(FailureResult<ValidationException>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SuccessResult<ListarContactoPorGestorResponse>), StatusCodes.Status200OK)]
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


        [ProducesResponseType(typeof(FailureResult<Exception>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(FailureResult<ApplicationException>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(FailureResult<ValidationException>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SuccessResult<CrearContactoResponse>), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        [HttpPost("CrearContacto")]
        public async Task<IActionResult> CrearContacto([FromBody] CrearContactoRequest request)
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
