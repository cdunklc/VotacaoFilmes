using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votacao.Domain.Commands.Inputs.Authentication;
using Votacao.Domain.Handlers;
using Votacao.Infra.Interfaces.Commands;

namespace VotacaoApi.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationHandler _handler;                        

        public AuthenticationController(AuthenticationHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("signin")]
        public ICommandResult Autenticar([FromBody] AuthenticationCommand command)
        {
            return _handler.Handle(command);
        }
    }
}
