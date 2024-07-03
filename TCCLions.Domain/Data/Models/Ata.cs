using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Domain.Data.Models
{
    public class Ata
    {
        public Guid Id {get; private set;} = Guid.NewGuid();
        public string Titulo {get; set;}
        public string Descricao {get; set;}
    
    }
}