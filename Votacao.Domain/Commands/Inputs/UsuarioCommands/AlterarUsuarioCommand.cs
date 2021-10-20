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
    public class AlterarUsuarioCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if(UsuarioId <= 0)
                    AddNotification("UsuarioId", "UsuarioId deve ser maior que 0");

                if (string.IsNullOrWhiteSpace(Nome))
                    AddNotification("Nome", "Nome é um campo obrigatório");
                else if (Nome.Length > 50)
                    AddNotification("Nome", "Nome maior que 50 caracteres");

                if (string.IsNullOrWhiteSpace(Login))
                    AddNotification("Login", "Login é um campo obrigatório");
                else if (Nome.Length > 15)
                    AddNotification("Login", "Login maior que 15 caracteres");

                if (string.IsNullOrWhiteSpace(Senha))
                    AddNotification("Senha", "Senha é um campo obrigatório");
                else if (Senha.Length > 15)
                    AddNotification("Senha", "Login maior que 20 caracteres");

                return Valid;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
