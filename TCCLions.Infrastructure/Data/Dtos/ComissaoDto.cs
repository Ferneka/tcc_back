using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Infrastructure.Data.Dtos
{
    public class ComissaoDto
    {
        public Guid IdComissao {get; set;}
        public Guid IdTipoComissao {get; set;}
        public Guid IdAdmin {get; set;}
    }
}