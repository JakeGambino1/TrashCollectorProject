namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPickupOptionsForCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "WeeklyPickupDay", c => c.String());
            AddColumn("dbo.Customers", "OneTimePickupDate", c => c.String());
            AddColumn("dbo.Customers", "SuspendPickupStart", c => c.String());
            AddColumn("dbo.Customers", "SuspendPickupStop", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SuspendPickupStop");
            DropColumn("dbo.Customers", "SuspendPickupStart");
            DropColumn("dbo.Customers", "OneTimePickupDate");
            DropColumn("dbo.Customers", "WeeklyPickupDay");
        }
    }
}
