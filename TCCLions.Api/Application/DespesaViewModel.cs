
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Api.Application
{
    public class DespesaViewModel
    {
        public Guid IdDespesa {get; set;} 
        public string DataVencimento {get; set;}
        public string DataRegistro {get; set;}
        public double ValorTotal {get; set;}
        public Guid IdMembro {get; set;}
        public Guid IdAdmim {get; set;}
    }
}