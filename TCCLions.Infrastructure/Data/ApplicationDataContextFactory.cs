using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TCCLions.Infrastructure.Data
{
    public class ApplicationDataContextFactory : IDesignTimeDbContextFactory<ApplicationDataContext>
    {
        public ApplicationDataContext CreateDbContext(string[] args){
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDataContext>();
            optionsBuilder.UseSqlite("Data Source = tcclionsapi.db");

            return new ApplicationDataContext(optionsBuilder.Options);
        }
    }
}