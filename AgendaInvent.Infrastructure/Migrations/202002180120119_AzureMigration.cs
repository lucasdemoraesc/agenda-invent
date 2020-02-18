namespace AgendaInvent.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AzureMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 12),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Phone, unique: true, name: "IX_PHONE");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contact", "IX_PHONE");
            DropTable("dbo.Contact");
        }
    }
}
