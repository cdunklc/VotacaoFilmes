using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votacao.Domain.Entidades;

namespace Votacao.Domain.Query
{
    public class VotoQueryResult
    {
        public long VotoId { get; set; }
        public UsuarioQueryResult Usuario { get; set; }
        public FilmeQueryResult Filme { get; set; }
    }
}
