namespace agendaInvent.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDomain3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Contact", "Name", unique: true, name: "IX_NAME");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contact", "IX_NAME");
        }
    }
}
