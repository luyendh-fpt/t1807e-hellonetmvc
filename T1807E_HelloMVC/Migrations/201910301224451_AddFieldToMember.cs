namespace T1807E_HelloMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldToMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "CreatedAt", c => c.Long(nullable: false));
            AddColumn("dbo.Members", "UpdatedAt", c => c.Long(nullable: false));
            AddColumn("dbo.Members", "DeletedAt", c => c.Long(nullable: false));
            AddColumn("dbo.Members", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Status");
            DropColumn("dbo.Members", "DeletedAt");
            DropColumn("dbo.Members", "UpdatedAt");
            DropColumn("dbo.Members", "CreatedAt");
        }
    }
}
