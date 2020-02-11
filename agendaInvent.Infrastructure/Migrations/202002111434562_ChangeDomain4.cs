namespace AgendaInvent.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDomain4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contact", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "Email", c => c.String(maxLength: 80));
        }
    }
}
