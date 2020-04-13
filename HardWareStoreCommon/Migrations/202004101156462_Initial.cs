namespace HardwareStoreCommon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PickUpDate = c.DateTime(nullable: false),
                        RentPeriod = c.Time(nullable: false, precision: 7),
                        Status = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                        Tool_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Tools", t => t.Tool_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Tool_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Deposit = c.Int(nullable: false),
                        PricePerDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Tool_Id", "dbo.Tools");
            DropForeignKey("dbo.Bookings", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Bookings", new[] { "Tool_Id" });
            DropIndex("dbo.Bookings", new[] { "Customer_Id" });
            DropTable("dbo.Tools");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
        }
    }
}
