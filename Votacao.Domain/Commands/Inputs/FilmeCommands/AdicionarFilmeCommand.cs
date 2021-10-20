using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Inputs.Filme
{
    public class AdicionarFilmeCommand : Notifiable, ICommandPadrao
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Titulo))
                    AddNotification("Titulo", "Titulo é um campo obrigatório");
                else if (Titulo.Length > 50)
                    AddNotification("Titulo", "Titulo maior que 50 caracteres");

                if (string.IsNullOrWhiteSpace(Diretor))
                    AddNotification("Diretor", "Diretor é um campo obrigatório");
                else if (Diretor.Length > 50)
                    AddNotification("Diretor", "Diretor maior que 50 caracteres");                

                return Valid;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
