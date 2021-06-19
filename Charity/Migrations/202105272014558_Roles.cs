namespace Charity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "UserType", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Region", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Region");
            DropColumn("dbo.AspNetUsers", "UserType");
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}
