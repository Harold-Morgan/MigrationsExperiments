namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        NAME = c.String(nullable: false),
                        CODE = c.String(nullable: false),
                        ADRESS = c.String(),
                        DISCOUNT = c.Long(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ORDER_DATE = c.DateTime(nullable: false),
                        SHIPMENT_DATE = c.DateTime(nullable: false),
                        ORDER_NUMBER = c.Long(nullable: false),
                        STATUS = c.String(),
                        Customer_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.Customer_ID)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "dbo.OrderElement",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ITEMS_COUNT = c.Int(nullable: false),
                        ITEM_PRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Item_ID = c.Guid(),
                        Order_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Item", t => t.Item_ID)
                .ForeignKey("dbo.Order", t => t.Order_ID)
                .Index(t => t.Item_ID)
                .Index(t => t.Order_ID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CODE = c.String(nullable: false),
                        NAME = c.String(),
                        PRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CATEGORY = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderElement", "Order_ID", "dbo.Order");
            DropForeignKey("dbo.OrderElement", "Item_ID", "dbo.Item");
            DropForeignKey("dbo.Order", "Customer_ID", "dbo.Customer");
            DropIndex("dbo.OrderElement", new[] { "Order_ID" });
            DropIndex("dbo.OrderElement", new[] { "Item_ID" });
            DropIndex("dbo.Order", new[] { "Customer_ID" });
            DropTable("dbo.Item");
            DropTable("dbo.OrderElement");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
