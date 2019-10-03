namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBalanceToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "OutstandingBalance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "OutstandingBalance");
        }
    }
}
