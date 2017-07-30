namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
          Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b34a7ae3-434f-4bb2-a678-7ad0f7fa4a32', N'yalain9@gmail.com', 0, N'ADLDFN+A3jdrStDYDHTUxCWV2Jd/zmNWbS8UmtjIwBzZXALBhaYs7dhaN6+pT9/KOg==', N'006325d0-e3c4-4960-8ef6-1c2ab8cc4560', NULL, 0, 0, NULL, 1, 0, N'yalain9@gmail.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f5725ffd-24a1-48b9-81a0-48e5fc1f9208', N'admin@vidly.com', 0, N'AMfI83hvP/tNOjdjqqdVUsOtoM4jqFF2XorhqeCqUljyRx5HxZmRMod0axmgBcCKzA==', N'e8990d89-c4c7-420d-908f-936439400f9f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a109da0c-2c33-4d16-b4ce-d2d64adfc883', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f5725ffd-24a1-48b9-81a0-48e5fc1f9208', N'a109da0c-2c33-4d16-b4ce-d2d64adfc883')

          ");
        }
        
        public override void Down()
        {
        }
    }
}
