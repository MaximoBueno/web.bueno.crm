using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using web.bueno.crm.aplication.Abstractions;
using web.bueno.crm.aplication.Common;
using ApplicationException = web.bueno.crm.aplication.Common.ApplicationException;
using AutoMapper;
using MediatR;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.aplication.UsesCases.UseCaseContacto.CrearContacto
{
    public class CrearContactoHandler(IContactoRepository contactoRepository, IMapper mapper)
        : IRequestHandler<CrearContactoRequest, IResult>
    {
        public async Task<IResult> Handle(CrearContactoRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;

            try
            {

                var validator = new CrearContactoValidator();

                var validatorResult = validator.Validate(request);

                if (!validatorResult.IsValid)
                    throw new ValidationException(validatorResult.ToString());

                var contacto = mapper.Map<Contacto>(request);

                if (contacto == null)
                    throw new ValidationException("El contacto enviado es nulo");

                contacto.FechaCreacion = DateTime.Now;

                var save = await contactoRepository.CrearContacto(contacto);

                if (save)
                {
                    var contactoRes = mapper.Map<CrearContactoResponse>(contacto);
                    response = new SuccessResult<CrearContactoResponse>(contactoRes);
                }
                else
                {
                    response = new FailureResult<ApplicationException>("No existen contactos");
                }
            }
            catch (ValidationException ex)
            {

                response = new FailureResult<ValidationException>(ex.Message);
            }
            catch (ApplicationException ex)
            {

                response = new FailureResult<ApplicationException>(ex.Message);
            }
            catch (Exception ex)
            {
                response = new FailureResult<Exception>(ex.Message);
            }

            return response;
        }
    }
}
