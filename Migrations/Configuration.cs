namespace Todo.Site.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebMatrix.WebData;
    using System.Web.Security;
    using Todo.Site.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Todo.Site.Models.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Todo.Site.Models.BlogContext context)
        {
            WebSecurity.InitializeDatabaseConnection(
	                "Models_",
	                "UserProfile",
	                "UserId",
	                "UserName", autoCreateTables: true);
	 
	            if (!Roles.RoleExists("Administrator"))
	                Roles.CreateRole("Administrator");

                if (!Roles.RoleExists("Publisher"))
                    Roles.CreateRole("Publisher");
	 
	            if (!WebSecurity.UserExists("admin"))
	                WebSecurity.CreateUserAndAccount(
	                    "admin",
	                    "admin"
	             );

                if (!Roles.GetRolesForUser("admin").Contains("Administrator"))
                    Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Administrator" });
        }
    }
}
