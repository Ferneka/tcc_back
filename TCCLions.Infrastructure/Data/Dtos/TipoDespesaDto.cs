using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Infrastructure.Data.Dtos
{
    public class TipoDespesaDto
    {
        public Guid IdTipoDespesa {get; set;} 
        public string Descricao {get; set;}
    }
}