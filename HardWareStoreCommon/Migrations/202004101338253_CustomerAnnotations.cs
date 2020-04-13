namespace HardwareStoreCommon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "UserName", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
