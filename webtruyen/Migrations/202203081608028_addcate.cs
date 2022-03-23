namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "idcate", c => c.Int());
            AddForeignKey("dbo.Stories", "idcate", "dbo.Categories", "CategoryId");
            CreateIndex("dbo.Stories", "idcate");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Stories", new[] { "idcate" });
            DropForeignKey("dbo.Stories", "idcate", "dbo.Categories");
            DropColumn("dbo.Stories", "idcate");
        }
    }
}
