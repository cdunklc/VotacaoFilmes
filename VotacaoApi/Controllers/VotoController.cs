using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votacao.Domain.Commands.Inputs.Filme;
using Votacao.Domain.Commands.Inputs.VotoCommands;
using Votacao.Domain.Handlers;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Query;
using Votacao.Infra.Interfaces.Commands;

namespace VotacaoApi.Controllers
{
    [Authorize]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class VotoController : ControllerBase
    {
        private readonly IVotoRepository _repository;
        private readonly VotoHandler _handler;

        public VotoController(IVotoRepository repository, VotoHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/votos/{id}")]
        public VotoQueryResult ObterVoto(long id)
        {
            return _repository.Obter(id);
        }

        [HttpGet]
        [Route("v1/votos")]
        public List<VotoQueryResult> ListarVotos()
        {
            return _repository.Listar();
        }

        [HttpPost]
        [Route("v1/votos")]
        public ICommandResult InserirVoto([FromBody] AdicionarVotoCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/votos/{id}")]
        public ICommandResult AlterarVoto(long id, [FromBody] AlterarVotoCommand command)
        {
            command.VotoId = id;
            var result = _handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/votos/{id}")]
        public ICommandResult ApagarVoto(long id)
        {
            var command = new ApagarVotoCommand() { VotoId = id };
            var result = _handler.Handle(command);
            return result;
        }
    }
}
