using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacao.Infra.Interfaces.Commands
{
    public interface ICommandResult
    {
        bool Sucess { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}
