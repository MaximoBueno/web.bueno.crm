using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using web.bueno.crm.aplication.Common;
using web.bueno.crm.aplication.Services;

using ApplicationException = web.bueno.crm.aplication.Common.ApplicationException;
using MediatR;

namespace web.bueno.crm.aplication.UsesCases.UseCaseToken.LeerToken
{
    public class LeerTokenHandler(ITokenService tokenService) : IRequestHandler<LeerTokenRequest, IResult>
    {
        public async Task<IResult> Handle(LeerTokenRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;

            try {
                var validator = new LeerTokenValidator();

                var validatorResult = validator.Validate(request);

                if (!validatorResult.IsValid)
                    throw new ValidationException(validatorResult.ToString());

                var consulta =  tokenService.ReadToken(request);
                response = new SuccessResult<LeerTokenResponse >(consulta);

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
