using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votacao.Domain.Commands.Inputs.Filme;
using Votacao.Domain.Commands.Outputs;
using Votacao.Domain.Entidades;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Handlers
{
    public class FilmeHandler : ICommandHandler<AdicionarFilmeCommand>,
                                ICommandHandler<AlterarFilmeCommand>,
                                ICommandHandler<ApagarFilmeCommand>
    {
        private readonly IFilmeRepository _repository;

        public FilmeHandler(IFilmeRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new FilmeCommandResult(false, "Por favor corrija as inconsistências abaixo", command.Notifications);

                Filme filme = new Filme(0, command.Titulo, command.Diretor);

                long id = _repository.Inserir(filme);

                return new FilmeCommandResult(true, "Filme adicionado com sucesso!", new
                {
                    FilmeId = id,
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICommandResult Handle(AlterarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new FilmeCommandResult(false, "Por favor corrija as inconsistências abaixo", command.Notifications);

                if (!_repository.CheckId(command.FilmeId))
                    return new FilmeCommandResult(false, "FilmeId", new Notification("FilmeId", "FilmeId inválido. Este filme não foi cadastrado"));

                Filme filme = new Filme(command.FilmeId, command.Titulo, command.Diretor);

                _repository.Atualizar(filme);

                return new FilmeCommandResult(true, "Filme atualizado com sucesso!", new
                {
                    FilmeId = filme.FilmeId,
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICommandResult Handle(ApagarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new FilmeCommandResult(false, "Por favor corrija as inconsistências abaixo", command.Notifications);


                _repository.Apagar(command.FilmeId);

                return new FilmeCommandResult(true, "Filme excluído com sucesso!", new { FilmeId = command.FilmeId });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
