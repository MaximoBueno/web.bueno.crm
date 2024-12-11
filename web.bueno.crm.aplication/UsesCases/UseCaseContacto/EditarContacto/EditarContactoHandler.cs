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

namespace web.bueno.crm.aplication.UsesCases.UseCaseContacto.EditarContacto
{
    public class EditarContactoHandler(IContactoRepository contactoRepository, IMapper mapper)
        : IRequestHandler<EditarContactoRequest, IResult>
    {
        public async Task<IResult> Handle(EditarContactoRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;

            try
            {
                var validator = new EditarContactoValidator();

                var validatorResult = validator.Validate(request);

                if (!validatorResult.IsValid)
                    throw new ValidationException(validatorResult.ToString());


                var contacto = mapper.Map<Contacto>(request);

                if (contacto == null)
                    throw new ValidationException("El contacto enviado es nulo");

                contacto.FechaModificacion = DateTime.Now;

                var save = await contactoRepository.EditarContacto(contacto);

                if (save)
                {
                    var contactoRes = mapper.Map<EditarContactoResponse>(contacto);
                    response = new SuccessResult<EditarContactoResponse>(contactoRes);
                }
                else
                {
                    response = new FailureResult<ApplicationException>("Error en " + this.GetType().Name);
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
