namespace AgendaInvent.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        Email = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_NAME")
                .Index(t => t.Phone, unique: true, name: "IX_PHONE")
                .Index(t => t.Email, unique: true, name: "IX_EMAIL");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contact", "IX_EMAIL");
            DropIndex("dbo.Contact", "IX_PHONE");
            DropIndex("dbo.Contact", "IX_NAME");
            DropTable("dbo.Contact");
        }
    }
}
