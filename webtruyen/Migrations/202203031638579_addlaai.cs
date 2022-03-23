namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlaai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Story_StoryId", c => c.Int());
            AddForeignKey("dbo.Authors", "Story_StoryId", "dbo.Stories", "StoryId");
            CreateIndex("dbo.Authors", "Story_StoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Authors", new[] { "Story_StoryId" });
            DropForeignKey("dbo.Authors", "Story_StoryId", "dbo.Stories");
            DropColumn("dbo.Authors", "Story_StoryId");
        }
    }
}
