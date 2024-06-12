using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Infrastructure.Data.Dtos
{
    public class AtaDto
    {
        public Guid Id {get; set;}
        public string Titulo {get; set;}
        public string Descricao {get; set;}
        public Guid IdAdmin {get; set;}
    }
}