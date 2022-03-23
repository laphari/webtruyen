namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anhbias", "Namest", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Anhbias", "Namest");
        }
    }
}
