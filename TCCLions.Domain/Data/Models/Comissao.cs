using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Domain.Data.Models
{
    public class Comissao
    {
        public Guid IdComissao {get; private set;} = Guid.NewGuid();
        public Guid IdTipoComissao {get; set;}
        public TipoComissao TipoComissao {get; set;}
        public Guid IdAdmin {get; set;}
        public Administrador Administrador {get; set;}
    }
}