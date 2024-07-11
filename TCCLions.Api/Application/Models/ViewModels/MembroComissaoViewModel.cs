using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Api.Application.Models.ViewModels
{
    public class MembroComissaoViewModel
    {
        public Guid Id {get; set;} 
        public Guid IdMembro {get; set;}
        public Guid IdComissao {get; set;}
        public string DataInicio {get; set;}
        public string DataFim {get; set;}
    }
}