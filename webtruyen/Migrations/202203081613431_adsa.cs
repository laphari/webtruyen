namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adsa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "imgcate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "imgcate");
        }
    }
}
