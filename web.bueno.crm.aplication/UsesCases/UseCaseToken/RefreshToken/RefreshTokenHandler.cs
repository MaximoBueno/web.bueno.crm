using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using web.bueno.crm.aplication.Common;
using web.bueno.crm.aplication.Services;

using ApplicationException = web.bueno.crm.aplication.Common.ApplicationException;

using web.bueno.crm.aplication.Abstractions;
using web.bueno.crm.aplication.UsesCases.UseCaseToken.LeerToken;

using MediatR;

namespace web.bueno.crm.aplication.UsesCases.UseCaseToken.RefreshToken
{
    public class RefreshTokenHandler(ITokenService tokenService, IUsuarioRepository usuarioRepository) : IRequestHandler<RefreshTokenRequest, IResult>
    {
        public async Task<IResult> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;

            try
            {
                var validator = new RefreshTokenValidator();

                var validatorResult = validator.Validate(request);

                if (!validatorResult.IsValid)
                    throw new ValidationException(validatorResult.ToString());

                var reqReadTokne = new LeerTokenRequest() { Token = request.Token };

                var readData = tokenService.ReadToken(reqReadTokne);

                var EsRefresh = readData.Payload.FirstOrDefault(c => c.Key == "refresh");
                var dataLogin = readData.Payload.FirstOrDefault(c => c.Key == "ulo");
                var dataId = readData.Payload.FirstOrDefault(c => c.Key == "uid");

                if (EsRefresh.Value == null) throw new ValidationException("Error de los datos del token #1");
                if (dataLogin.Value == null) throw new ValidationException("Error de los datos del token #2");
                if (dataId.Value == null) throw new ValidationException("Error de los datos del token #3");

                var usuario = await usuarioRepository.ObtenerUsuarioPorId(Convert.ToInt64(dataId.Value));

                var tokenPerm = tokenService.CreateToken(usuario, false);
                var tokenRefresh = tokenService.CreateToken(usuario, true);

                response = new SuccessResult<RefreshTokenResponse>(new RefreshTokenResponse(){Token = tokenPerm, TokenRefresh = tokenPerm });

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
