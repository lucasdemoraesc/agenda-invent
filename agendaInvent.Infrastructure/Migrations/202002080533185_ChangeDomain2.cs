namespace AgendaInvent.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDomain2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Contact", "IX_PHONE");
            CreateIndex("dbo.Contact", "Phone", unique: true, name: "IX_PHONE");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contact", "IX_PHONE");
            CreateIndex("dbo.Contact", "Phone", unique: true, name: "IX_PHONE");
        }
    }
}
