using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Api.Application
{
    public class DespesaTipoDespesa
    {
        public Guid IdDespesaTipoDespesa {get;set;}
        public Guid IdDespesa {get; set;}
        public Guid IdTipoDespesa {get; set;}
        public double Valor {get; set;}
    }
}