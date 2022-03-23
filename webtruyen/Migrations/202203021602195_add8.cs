namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "Storyauthor", c => c.String());
            AddColumn("dbo.Stories", "Storycate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stories", "Storycate");
            DropColumn("dbo.Stories", "Storyauthor");
        }
    }
}
