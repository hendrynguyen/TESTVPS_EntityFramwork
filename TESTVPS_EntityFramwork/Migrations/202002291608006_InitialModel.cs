namespace TESTVPS_EntityFramwork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VPS_Information",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IP_Address = c.String(),
                        User_Name = c.String(),
                        Pass_Word = c.String(),
                        Country = c.String(),
                        Brought_Date = c.DateTime(),
                        Expiration_Date = c.DateTime(),
                        Put_Some_Notes = c.String(),
                        VPS_Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VPS_Information");
        }
    }
}
