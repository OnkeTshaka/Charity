namespace Charity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coffee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Intro = c.String(nullable: false, maxLength: 120),
                        Body = c.String(),
                        Picture = c.String(),
                        AllowComments = c.Boolean(nullable: false),
                        OnCreated = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Comments = c.String(),
                        ThisDateTime = c.DateTime(),
                        ArticleId = c.Int(nullable: false),
                        Rating = c.Int(),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        EmailAddress = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 10),
                        Message = c.String(nullable: false, maxLength: 500),
                        TimeStamp = c.String(nullable: false),
                        IsReaded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organisation",
                c => new
                    {
                        OrganisationId = c.Int(nullable: false, identity: true),
                        OrganisationName = c.String(nullable: false),
                        OrganisationCity = c.String(nullable: false),
                        OrganisationState = c.String(nullable: false),
                        OrganisationType = c.Int(nullable: false),
                        OrganisationZipCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrganisationId);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        Phone = c.String(maxLength: 100),
                        DonationType = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Blog", "CategoryId", "dbo.Category");
            DropIndex("dbo.Comment", new[] { "Id" });
            DropIndex("dbo.Blog", new[] { "CategoryId" });
            DropTable("dbo.Payment");
            DropTable("dbo.Organisation");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Comment");
            DropTable("dbo.Category");
            DropTable("dbo.Blog");
        }
    }
}
