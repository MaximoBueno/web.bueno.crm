using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.aplication.Abstractions;
using web.bueno.crm.aplication.Common;
using ApplicationException = web.bueno.crm.aplication.Common.ApplicationException;

namespace web.bueno.crm.aplication.UsesCases.UseCaseContacto.ListarContactoPorGestor
{
    public class ListarContactoPorGestorHandler(IContactoRepository contactoRepository, IMapper mapper)
        : IRequestHandler<ListarContactoPorGestorRequest, IResult>
    {
        public async Task<IResult> Handle(ListarContactoPorGestorRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;

            try
            {

                var validator = new ListarContactoPorGestorValidator();

                var validatorResult = validator.Validate(request);

                if (!validatorResult.IsValid)
                    throw new ValidationException(validatorResult.ToString());


                //var count = await contactoRepository.CantidadContactoPorIdGestor(request.IdGestor);

                var contactos = await contactoRepository.ListarContactoPorIdGestor(request.IdGestor, request.Page, request.Limit);

                var list = mapper.Map<List<ContactoResponse>>(contactos);

                if (contactos != null)
                {
                    response = new SuccessResult<ListarContactoPorGestorResponse>(
                        new ListarContactoPorGestorResponse { contactos = list }
                    );
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
