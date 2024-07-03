using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Domain.Data.Models
{
    public class Despesa 
    {
        public Guid Id {get; private set;} = Guid.NewGuid();
        public string DataVencimento {get; set;}
        public string DataRegistro {get; set;}
        public double ValorTotal {get; set;}
        public Guid IdMembro {get; set;}
        public Membro Membro {get; set;}
    }
}