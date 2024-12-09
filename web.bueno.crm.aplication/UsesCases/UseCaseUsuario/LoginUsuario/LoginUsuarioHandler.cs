﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.aplication.Common;
using web.bueno.crm.aplication.Abstractions;
using ApplicationException = web.bueno.crm.aplication.Common.ApplicationException;
using web.bueno.crm.aplication.Services;

namespace web.bueno.crm.aplication.UsesCases.UseCaseUsuario.LoginUsuario
{
    public class LoginUsuarioHandler(IUsuarioRepository usuarioRepository, ITokenService tokenService, IMapper mapper)
        : IRequestHandler<LoginUsuarioRequest, IResult>
    {
        public async Task<IResult> Handle(LoginUsuarioRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;

            try
            {

                var validator = new LoginUsuarioValidator();

                var validatorResult = validator.Validate(request);

                if (!validatorResult.IsValid)
                    throw new ValidationException(validatorResult.ToString());

                var usuario = await usuarioRepository.Login(request.Correo, request.Clave);

                if (usuario != null) {

                    response = new SuccessResult<LoginUsuarioResponse>(
                        new LoginUsuarioResponse { Token = tokenService.CreateToken(usuario)}
                    );

                }
                else
                {
                    response = new FailureResult<ApplicationException>("Usuario o contraseña incorrecta");

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
