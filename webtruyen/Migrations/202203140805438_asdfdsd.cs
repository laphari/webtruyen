namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfdsd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Anhbias", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Anhbias", new[] { "Category_CategoryId" });
            DropColumn("dbo.Anhbias", "IDtheloaibia");
            DropColumn("dbo.Anhbias", "Category_CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Anhbias", "Category_CategoryId", c => c.Int());
            AddColumn("dbo.Anhbias", "IDtheloaibia", c => c.Int());
            CreateIndex("dbo.Anhbias", "Category_CategoryId");
            AddForeignKey("dbo.Anhbias", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
