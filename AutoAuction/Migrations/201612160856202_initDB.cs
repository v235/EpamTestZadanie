namespace AutoAuction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerLots",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        LotId = c.Int(nullable: false),
                        CustomerBet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WinAuction = c.Boolean(nullable: false),
                        LotMaker = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.LotId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Lots", t => t.LotId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.LotId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.CustomerRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CustomerRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lots",
                c => new
                    {
                        LotId = c.Int(nullable: false, identity: true),
                        LotName = c.String(),
                        LotImageUrl = c.String(),
                        StarLotSaleDate = c.DateTime(nullable: false),
                        EndLotSaleDate = c.DateTime(nullable: false),
                        StartLotPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSold = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LotId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerLots", "LotId", "dbo.Lots");
            DropForeignKey("dbo.Customers", "RoleId", "dbo.CustomerRoles");
            DropForeignKey("dbo.CustomerLots", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Customers", new[] { "RoleId" });
            DropIndex("dbo.CustomerLots", new[] { "LotId" });
            DropIndex("dbo.CustomerLots", new[] { "CustomerId" });
            DropTable("dbo.Lots");
            DropTable("dbo.CustomerRoles");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerLots");
        }
    }
}
