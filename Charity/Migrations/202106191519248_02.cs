namespace Charity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Delivered",
                c => new
                    {
                        DeliveryID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        PickUpAddress = c.String(),
                        Clothes = c.Boolean(nullable: false),
                        Food = c.Boolean(nullable: false),
                        TotalQTY = c.Int(nullable: false),
                        image = c.Binary(),
                        status = c.String(),
                        OrganisationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeliveryID)
                .ForeignKey("dbo.Organisation", t => t.OrganisationId, cascadeDelete: true)
                .Index(t => t.OrganisationId);
            
            CreateTable(
                "dbo.Delivery",
                c => new
                    {
                        DeliveryID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        PickUpAddress = c.String(),
                        Clothes = c.Boolean(nullable: false),
                        Food = c.Boolean(nullable: false),
                        TotalQTY = c.Int(nullable: false),
                        image = c.Binary(),
                        status = c.String(),
                        OrganisationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeliveryID)
                .ForeignKey("dbo.Organisation", t => t.OrganisationId, cascadeDelete: true)
                .Index(t => t.OrganisationId);
            
            CreateTable(
                "dbo.OnRoute",
                c => new
                    {
                        DeliveryID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        PickUpAddress = c.String(),
                        Clothes = c.Boolean(nullable: false),
                        Food = c.Boolean(nullable: false),
                        TotalQTY = c.Int(nullable: false),
                        image = c.Binary(),
                        status = c.String(),
                        OrganisationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeliveryID)
                .ForeignKey("dbo.Organisation", t => t.OrganisationId, cascadeDelete: true)
                .Index(t => t.OrganisationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OnRoute", "OrganisationId", "dbo.Organisation");
            DropForeignKey("dbo.Delivery", "OrganisationId", "dbo.Organisation");
            DropForeignKey("dbo.Delivered", "OrganisationId", "dbo.Organisation");
            DropIndex("dbo.OnRoute", new[] { "OrganisationId" });
            DropIndex("dbo.Delivery", new[] { "OrganisationId" });
            DropIndex("dbo.Delivered", new[] { "OrganisationId" });
            DropTable("dbo.OnRoute");
            DropTable("dbo.Delivery");
            DropTable("dbo.Delivered");
        }
    }
}
