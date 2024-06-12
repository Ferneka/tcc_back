using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Infrastructure.Data.Dtos
{
    public class AdministradorDto
    {
        public Guid Id {get; set;} 
        public string AdminLogin {get; set;}
        public string AdminSenha {get; set;}
    }
}