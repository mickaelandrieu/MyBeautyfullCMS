using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;


namespace Todo.Site.Migrations
{
    
    public class Configuration : DbMigrationsConfiguration<Todo.Site.Models.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
