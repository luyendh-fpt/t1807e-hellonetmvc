namespace T1807E_HelloMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Phone = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        ConfirmPassword = c.String(unicode: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Members", "Password", c => c.String(maxLength: 30, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Password", c => c.String(unicode: false));
            AlterColumn("dbo.Members", "Email", c => c.String(unicode: false));
            DropTable("dbo.Customers");
        }
    }
}
