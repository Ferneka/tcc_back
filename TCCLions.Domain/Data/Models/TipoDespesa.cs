using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Domain.Data.Models
{
    public class TipoDespesa
    {
        public Guid IdTipoDespesa {get; private set;} = Guid.NewGuid();
        public string Descricao {get; set;}
        public Guid IdAdmin {get; set;}
        public Administrador Administrador {get; set;}
    }
}