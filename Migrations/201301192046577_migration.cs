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
                        Id = c.Int(nullable: false, identity: true),
                        createdAt = c.DateTime(nullable: false),
                        title = c.String(nullable: false, maxLength: 4000),
                        introduction = c.String(maxLength: 4000),
                        content = c.String(nullable: false, maxLength: 4000),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Page",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        createdAt = c.DateTime(nullable: false),
                        title = c.String(nullable: false, maxLength: 4000),
                        content = c.String(nullable: false, maxLength: 4000),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Page");
            DropTable("dbo.Article");
            DropTable("dbo.UserProfile");
        }
    }
}
