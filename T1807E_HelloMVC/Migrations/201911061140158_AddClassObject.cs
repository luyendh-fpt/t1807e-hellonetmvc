namespace T1807E_HelloMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassObject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassObjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClassObjects");
        }
    }
}
