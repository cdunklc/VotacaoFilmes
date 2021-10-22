using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votacao.Domain.Commands.Inputs;
using Votacao.Domain.Handlers;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Query;
using Votacao.Infra.Interfaces.Commands;

namespace VotacaoApi.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly UsuarioHandler _handler;

        public UsuarioController(IUsuarioRepository repository, UsuarioHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/usuarios/{id}")]
        public UsuarioQueryResult ObterUsuario(long id)
        {
            return _repository.Obter(id);
        }

        [HttpGet]
        [Route("v1/usuarios")]
        public List<UsuarioQueryResult> ListarUsuarios()
        {
            return _repository.Listar();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("v1/usuarios")]
        public ICommandResult InserirUsuario([FromBody] AdicionarUsuarioCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/usuarios/{id}")]
        public ICommandResult AlterarUsuario(long id, [FromBody] AlterarUsuarioCommand command)
        {
            command.UsuarioId = id;
            var result = _handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/usuarios/{id}")]
        public ICommandResult ApagarUsuario(long id)
        {
            var command = new ApagarUsuarioCommand() { UsuarioId = id };
            var result = _handler.Handle(command);
            return result;
        }
    }
}
