using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacao.Domain.Query
{
    public class UsuarioQueryResult
    {
        public long UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }        
    }
}
