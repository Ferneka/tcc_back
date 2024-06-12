using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Domain.Data.Models
{
    public class MembroComissao
    {
        public Guid IdMembroComissao {get; private set;} = Guid.NewGuid();
        public Guid IdMembro {get; set;}
        public Membro Membro {get; set;}
        public Guid IdComissao {get; set;}
        public Comissao Comissao {get; set;}
        public string DataInicio {get; set;}
        public string DataFim {get; set;}
        
    }
}