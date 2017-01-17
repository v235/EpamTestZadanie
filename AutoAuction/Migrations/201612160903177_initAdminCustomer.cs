namespace AutoAuction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initAdminCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[Customers] ON");
            Sql(
                "INSERT INTO [dbo].[Customers] ([CustomerId], [Email], [Password], [RoleId]) VALUES (1, N'admin', N'admin', 1)");
            Sql("SET IDENTITY_INSERT [dbo].[Customers] OFF");
        }

        public override void Down()
        {
        }
    }
}
