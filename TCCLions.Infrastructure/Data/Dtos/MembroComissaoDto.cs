using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Infrastructure.Data.Dtos
{
    public class MembroComissaoDto
    {
        public Guid Id {get; set;} 
        public Guid IdMembro {get; set;}
        public Guid IdComissao {get; set;}
        public string DataInicio {get; set;}
        public string DataFim {get; set;}
    }
}