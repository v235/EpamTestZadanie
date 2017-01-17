namespace AutoAuction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initRoleTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[CustomerRoles] ON");
            Sql("INSERT INTO [dbo].[CustomerRoles] ([Id], [RoleName]) VALUES (1, N'admin')");
            Sql("INSERT INTO [dbo].[CustomerRoles] ([Id], [RoleName]) VALUES (2, N'customer')");
            Sql("SET IDENTITY_INSERT [dbo].[CustomerRoles] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
