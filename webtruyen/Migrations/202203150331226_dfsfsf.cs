namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfsfsf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anhbias", "IDtensach", c => c.Int());
            AddForeignKey("dbo.Anhbias", "IDtensach", "dbo.Stories", "StoryId");
            CreateIndex("dbo.Anhbias", "IDtensach");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Anhbias", new[] { "IDtensach" });
            DropForeignKey("dbo.Anhbias", "IDtensach", "dbo.Stories");
            DropColumn("dbo.Anhbias", "IDtensach");
        }
    }
}
