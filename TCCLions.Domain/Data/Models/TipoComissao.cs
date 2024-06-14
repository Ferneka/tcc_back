using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Domain.Data.Models
{
    public class TipoComissao : BaseEntity
    {
        public string Descricao {get; set;}
        public Guid IdAdmin {get; set;}
        public Administrador Administrador {get; set;}
    }
}