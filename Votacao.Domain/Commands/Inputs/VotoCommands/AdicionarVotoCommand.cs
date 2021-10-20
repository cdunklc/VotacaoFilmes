using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votacao.Domain.Entidades;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Inputs.VotoCommands
{
    public class AdicionarVotoCommand : Notifiable, ICommandPadrao
    {
        public long UsuarioId { get; set; }
        public long FilmeId { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (UsuarioId <= 0)
                    AddNotification("UsuarioId", "UsuarioId deve ser maior que 0");

                if (FilmeId <= 0)
                    AddNotification("UsuarioId", "UsuarioId é um campo obrigatório");


                return Valid;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
