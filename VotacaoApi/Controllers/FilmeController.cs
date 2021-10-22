using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votacao.Domain.Commands.Inputs.Filme;
using Votacao.Domain.Handlers;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Query;
using Votacao.Infra.Interfaces.Commands;

namespace VotacaoApi.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _repository;
        private readonly FilmeHandler _handler;

        public FilmeController(IFilmeRepository repository, FilmeHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/filmes/{id}")]
        public FilmeQueryResult ObterFilme(long id)
        {
            return _repository.Obter(id);
        }

        [HttpGet]
        [Route("v1/filmes")]
        public List<FilmeQueryResult> ListarFilmes()
        {
            return _repository.Listar();
        }

        [HttpPost]
        [Route("v1/filmes")]
        public ICommandResult InserirFilme([FromBody] AdicionarFilmeCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/filmes/{id}")]
        public ICommandResult AlterarFilme(long id, [FromBody] AlterarFilmeCommand command)
        {
            command.FilmeId = id;
            var result = _handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/filmes/{id}")]
        public ICommandResult ApagarFilme(long id)
        {
            var command = new ApagarFilmeCommand() { FilmeId = id };
            var result = _handler.Handle(command);
            return result;
        }
    }
}
