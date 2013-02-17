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
            if (context.Tags.Count() == 0)
            {
                seedTags().ForEach(tag => context.Tags.Add(tag));
            }
            if (context.Articles.Count() == 0)
            {
                seedArticles().ForEach(article => context.Articles.Add(article));
            }
            if(context.StaticPages.Count() == 0)
            {
                seedPages().ForEach(page => context.StaticPages.Add(page));
            }
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
            if (!Roles.RoleExists("User"))
            {
                Roles.CreateRole("User");
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

        private List<StaticPage> seedPages()
        {
            var pages = new List<StaticPage> {
                new StaticPage
                {
                    PageId       = 1,
                    title        = "Actualités",
                    content      = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras malesuada laoreet ultrices. Aenean in justo sed massa mollis accumsan ut vitae nunc. Mauris gravida, sem at auctor scelerisque, leo sapien posuere augue, et cursus diam odio at nulla. Sed nisl arcu, varius ut vestibulum vel, mattis at massa. Mauris vitae elit neque, vitae eleifend sapien. Duis felis augue, ultrices sit amet molestie a, luctus dapibus nisi. Aliquam nunc risus, hendrerit et cursus bibendum, cursus vitae magna. Quisque luctus nisl scelerisque enim congue iaculis. Praesent varius quam id dolor ornare placerat. Donec quis sem magna, eu faucibus quam. Duis a quam leo, sit amet fringilla nunc. Ut blandit, erat et vulputate tempus, risus turpis eleifend ipsum, nec fringilla leo neque eu sem.Integer imperdiet tempor volutpat. Phasellus rhoncus erat et libero luctus non fringilla orci mattis. In hac habitasse platea dictumst. Proin vel metus magna. Nulla eget ipsum mi. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla quis dolor sit amet purus placerat bibendum. Integer vel turpis odio. Vestibulum tortor sem, accumsan ut sodales ac, ullamcorper non turpis. Vivamus gravida suscipit metus vitae condimentum. Curabitur at ultricies felis. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed ultricies gravida magna eget elementum. Duis sagittis commodo molestie. In tincidunt sagittis orci sit amet malesuada.Proin laoreet elit vel sapien commodo auctor. Nunc feugiat tristique nulla ullamcorper bibendum. Aenean bibendum vestibulum congue. Nunc in ligula pretium nibh molestie blandit sed id nulla. Ut elementum scelerisque ante, vitae tempus libero malesuada malesuada. In at ipsum nulla, ac eleifend sem. Maecenas eget felis sit amet lorem tristique blandit. Sed scelerisque turpis nec diam auctor elementum eget et erat. Suspendisse non semper nulla. Vestibulum eget risus lorem. Fusce a eros lectus. Suspendisse eget mi in felis faucibus interdum. Mauris id diam at est vehicula feugiat sed dignissim turpis.Nam ornare est augue. Nunc eu blandit libero. Phasellus sagittis magna sit amet massa convallis adipiscing. Maecenas in diam pellentesque eros auctor malesuada. Vivamus accumsan mauris nec arcu pulvinar ornare sed eget mi. Integer congue felis id orci malesuada sed pulvinar augue tincidunt. Quisque volutpat dapibus nunc ut scelerisque. Maecenas at sodales velit. Maecenas dui ipsum, tincidunt et condimentum in, gravida porttitor magna. Donec vel nulla non mi scelerisque ultricies eu in lectus. Donec eget lectus sagittis nunc hendrerit consectetur sit amet ut orci. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Vivamus egestas vulputate est.Proin nisl urna, eleifend sit amet tincidunt at, pulvinar ac dolor. Ut at augue in enim imperdiet congue sit amet a velit. Proin velit sapien, lobortis sed volutpat eu, mattis ut risus. Vivamus eget diam ipsum, id tristique metus. Morbi dictum fringilla massa, id pellentesque metus congue sed. In hac habitasse platea dictumst. Cras ultrices imperdiet augue ac dignissim. Donec luctus ante turpis. In ultrices sem ut leo convallis fermentum. Sed posuere mattis felis, non pulvinar nibh gravida a. Vivamus quis laoreet quam. "
                },
                new StaticPage
                {
                    PageId       = 2,
                    title        = "Sports",
                    content      = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras malesuada laoreet ultrices. Aenean in justo sed massa mollis accumsan ut vitae nunc. Mauris gravida, sem at auctor scelerisque, leo sapien posuere augue, et cursus diam odio at nulla. Sed nisl arcu, varius ut vestibulum vel, mattis at massa. Mauris vitae elit neque, vitae eleifend sapien. Duis felis augue, ultrices sit amet molestie a, luctus dapibus nisi. Aliquam nunc risus, hendrerit et cursus bibendum, cursus vitae magna. Quisque luctus nisl scelerisque enim congue iaculis. Praesent varius quam id dolor ornare placerat. Donec quis sem magna, eu faucibus quam. Duis a quam leo, sit amet fringilla nunc. Ut blandit, erat et vulputate tempus, risus turpis eleifend ipsum, nec fringilla leo neque eu sem.Integer imperdiet tempor volutpat. Phasellus rhoncus erat et libero luctus non fringilla orci mattis. In hac habitasse platea dictumst. Proin vel metus magna. Nulla eget ipsum mi. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla quis dolor sit amet purus placerat bibendum. Integer vel turpis odio. Vestibulum tortor sem, accumsan ut sodales ac, ullamcorper non turpis. Vivamus gravida suscipit metus vitae condimentum. Curabitur at ultricies felis. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed ultricies gravida magna eget elementum. Duis sagittis commodo molestie. In tincidunt sagittis orci sit amet malesuada.Proin laoreet elit vel sapien commodo auctor. Nunc feugiat tristique nulla ullamcorper bibendum. Aenean bibendum vestibulum congue. Nunc in ligula pretium nibh molestie blandit sed id nulla. Ut elementum scelerisque ante, vitae tempus libero malesuada malesuada. In at ipsum nulla, ac eleifend sem. Maecenas eget felis sit amet lorem tristique blandit. Sed scelerisque turpis nec diam auctor elementum eget et erat. Suspendisse non semper nulla. Vestibulum eget risus lorem. Fusce a eros lectus. Suspendisse eget mi in felis faucibus interdum. Mauris id diam at est vehicula feugiat sed dignissim turpis.Nam ornare est augue. Nunc eu blandit libero. Phasellus sagittis magna sit amet massa convallis adipiscing. Maecenas in diam pellentesque eros auctor malesuada. Vivamus accumsan mauris nec arcu pulvinar ornare sed eget mi. Integer congue felis id orci malesuada sed pulvinar augue tincidunt. Quisque volutpat dapibus nunc ut scelerisque. Maecenas at sodales velit. Maecenas dui ipsum, tincidunt et condimentum in, gravida porttitor magna. Donec vel nulla non mi scelerisque ultricies eu in lectus. Donec eget lectus sagittis nunc hendrerit consectetur sit amet ut orci. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Vivamus egestas vulputate est.Proin nisl urna, eleifend sit amet tincidunt at, pulvinar ac dolor. Ut at augue in enim imperdiet congue sit amet a velit. Proin velit sapien, lobortis sed volutpat eu, mattis ut risus. Vivamus eget diam ipsum, id tristique metus. Morbi dictum fringilla massa, id pellentesque metus congue sed. In hac habitasse platea dictumst. Cras ultrices imperdiet augue ac dignissim. Donec luctus ante turpis. In ultrices sem ut leo convallis fermentum. Sed posuere mattis felis, non pulvinar nibh gravida a. Vivamus quis laoreet quam. "
                },
                new StaticPage
                {
                    PageId       = 3,
                    title        = "Sarkozy est de retour !",
                    content      = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras malesuada laoreet ultrices. Aenean in justo sed massa mollis accumsan ut vitae nunc. Mauris gravida, sem at auctor scelerisque, leo sapien posuere augue, et cursus diam odio at nulla. Sed nisl arcu, varius ut vestibulum vel, mattis at massa. Mauris vitae elit neque, vitae eleifend sapien. Duis felis augue, ultrices sit amet molestie a, luctus dapibus nisi. Aliquam nunc risus, hendrerit et cursus bibendum, cursus vitae magna. Quisque luctus nisl scelerisque enim congue iaculis. Praesent varius quam id dolor ornare placerat. Donec quis sem magna, eu faucibus quam. Duis a quam leo, sit amet fringilla nunc. Ut blandit, erat et vulputate tempus, risus turpis eleifend ipsum, nec fringilla leo neque eu sem.Integer imperdiet tempor volutpat. Phasellus rhoncus erat et libero luctus non fringilla orci mattis. In hac habitasse platea dictumst. Proin vel metus magna. Nulla eget ipsum mi. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla quis dolor sit amet purus placerat bibendum. Integer vel turpis odio. Vestibulum tortor sem, accumsan ut sodales ac, ullamcorper non turpis. Vivamus gravida suscipit metus vitae condimentum. Curabitur at ultricies felis. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed ultricies gravida magna eget elementum. Duis sagittis commodo molestie. In tincidunt sagittis orci sit amet malesuada.Proin laoreet elit vel sapien commodo auctor. Nunc feugiat tristique nulla ullamcorper bibendum. Aenean bibendum vestibulum congue. Nunc in ligula pretium nibh molestie blandit sed id nulla. Ut elementum scelerisque ante, vitae tempus libero malesuada malesuada. In at ipsum nulla, ac eleifend sem. Maecenas eget felis sit amet lorem tristique blandit. Sed scelerisque turpis nec diam auctor elementum eget et erat. Suspendisse non semper nulla. Vestibulum eget risus lorem. Fusce a eros lectus. Suspendisse eget mi in felis faucibus interdum. Mauris id diam at est vehicula feugiat sed dignissim turpis.Nam ornare est augue. Nunc eu blandit libero. Phasellus sagittis magna sit amet massa convallis adipiscing. Maecenas in diam pellentesque eros auctor malesuada. Vivamus accumsan mauris nec arcu pulvinar ornare sed eget mi. Integer congue felis id orci malesuada sed pulvinar augue tincidunt. Quisque volutpat dapibus nunc ut scelerisque. Maecenas at sodales velit. Maecenas dui ipsum, tincidunt et condimentum in, gravida porttitor magna. Donec vel nulla non mi scelerisque ultricies eu in lectus. Donec eget lectus sagittis nunc hendrerit consectetur sit amet ut orci. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Vivamus egestas vulputate est.Proin nisl urna, eleifend sit amet tincidunt at, pulvinar ac dolor. Ut at augue in enim imperdiet congue sit amet a velit. Proin velit sapien, lobortis sed volutpat eu, mattis ut risus. Vivamus eget diam ipsum, id tristique metus. Morbi dictum fringilla massa, id pellentesque metus congue sed. In hac habitasse platea dictumst. Cras ultrices imperdiet augue ac dignissim. Donec luctus ante turpis. In ultrices sem ut leo convallis fermentum. Sed posuere mattis felis, non pulvinar nibh gravida a. Vivamus quis laoreet quam. "
                },
                new StaticPage
                {
                    PageId       = 4,
                    title        = "A propos",
                    content      = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras malesuada laoreet ultrices. Aenean in justo sed massa mollis accumsan ut vitae nunc. Mauris gravida, sem at auctor scelerisque, leo sapien posuere augue, et cursus diam odio at nulla. Sed nisl arcu, varius ut vestibulum vel, mattis at massa. Mauris vitae elit neque, vitae eleifend sapien. Duis felis augue, ultrices sit amet molestie a, luctus dapibus nisi. Aliquam nunc risus, hendrerit et cursus bibendum, cursus vitae magna. Quisque luctus nisl scelerisque enim congue iaculis. Praesent varius quam id dolor ornare placerat. Donec quis sem magna, eu faucibus quam. Duis a quam leo, sit amet fringilla nunc. Ut blandit, erat et vulputate tempus, risus turpis eleifend ipsum, nec fringilla leo neque eu sem.Integer imperdiet tempor volutpat. Phasellus rhoncus erat et libero luctus non fringilla orci mattis. In hac habitasse platea dictumst. Proin vel metus magna. Nulla eget ipsum mi. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla quis dolor sit amet purus placerat bibendum. Integer vel turpis odio. Vestibulum tortor sem, accumsan ut sodales ac, ullamcorper non turpis. Vivamus gravida suscipit metus vitae condimentum. Curabitur at ultricies felis. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed ultricies gravida magna eget elementum. Duis sagittis commodo molestie. In tincidunt sagittis orci sit amet malesuada.Proin laoreet elit vel sapien commodo auctor. Nunc feugiat tristique nulla ullamcorper bibendum. Aenean bibendum vestibulum congue. Nunc in ligula pretium nibh molestie blandit sed id nulla. Ut elementum scelerisque ante, vitae tempus libero malesuada malesuada. In at ipsum nulla, ac eleifend sem. Maecenas eget felis sit amet lorem tristique blandit. Sed scelerisque turpis nec diam auctor elementum eget et erat. Suspendisse non semper nulla. Vestibulum eget risus lorem. Fusce a eros lectus. Suspendisse eget mi in felis faucibus interdum. Mauris id diam at est vehicula feugiat sed dignissim turpis.Nam ornare est augue. Nunc eu blandit libero. Phasellus sagittis magna sit amet massa convallis adipiscing. Maecenas in diam pellentesque eros auctor malesuada. Vivamus accumsan mauris nec arcu pulvinar ornare sed eget mi. Integer congue felis id orci malesuada sed pulvinar augue tincidunt. Quisque volutpat dapibus nunc ut scelerisque. Maecenas at sodales velit. Maecenas dui ipsum, tincidunt et condimentum in, gravida porttitor magna. Donec vel nulla non mi scelerisque ultricies eu in lectus. Donec eget lectus sagittis nunc hendrerit consectetur sit amet ut orci. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Vivamus egestas vulputate est.Proin nisl urna, eleifend sit amet tincidunt at, pulvinar ac dolor. Ut at augue in enim imperdiet congue sit amet a velit. Proin velit sapien, lobortis sed volutpat eu, mattis ut risus. Vivamus eget diam ipsum, id tristique metus. Morbi dictum fringilla massa, id pellentesque metus congue sed. In hac habitasse platea dictumst. Cras ultrices imperdiet augue ac dignissim. Donec luctus ante turpis. In ultrices sem ut leo convallis fermentum. Sed posuere mattis felis, non pulvinar nibh gravida a. Vivamus quis laoreet quam. "
                }
            };

            return pages;
        }
    }
}