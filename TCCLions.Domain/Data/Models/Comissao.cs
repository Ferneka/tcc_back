using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Domain.Data.Models
{
    public class Comissao
    {
        public Guid Id {get; private set;} = Guid.NewGuid();
        public Guid IdTipoComissao {get; set;}
        public TipoComissao TipoComissao {get; set;}
    }
}