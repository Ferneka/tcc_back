using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCLions.Api.Application.Models.ViewModels
{
    public class DespesaTipoDespesaViewModel
    {
        public Guid Id {get;set;}
        public Guid IdDespesa {get; set;}
        public Guid IdTipoDespesa {get; set;}
        public double Valor {get; set;}
    }
}