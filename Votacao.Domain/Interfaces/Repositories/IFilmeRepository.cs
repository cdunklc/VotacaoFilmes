using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votacao.Domain.Entidades;
using Votacao.Domain.Query;

namespace Votacao.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository
    {
        long Inserir(Filme filme);
        void Atualizar(Filme filme);
        void Apagar(long id);
        List<FilmeQueryResult> Listar();
        FilmeQueryResult Obter(long id);
        bool CheckId(long id);
    }
}
