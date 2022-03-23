namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddddf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anhbias", "motaveanhbia", c => c.String());
            AddColumn("dbo.Anhbias", "ngaytao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Anhbias", "ngaytao");
            DropColumn("dbo.Anhbias", "motaveanhbia");
        }
    }
}
