using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacao.Domain.Entidades
{
    public class Filme
    {
        public long FilmeId { get; private set; }
        public string Titulo { get; private set; }
        public string Diretor { get; private set; }

        public Filme(long filmeId, string titulo, string diretor)
        {
            FilmeId = filmeId;
            Titulo = titulo;
            Diretor = diretor;
        }
    }
}
