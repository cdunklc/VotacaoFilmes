using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Inputs.Filme
{
    public class ApagarFilmeCommand : Notifiable, ICommandPadrao
    {
        public long FilmeId { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (FilmeId <= 0)
                    AddNotification("FilmeId", "FilmeId deve ser maior que 0");

                return Valid;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
