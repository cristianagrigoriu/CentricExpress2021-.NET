using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Flights.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Initial Catalog=Flights;Integrated Security=true;MultipleActiveResultSets=True");
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
