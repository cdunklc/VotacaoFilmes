using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votacao.Domain.Entidades;
using Votacao.Domain.Query;

namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        long Inserir(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Apagar(long id);
        List<UsuarioQueryResult> Listar();
        UsuarioQueryResult Obter(long id);
        bool CheckId(long id);
    }
}
