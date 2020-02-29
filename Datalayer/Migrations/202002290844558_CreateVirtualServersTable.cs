namespace Datalayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateVirtualServersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VirtualServers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDateTime = c.DateTime(nullable: false),
                        RemovedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VirtualServers");
        }
    }
}
