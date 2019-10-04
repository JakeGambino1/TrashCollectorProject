namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPickupBoolForCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "pickupCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "pickupCompleted");
        }
    }
}
