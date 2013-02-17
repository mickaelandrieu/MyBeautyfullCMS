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
            seedArticles().ForEach(article => context.Articles.Add(article));
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

        private List<Article> seedArticles()
        {
            var articles = new List<Article> {
                new Article
                {
                    ArticleId    = 1,
                    title        = "Viande de cheval : tour d'Europe des produits concernés",
                    introduction = "Une dizaine de pays européens sont touchés à des degrés divers par le scandale de la viande de cheval vendue pour du bœuf.",
                    content      = "Les Européens vont procéder à plusieurs milliers de tests sur des plats censés être préparés à base de boeuf pour vérifier s'ils contiennent du cheval alors que le scandale s'étend à de nouveaux pays et que la société française Spanghero, mise en cause par Paris, clame son innocence. Tour d’Europe des produits concernés par le ''horsegate''.L'Europe entière déguste...C’est en Irlande et en Grande-Bretagne qu’ont été détectées mi-janvier les premières traces de viande de cheval dans des hamburgers. Le 7 février, l’agence britannique de sécurité alimentaire annonce que des lasagnes, distribuées par la marque de surgelés Findus contiennent en réalité plus de 60% de viande de cheval.En Suède, le géant de l’agroalimentaire Findus rappelle des plats de lasagnes surgelées. Des grandes chaînes de supermarchés retirent également de la vente des produits provenant du fournisseur Comigel.En Allemagne, en Suisse et en Norvège, plusieurs chaînes de magasins lancent une série de tests. Les groupes de distribution Real, Coop et NorgesGruppen détectent la présence de viande chevaline dans des lasagnes surgelées qui sont aussitôt retirées des étals.Tortellinis, pizzas...En Autriche, c’est dans les tortellinis viande de bœuf, distribuées par la chaîne allemande Lidl que des traces de viande de cheval sont détectées.Au Danemark, une enquête est en cours sur un abattoir qui pourrait avoir introduit du cheval dans de la viande présentée comme du bœuf, destinée à des fabricants de pizza. Enfin, au Pays-Bas, une perquisition a été menée dans une usine qui mélangeait viande de cheval et de bœuf avant de la revendre labellisée ''pur bœuf''.",
                    UserId       = 1,
                    TagId        = 2,
                    status       = true
                },
                new Article
                {
                    ArticleId    = 2,
                    title        = "Viande de cheval : tour d'Europe des produits concernés",
                    introduction = "Une dizaine de pays européens sont touchés à des degrés divers par le scandale de la viande de cheval vendue pour du bœuf.",
                    content      = "Les Européens vont procéder à plusieurs milliers de tests sur des plats censés être préparés à base de boeuf pour vérifier s'ils contiennent du cheval alors que le scandale s'étend à de nouveaux pays et que la société française Spanghero, mise en cause par Paris, clame son innocence. Tour d’Europe des produits concernés par le ''horsegate''.L'Europe entière déguste...C’est en Irlande et en Grande-Bretagne qu’ont été détectées mi-janvier les premières traces de viande de cheval dans des hamburgers. Le 7 février, l’agence britannique de sécurité alimentaire annonce que des lasagnes, distribuées par la marque de surgelés Findus contiennent en réalité plus de 60% de viande de cheval.En Suède, le géant de l’agroalimentaire Findus rappelle des plats de lasagnes surgelées. Des grandes chaînes de supermarchés retirent également de la vente des produits provenant du fournisseur Comigel.En Allemagne, en Suisse et en Norvège, plusieurs chaînes de magasins lancent une série de tests. Les groupes de distribution Real, Coop et NorgesGruppen détectent la présence de viande chevaline dans des lasagnes surgelées qui sont aussitôt retirées des étals.Tortellinis, pizzas...En Autriche, c’est dans les tortellinis viande de bœuf, distribuées par la chaîne allemande Lidl que des traces de viande de cheval sont détectées.Au Danemark, une enquête est en cours sur un abattoir qui pourrait avoir introduit du cheval dans de la viande présentée comme du bœuf, destinée à des fabricants de pizza. Enfin, au Pays-Bas, une perquisition a été menée dans une usine qui mélangeait viande de cheval et de bœuf avant de la revendre labellisée ''pur bœuf''.",
                    UserId       = 1,
                    TagId        = 3,
                    status       = true
                },
                new Article
                {
                    ArticleId    = 3,
                    title        = "Viande de cheval : tour d'Europe des produits concernés",
                    introduction = "Une dizaine de pays européens sont touchés à des degrés divers par le scandale de la viande de cheval vendue pour du bœuf.",
                    content      = "Les Européens vont procéder à plusieurs milliers de tests sur des plats censés être préparés à base de boeuf pour vérifier s'ils contiennent du cheval alors que le scandale s'étend à de nouveaux pays et que la société française Spanghero, mise en cause par Paris, clame son innocence. Tour d’Europe des produits concernés par le ''horsegate''.L'Europe entière déguste...C’est en Irlande et en Grande-Bretagne qu’ont été détectées mi-janvier les premières traces de viande de cheval dans des hamburgers. Le 7 février, l’agence britannique de sécurité alimentaire annonce que des lasagnes, distribuées par la marque de surgelés Findus contiennent en réalité plus de 60% de viande de cheval.En Suède, le géant de l’agroalimentaire Findus rappelle des plats de lasagnes surgelées. Des grandes chaînes de supermarchés retirent également de la vente des produits provenant du fournisseur Comigel.En Allemagne, en Suisse et en Norvège, plusieurs chaînes de magasins lancent une série de tests. Les groupes de distribution Real, Coop et NorgesGruppen détectent la présence de viande chevaline dans des lasagnes surgelées qui sont aussitôt retirées des étals.Tortellinis, pizzas...En Autriche, c’est dans les tortellinis viande de bœuf, distribuées par la chaîne allemande Lidl que des traces de viande de cheval sont détectées.Au Danemark, une enquête est en cours sur un abattoir qui pourrait avoir introduit du cheval dans de la viande présentée comme du bœuf, destinée à des fabricants de pizza. Enfin, au Pays-Bas, une perquisition a été menée dans une usine qui mélangeait viande de cheval et de bœuf avant de la revendre labellisée ''pur bœuf''.",
                    UserId       = 1,
                    TagId        = 1,
                    status       = true
                }
            };

            return articles;
        }
    }
}