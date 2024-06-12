using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Api.Application
{
    public class TipoComissaoViewModel
    {
        public Guid IdTipoComissao {get; set;}
        public string Descricao {get; set;}
        public Guid IdAdmin {get; set;}
    }
}