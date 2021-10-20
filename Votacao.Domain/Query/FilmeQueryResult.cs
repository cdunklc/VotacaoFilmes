using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacao.Domain.Query
{
    public class FilmeQueryResult
    {
        public long FilmeId { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
    }
}
