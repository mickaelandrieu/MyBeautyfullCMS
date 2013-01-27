using System.Data.Entity.Migrations;
using WebMatrix.WebData;
using Todo.Site.Models;
using System.Web.Security;
using System.Linq;


namespace Todo.Site.Models
{
    public class Configuration : DbMigrationsConfiguration<BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Todo.Site.Models.BlogContext context)
        {
            WebSecurity.InitializeDatabaseConnection("Models_", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");
            }

            if (!WebSecurity.UserExists("john"))
            {
                WebSecurity.CreateUserAndAccount("john", "secret");
            }

            if (!Roles.GetRolesForUser("john").Contains("Administrator"))
            {
                Roles.AddUsersToRoles(new[] { "john" }, new[] { "Administrator" });
            }
        }
    }
}