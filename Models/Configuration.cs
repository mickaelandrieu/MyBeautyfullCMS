using System.Data.Entity.Migrations;
using WebMatrix.WebData;
using Todo.Site.Models;
using System.Web.Security;
using System.Linq;
using System.Collections.Generic;


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
            enableMemberShip();
            seedTags().ForEach(tag => context.Tags.Add(tag));
        }

        private void enableMemberShip()
        {
            try
            {
                WebSecurity.InitializeDatabaseConnection("Models_", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }
            catch (System.Exception ex)
            {

            }

            if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");
            }
            if (!WebSecurity.UserExists("administrateur"))
            {
                WebSecurity.CreateUserAndAccount("administrateur", "secret");
            }

            if (!Roles.GetRolesForUser("administrateur").Contains("Administrator"))
            {
                Roles.AddUsersToRoles(new[] { "administrateur" }, new[] { "Administrator" });
            }
            if (!Roles.RoleExists("Publisher"))
            {
                Roles.CreateRole("Publisher");
            }
            if (!WebSecurity.UserExists("editeur"))
            {
                WebSecurity.CreateUserAndAccount("editeur", "editeur");
            }

            if (!Roles.GetRolesForUser("editeur").Contains("Publisher"))
            {
                Roles.AddUsersToRoles(new[] { "editeur" }, new[] { "Publisher" });
            }
        }

        private List<Tag> seedTags()
        {
            var tags = new List<Tag> {
                new Tag
                {
                    TagId = 0,
                    title = "Non Catégorisé"
                },
                new Tag
                {
                    TagId = 1,
                    title = "Science Fiction"
                },
                new Tag
                {
                    TagId = 2,
                    title = "Sports"
                },
                new Tag
                {
                    TagId = 3,
                    title = "Actualités"
                },
                new Tag
                {
                    TagId = 4,
                    title = "High Tech'"
                },
            };

            return tags;
        }
    }
}