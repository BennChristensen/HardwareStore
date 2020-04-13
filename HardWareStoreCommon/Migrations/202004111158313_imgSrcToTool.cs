namespace HardwareStoreCommon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgSrcToTool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tools", "ImgSrc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tools", "ImgSrc");
        }
    }
}
