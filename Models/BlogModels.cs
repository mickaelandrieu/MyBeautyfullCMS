using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Web.Security;

namespace Todo.Site.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext()
            : base("Models_")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, DbMigrationsConfiguration<Todo.Site.Models.BlogContext>>());
        }

    }
}
