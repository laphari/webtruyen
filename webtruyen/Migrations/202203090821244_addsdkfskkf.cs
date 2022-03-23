namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsdkfskkf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "idtacgiaintheloai", c => c.Int());
            AddForeignKey("dbo.Categories", "idtacgiaintheloai", "dbo.Authors", "AuthorId");
            CreateIndex("dbo.Categories", "idtacgiaintheloai");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "idtacgiaintheloai" });
            DropForeignKey("dbo.Categories", "idtacgiaintheloai", "dbo.Authors");
            DropColumn("dbo.Categories", "idtacgiaintheloai");
        }
    }
}
