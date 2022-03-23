namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsfs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anhbias", "IDtheloaibia", c => c.Int());
            AddForeignKey("dbo.Anhbias", "IDtheloaibia", "dbo.Categories", "CategoryId");
            CreateIndex("dbo.Anhbias", "IDtheloaibia");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Anhbias", new[] { "IDtheloaibia" });
            DropForeignKey("dbo.Anhbias", "IDtheloaibia", "dbo.Categories");
            DropColumn("dbo.Anhbias", "IDtheloaibia");
        }
    }
}
