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
    public class CrearContactoHandler(IContactoRepository contactoRepository, 
        IContactoTelefonoRepository contactoTelefonoRepository, IContactoCorreoRepository contactoCorreoRepository,
        IMapper mapper)
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
                var listaTelefonos = mapper.Map<List<ContactoTelefono>>(request.Telefonos);
                var listaCorreos = mapper.Map<List<ContactoCorreo>>(request.Correos);


                if (contacto == null)
                    throw new ValidationException("El contacto enviado es nulo");

                contacto.FechaCreacion = DateTime.Now;

                var save = await contactoRepository.CrearContacto(contacto);

                if (contacto.Id == 0) throw new Common.ApplicationException("El contacto no se registro correctamente.");

                if (save)
                {
                    var contactoRes = mapper.Map<CrearContactoResponse>(contacto);
                    response = new SuccessResult<CrearContactoResponse>(contactoRes);

                    for (int i = 0; i <= listaTelefonos.Count; i++)
                    {
                        listaTelefonos[i].IdContacto = contacto.Id;
                        listaTelefonos[i].FechaCreacion = DateTime.Now;
                        listaTelefonos[i].FechaModificacion = DateTime.Now;

                        var ok = await contactoTelefonoRepository.CrearContactoTelefono(listaTelefonos[i]);

                        if (listaTelefonos[i].Id == 0) throw new Common.ApplicationException("El telefono no se registro correctamente.");

                    }

                    for (int i = 0; i <= listaCorreos.Count; i++)
                    {
                        listaCorreos[i].IdContacto = contacto.Id;
                        listaCorreos[i].FechaCreacion = DateTime.Now;
                        listaCorreos[i].FechaModificacion = DateTime.Now;

                        var ok = await contactoCorreoRepository.CrearContactoCorreo(listaCorreos[i]);

                        if (listaCorreos[i].Id == 0) throw new Common.ApplicationException("El correo no se registro correctamente.");

                    }

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
