namespace HardwareStoreCommon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexOnUserName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "UserName", c => c.String(nullable: false, maxLength: 200));
            CreateIndex("dbo.Customers", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "UserName" });
            AlterColumn("dbo.Customers", "UserName", c => c.String(nullable: false));
        }
    }
}
