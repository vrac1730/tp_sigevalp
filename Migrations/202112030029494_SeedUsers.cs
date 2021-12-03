namespace SIGEVALP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0f5243a5-cda4-44f5-9137-64cf96a43d8c', N'admingeneral@sigevalp.com', 0, N'AAUk+8Ox0J2+ZmpjUNiQAvqxjwTNRKggch0kDqSYaXv0Q1Afu0wLzsOeI5H0lIRKqA==', N'774f85b6-e707-4a16-aa30-62d99b6095db', NULL, 0, 0, NULL, 1, 0, N'admingeneral@sigevalp.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'67807522-93d5-40e1-a3b3-1f5f42774e7d', N'sebas_rodriguez_18@hotmail.com', 0, N'AICOwaG4O9gXbzc83rsYgXoY4iAz5mBkikRMBR6LvqZPtdJBjnqKQDsQuc8zRx/cwg==', N'507012ff-6217-4758-9f25-ec8d3d75a5b4', NULL, 0, 0, NULL, 1, 0, N'sebas_rodriguez_18@hotmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6903f8be-ea5b-46cc-8b08-6f29468dc17c', N'almacenero@sigevalp.com', 0, N'AO/yK9PYWV43m2vpFKMZyBbXD5nY0rqnG3Dr5w1JQLK5g4scJxbSrDA/vGypbMG9ww==', N'86314567-f1c1-4af1-a267-5ca979c09cd4', NULL, 0, 0, NULL, 1, 0, N'almacenero@sigevalp.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a687ff0f-f608-43c7-a3ce-2e4920dfb356', N'adminweb@sigevalp.com', 0, N'ADiHXyEwFkWgY3gDrVEoS48s/ZmQK9KRKWr1TZ9iFpjS/6O9QRMNWfaesIBhqpnusQ==', N'c59d0a24-fe52-4981-8a3e-a652bee846ca', NULL, 0, 0, NULL, 1, 0, N'adminweb@sigevalp.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b0aa3dde-623e-467a-98f9-d493ca15c2f5', N'administrador@sigevalp.com', 0, N'AOr5bqSNWoryAe8rTpMGeZhn+l6sJMs0qGB9F6xtaeGjhgh6qvhCKVCoW3QU7J5xMg==', N'012b3c39-7a6a-4df0-8f37-f84b43aa3657', NULL, 0, 0, NULL, 1, 0, N'administrador@sigevalp.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ed14e76c-7049-44e0-9802-3e0d250b3faf', N'jefealmacen@sigevalp.com', 0, N'AEZtY/LYHN7MwOZt0SQkeA4m4EIwAXpnNrPYu5v4YhTCd7n304n1ttJLvmIEUuMJpw==', N'31a3876e-1057-4fc0-9b24-5c19189c8058', NULL, 0, 0, NULL, 1, 0, N'jefealmacen@sigevalp.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'189cef11-bd5e-4cf0-8470-76fae8284258', N'AdminGeneral')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8b2745ae-0f3f-43d7-92ea-73814692db1b', N'AdminSIGEVALP')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f512ace4-c9b2-4f8a-a2ea-5bd5c4d24903', N'AdminWeb')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6e2cd175-856c-4b57-9381-e751df11c2cc', N'Almacenero')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'34b55412-aef8-469a-a776-268686549542', N'JefeAlmacen')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0f5243a5-cda4-44f5-9137-64cf96a43d8c', N'189cef11-bd5e-4cf0-8470-76fae8284258')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ed14e76c-7049-44e0-9802-3e0d250b3faf', N'34b55412-aef8-469a-a776-268686549542')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6903f8be-ea5b-46cc-8b08-6f29468dc17c', N'6e2cd175-856c-4b57-9381-e751df11c2cc')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b0aa3dde-623e-467a-98f9-d493ca15c2f5', N'8b2745ae-0f3f-43d7-92ea-73814692db1b')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a687ff0f-f608-43c7-a3ce-2e4920dfb356', N'f512ace4-c9b2-4f8a-a2ea-5bd5c4d24903')

        ");
        }
        
        public override void Down()
        {
        }
    }
}
