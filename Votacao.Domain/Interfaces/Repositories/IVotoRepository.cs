using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votacao.Domain.Entidades;
using Votacao.Domain.Query;

namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IVotoRepository
    {
        long Inserir(Voto voto);
        void Atualizar(Voto voto);
        void Apagar(long id);
        List<VotoQueryResult> Listar();
        VotoQueryResult Obter(long id);
        bool CheckId(long id);
    }
}
