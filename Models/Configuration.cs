using System.Data.Entity.Migrations;

namespace Todo.Site.Models
{
    public class Configuration : DbMigrationsConfiguration<BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}