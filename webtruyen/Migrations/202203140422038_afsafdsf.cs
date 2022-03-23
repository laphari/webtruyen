namespace webtruyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afsafdsf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anhbias",
                c => new
                    {
                        Idanhbia = c.Int(nullable: false, identity: true),
                        Nameanhbia = c.String(),
                        Imgbia = c.String(),
                    })
                .PrimaryKey(t => t.Idanhbia);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Anhbias");
        }
    }
}
