using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Infrastructure.Data.Dtos
{
    public class MembroDto
    {
        public Guid IdMembro {get; set;}
        public string Nome {get; set;}
        public string Endereco {get; set;}
        public string Bairro {get; set;}
        public string Cidade {get; set;}
        public string Cep {get; set;}
        public string Email {get; set;}
        public string EstadoCivil {get; set;}
        public string CPF {get; set;}
        public Guid IdAdmin {get; set;}
    }
}