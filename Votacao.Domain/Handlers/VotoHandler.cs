using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votacao.Domain.Commands.Inputs.Filme;
using Votacao.Domain.Commands.Inputs.VotoCommands;
using Votacao.Domain.Commands.Outputs;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Handlers
{
    public class VotoHandler :  ICommandHandler<AdicionarVotoCommand>,
                                ICommandHandler<AlterarVotoCommand>,
                                ICommandHandler<ApagarVotoCommand>
    {
        private readonly IVotoRepository _repository;
        private readonly IFilmeRepository _filmeRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public VotoHandler(IVotoRepository repository, IFilmeRepository filmeRepository, IUsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _filmeRepository = filmeRepository;
            _usuarioRepository = usuarioRepository;
        }

        public ICommandResult Handle(AdicionarVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new VotoCommandResult(false, "Por favor corrija as inconsistências abaixo", command.Notifications);

                if (!_filmeRepository.CheckId(command.FilmeId))
                    return new FilmeCommandResult(false, "FilmeId", new Notification("FilmeId", "FilmeId inválido. Este Filme não foi cadastrado"));

                if (!_usuarioRepository.CheckId(command.UsuarioId))
                    return new UsuarioCommandResult(false, "UsuarioId", new Notification("UsuarioId", "UsuarioId inválido. Este Usuario não foi cadastrado"));

                Voto voto = new Voto(0, command.UsuarioId, command.FilmeId);

                long id = _repository.Inserir(voto);

                return new VotoCommandResult(true, "Voto adicionado com sucesso!", new
                {
                    VotoId = id,
                    Usuario = command.UsuarioId,
                    Filme = command.FilmeId
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICommandResult Handle(AlterarVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new VotoCommandResult(false, "Por favor corrija as inconsistências abaixo", command.Notifications);

                if (!_repository.CheckId(command.VotoId))
                    return new VotoCommandResult(false, "VotoId", new Notification("VotoId", "VotoId inválido. Este Voto não foi cadastrado"));

                if (!_filmeRepository.CheckId(command.FilmeId))
                    return new FilmeCommandResult(false, "FilmeId", new Notification("FilmeId", "FilmeId inválido. Este Filme não foi cadastrado"));

                if (!_usuarioRepository.CheckId(command.UsuarioId))
                    return new UsuarioCommandResult(false, "UsuarioId", new Notification("UsuarioId", "UsuarioId inválido. Este Usuario não foi cadastrado"));

                Voto voto = new Voto(command.VotoId, command.UsuarioId, command.FilmeId);

                _repository.Atualizar(voto);

                return new VotoCommandResult(true, "Voto atualizado com sucesso!", new
                {
                    VotoId = command.VotoId,
                    Usuario = command.UsuarioId,
                    Filme = command.FilmeId
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICommandResult Handle(ApagarVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new VotoCommandResult(false, "Por favor corrija as inconsistências abaixo", command.Notifications);


                _repository.Apagar(command.VotoId);

                return new VotoCommandResult(true, "Voto excluído com sucesso!", new { VotoId = command.VotoId });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
