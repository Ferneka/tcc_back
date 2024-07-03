using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Domain.Data.Models
{
    public class TipoComissao 
    {
        public Guid Id {get; private set;} = Guid.NewGuid();
        public string Descricao {get; set;}
    }
}