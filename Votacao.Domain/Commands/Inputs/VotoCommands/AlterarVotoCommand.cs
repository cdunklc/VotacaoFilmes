using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Votacao.Domain.Entidades;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Inputs.Filme
{
    public class AlterarVotoCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long VotoId { get; set; }
        public long UsuarioId { get; set; }
        public long FilmeId { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (VotoId <= 0)
                    AddNotification("VotoId", "VotoId deve ser maior que 0");
                
                if (UsuarioId <= 0)
                    AddNotification("UsuarioId", "UsuarioId deve ser maior que 0");

                if (VotoId <= 0)
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
