using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Inputs
{
    public class ApagarUsuarioCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long UsuarioId { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (UsuarioId <= 0)
                    AddNotification("UsuarioId", "UsuarioId deve ser maior que 0");                

                return Valid;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
