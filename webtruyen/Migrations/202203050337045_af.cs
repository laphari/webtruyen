namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class af : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authors", "Story_StoryId", "dbo.Stories");
            DropIndex("dbo.Authors", new[] { "Story_StoryId" });
            AddColumn("dbo.Stories", "idtacgia", c => c.Int());
            AddForeignKey("dbo.Stories", "idtacgia", "dbo.Authors", "AuthorId");
            CreateIndex("dbo.Stories", "idtacgia");
            DropColumn("dbo.Authors", "Story_StoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Story_StoryId", c => c.Int());
            DropIndex("dbo.Stories", new[] { "idtacgia" });
            DropForeignKey("dbo.Stories", "idtacgia", "dbo.Authors");
            DropColumn("dbo.Stories", "idtacgia");
            CreateIndex("dbo.Authors", "Story_StoryId");
            AddForeignKey("dbo.Authors", "Story_StoryId", "dbo.Stories", "StoryId");
        }
    }
}
