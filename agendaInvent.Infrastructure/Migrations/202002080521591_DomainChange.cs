namespace AgendaInvent.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DomainChange : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Contact", "IX_NAME");
            DropIndex("dbo.Contact", "IX_EMAIL");
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Contact", "Email", unique: true, name: "IX_EMAIL");
            CreateIndex("dbo.Contact", "Name", unique: true, name: "IX_NAME");
        }
    }
}
