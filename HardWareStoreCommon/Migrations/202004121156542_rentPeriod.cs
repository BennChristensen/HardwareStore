namespace HardwareStoreCommon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentPeriod : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "RentPeriod");
            AddColumn("dbo.Bookings", "RentPeriod", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "RentPeriod");
            AddColumn("dbo.Bookings", "RentPeriod", c => c.Time());
        }
    }
}
