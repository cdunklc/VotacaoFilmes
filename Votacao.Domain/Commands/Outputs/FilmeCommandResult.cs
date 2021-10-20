﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Outputs
{
    public class FilmeCommandResult : ICommandResult
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public FilmeCommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }
    }
}
