using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Domain.Data.Models
{
    public class DespesaTipoDespesa : BaseEntity
    {
        public Guid IdDespesa {get; set;}
        public Despesa Despesa {get; set;}
        public Guid IdTipoDespesa {get; set;}
        public TipoDespesa TipoDespesa {get; set;}
        public double Valor {get; set;}

        
    }
}