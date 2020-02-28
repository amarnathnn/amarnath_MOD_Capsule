using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOD.TechnologyService.DBContexts;
using MOD.UserService;

namespace MOD.XUnitTestProject
{
    public static class DbContextMocker
    {
        public static UserContext GetUserContext()
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<UserContext>()
                  .UseSqlServer("Data Source=DOTNET;Initial Catalog=MODDB;User ID=sa;Password=pass@word1;")
                  .Options;

            // Create instance of DbContext
            var dbContext = new UserContext(options);

            // Add entities in memory
           // dbContext.Seed();

            return dbContext;
        }
        public static TechnologyContext GetTechnologyContext()
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<TechnologyContext>()
                  .UseSqlServer("Data Source=DOTNET;Initial Catalog=MODDB;User ID=sa;Password=pass@word1;")
                  .Options;

            // Create instance of DbContext
            var dbContext = new TechnologyContext(options);

            // Add entities in memory
            // dbContext.Seed();

            return dbContext;
        }
    }

}
