using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;
using TCCLions.Infrastructure.Data.Dtos;

namespace TCCLions.Infrastructure.Data.Repositories
{
    public class AdministradorRepository : RepositoryBase<Administrador>, IAdministradorRepository
    {
        public AdministradorRepository(ApplicationDataContext context) : base(context)
        {
            
        }
    }
}