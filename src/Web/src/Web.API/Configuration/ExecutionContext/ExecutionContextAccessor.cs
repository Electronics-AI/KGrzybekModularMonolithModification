using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using CompanyName.MyMeetings.BuildingBlocks.Application;
using Microsoft.AspNetCore.Http;

namespace CompanyName.MyMeetings.API.Configuration.ExecutionContext
{
    public class ExecutionContextAccessor : IExecutionContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExecutionContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId
        {
            get
            {   
                var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
                string userId = jwt.Claims.First(c => c.Type == "sub").Value;

                return Guid.Parse(userId);
            }
        }

        public Guid CorrelationId
        {
            get
            {
                if (IsAvailable && _httpContextAccessor.HttpContext.Request.Headers.Keys.Any(
                    x => x == CorrelationMiddleware.CorrelationHeaderKey))
                {
                    return Guid.Parse(
                        _httpContextAccessor.HttpContext.Request.Headers[CorrelationMiddleware.CorrelationHeaderKey]);
                }

                throw new ApplicationException("Http context and correlation id is not available");
            }
        }

        public bool IsAvailable => _httpContextAccessor.HttpContext != null;
    }
}