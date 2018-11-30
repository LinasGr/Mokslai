namespace EntityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.profiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 128),
                        Name = c.String(),
                        FamilyName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        EMail = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.users", t => t.UserName)
                .Index(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.profiles", "UserName", "dbo.users");
            DropIndex("dbo.profiles", new[] { "UserName" });
            DropTable("dbo.profiles");
        }
    }
}
