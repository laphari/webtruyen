namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "imghot", c => c.String());
            AddColumn("dbo.Categories", "trangthai", c => c.String());
            AddColumn("dbo.Categories", "namphathanh", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "namphathanh");
            DropColumn("dbo.Categories", "trangthai");
            DropColumn("dbo.Categories", "imghot");
        }
    }
}
