namespace AutoAuction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initLotTable : DbMigration
    {
        public override void Up()
        {
            Sql("delete from Lots");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'BMW E60', N'/Content/Image/1.jpg', N'2016-05-07 00:00:00', N'2016-12-30 00:00:00', CAST(125.00 AS Decimal(18, 2)), CAST(125.00 AS Decimal(18, 2)), 0)");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'Mercedes z1', N'/Content/Image/2.jpg', N'2016-06-14 00:00:00', N'2017-01-30 00:00:00', CAST(175.00 AS Decimal(18, 2)), CAST(175.00 AS Decimal(18, 2)), 0)");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                            " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'Audi A8', N'/Content/Image/3.jpg', N'2016-12-07 00:00:00', N'2016-12-25 00:00:00', CAST(140.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), 0)");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                            " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'Bugatti', N'/Content/Image/4.jpg', N'2016-12-17 00:00:00', N'2016-01-02 00:00:00', CAST(270.00 AS Decimal(18, 2)), CAST(270.00 AS Decimal(18, 2)), 0)");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                            " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'BMW e70', N'/Content/Image/5.jpg', N'2016-03-07 00:00:00', N'2016-12-20 00:00:00', CAST(500.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), 0)");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                            " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'Opel', N'/Content/Image/6.jpg', N'2016-05-05 00:00:00', N'2016-12-27 00:00:00', CAST(25.70 AS Decimal(18, 2)), CAST(25.70 AS Decimal(18, 2)), 0)");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                            " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'BMW 70', N'/Content/Image/7.jpg', N'2016-05-07 00:00:00', N'2016-12-30 00:00:00', CAST(325.00 AS Decimal(18, 2)), CAST(325.00 AS Decimal(18, 2)), 0)");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                            " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'Audi A6', N'/Content/Image/8.jpg', N'2016-12-07 00:00:00', N'2016-12-30 00:00:00', CAST(257.00 AS Decimal(18, 2)), CAST(257.00 AS Decimal(18, 2)), 0)");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                            " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'Mercedes E100', N'/Content/Image/9.jpg', N'2016-02-07 00:00:00', N'2017-02-05 00:00:00', CAST(2514.00 AS Decimal(18, 2)), CAST(2514.00 AS Decimal(18, 2)), 0)");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                            " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'Renault', N'/Content/Image/10.jpg', N'2016-05-02 00:00:00', N'2016-12-31 00:00:00', CAST(170.30 AS Decimal(18, 2)), CAST(170.30 AS Decimal(18, 2)), 0)");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                            " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'Citroen', N'/Content/Image/11.jpg', N'2016-07-07 00:00:00', N'2016-12-30 00:00:00', CAST(25.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), 0)");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                            " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'Shevrole', N'/Content/Image/12.jpg', N'2016-08-07 00:00:00', N'2017-01-07 00:00:00', CAST(225.00 AS Decimal(18, 2)), CAST(225.00 AS Decimal(18, 2)), 0)");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                            " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'MG', N'/Content/Image/13.jpg', N'2016-05-07 00:00:00', N'2017-02-23 00:00:00', CAST(125.00 AS Decimal(18, 2)), CAST(125.00 AS Decimal(18, 2)), 0)");
            Sql("INSERT INTO [dbo].[Lots] ([LotName], [LotImageUrl], [StarLotSaleDate], [EndLotSaleDate]," +
                            " [StartLotPrice], [CurrentPrice], [IsSold]) VALUES (N'Bentli', N'/Content/Image/14.jpg', N'2016-05-07 00:00:00', N'2016-12-31 00:00:00', CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0)");

        }
        
        public override void Down()
        {
        }
    }
}
