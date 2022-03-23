namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                        AuthorAvatar = c.String(),
                        AuthorDateOfBirth = c.DateTime(nullable: false),
                        AuthorDescription = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryDesctiption = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        StoryId = c.Int(nullable: false, identity: true),
                        StoryName = c.String(),
                        StoryImage = c.String(),
                        StoryDescription = c.String(),
                        StoryIsDone = c.String(),
                        StoryCreated = c.DateTime(nullable: false),
                        StoryUpdated = c.DateTime(nullable: false),
                        StoryDeleted = c.DateTime(nullable: false),
                        idcate = c.Int(nullable: false),
                        idau = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoryId)
                .ForeignKey("dbo.Categories", t => t.idcate, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.idau, cascadeDelete: true)
                .Index(t => t.idcate)
                .Index(t => t.idau);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Stories", new[] { "idau" });
            DropIndex("dbo.Stories", new[] { "idcate" });
            DropForeignKey("dbo.Stories", "idau", "dbo.Authors");
            DropForeignKey("dbo.Stories", "idcate", "dbo.Categories");
            DropTable("dbo.Stories");
            DropTable("dbo.Categories");
            DropTable("dbo.Authors");
        }
    }
}
