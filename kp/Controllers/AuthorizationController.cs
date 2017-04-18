using System;
using kp.Business.Abstractions.Services;
using kp.Domain.Data;
using kp.WebApi.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace kp.WebApi.Controllers
{
    [Route("api/tokens")]
    public class AuthorizationController
    {
        public AuthorizationController(ITokenService tokens)
        {
            this.Tokens = tokens;
        }

        public ITokenService Tokens
        {
            get;
        }

        [HttpPost]
        public Token GetToken([FromBody]TokenRequest request)
        {
            return this.Tokens.Get(request.Login, request.Password);
        }

        [HttpGet("{token}")]
        public Token GetToken(Guid token)
        {
            return this.Tokens.Get(token);
        }
    }
}