namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stories", "idcate", "dbo.Categories");
            DropForeignKey("dbo.Stories", "idau", "dbo.Authors");
            DropIndex("dbo.Stories", new[] { "idcate" });
            DropIndex("dbo.Stories", new[] { "idau" });
            DropColumn("dbo.Stories", "idcate");
            DropColumn("dbo.Stories", "idau");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stories", "idau", c => c.Int(nullable: false));
            AddColumn("dbo.Stories", "idcate", c => c.Int(nullable: false));
            CreateIndex("dbo.Stories", "idau");
            CreateIndex("dbo.Stories", "idcate");
            AddForeignKey("dbo.Stories", "idau", "dbo.Authors", "AuthorId", cascadeDelete: true);
            AddForeignKey("dbo.Stories", "idcate", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
    }
}
