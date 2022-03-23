namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asddas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "Nxb", c => c.String());
            AddColumn("dbo.Stories", "Ngonngu", c => c.String());
            AddColumn("dbo.Stories", "namsx", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stories", "namsx");
            DropColumn("dbo.Stories", "Ngonngu");
            DropColumn("dbo.Stories", "Nxb");
        }
    }
}
