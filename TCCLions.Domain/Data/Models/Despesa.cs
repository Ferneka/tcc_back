using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Domain.Data.Models
{
    public class Despesa 
    {
        public Guid Id {get; private set;} = Guid.NewGuid();
        public DateTime DataVencimento {get; set;}
        public DateTime DataRegistro {get; set;}
        public Guid IdMembro {get; set;}
        public Membro Membro {get; set;}

        public void Update()
        {

        }
    }
}