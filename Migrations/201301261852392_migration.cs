namespace Todo.Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        createdAt = c.DateTime(nullable: false),
                        title = c.String(nullable: false, maxLength: 4000),
                        introduction = c.String(maxLength: 4000),
                        content = c.String(nullable: false, maxLength: 4000),
                        status = c.Boolean(nullable: false),
                        TagId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.StaticPage",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        createdAt = c.DateTime(nullable: false),
                        title = c.String(nullable: false, maxLength: 4000),
                        content = c.String(nullable: false, maxLength: 4000),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PageId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Article", new[] { "UserId" });
            DropIndex("dbo.Article", new[] { "TagId" });
            DropForeignKey("dbo.Article", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Article", "TagId", "dbo.Tag");
            DropTable("dbo.StaticPage");
            DropTable("dbo.Tag");
            DropTable("dbo.Article");
            DropTable("dbo.UserProfile");
        }
    }
}
