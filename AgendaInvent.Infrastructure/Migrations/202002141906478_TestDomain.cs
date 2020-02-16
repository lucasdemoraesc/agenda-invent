namespace AgendaInvent.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestDomain : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contact", "Email");
            DropColumn("dbo.Contact", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "BirthDate", c => c.DateTime());
            AddColumn("dbo.Contact", "Email", c => c.String(maxLength: 80));
        }
    }
}
