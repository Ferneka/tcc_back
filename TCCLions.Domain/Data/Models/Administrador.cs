using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Domain.Data.Models
{
    public class Administrador : BaseEntity
    {
        public string AdminLogin {get; set;}
        public string AdminSenha {get; set;}
    }
}