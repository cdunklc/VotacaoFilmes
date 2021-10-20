using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votacao.Domain.Commands.Inputs;
using Votacao.Domain.Commands.Outputs;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Handlers
{
    public class UsuarioHandler : ICommandHandler<AdicionarUsuarioCommand>,
                                  ICommandHandler<AlterarUsuarioCommand>,
                                  ICommandHandler<ApagarUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Por favor corrija as inconsistências abaixo", command.Notifications);

                Usuario usuario = new Usuario(0, command.Nome, command.Login, command.Senha);

                long id = _repository.Inserir(usuario);                

                return new UsuarioCommandResult(true, "Usuário adicionado com sucesso!", new
                {
                    UsuarioId = id,
                    Nome = usuario.Nome,
                    Login = usuario.Login
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICommandResult Handle(AlterarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Por favor corrija as inconsistências abaixo", command.Notifications);

                if(!_repository.CheckId(command.UsuarioId))
                    return new UsuarioCommandResult(false, "UsuarioId", new Notification("UsuarioId", "UsuarioId inválido. Este usuário não foi cadastrado"));

                Usuario usuario = new Usuario(command.UsuarioId, command.Nome, command.Login, command.Senha);

                _repository.Atualizar(usuario);

                return new UsuarioCommandResult(true, "Usuário atualizado com sucesso!", new
                {
                    UsuarioId = usuario.UsuarioId,
                    Nome = usuario.Nome,
                    Login = usuario.Login
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICommandResult Handle(ApagarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Por favor corrija as inconsistências abaixo", command.Notifications);

                
                _repository.Apagar(command.UsuarioId);

                return new UsuarioCommandResult(true, "Usuário excluído com sucesso!", new { UsuarioId = command.UsuarioId });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
