namespace EntityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.associations",
                c => new
                    {
                        AssociationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Suspended = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AssociationId);
            
            CreateTable(
                "dbo.documents",
                c => new
                    {
                        DokumentID = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        Title = c.String(),
                        Text = c.String(),
                        DateValidFrom = c.DateTime(nullable: false),
                        DateValidTill = c.DateTime(nullable: false),
                        AssociationId = c.Int(nullable: false),
                        Activated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DokumentID)
                .ForeignKey("dbo.associations", t => t.AssociationId, cascadeDelete: true)
                .Index(t => t.AssociationId);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        DateCreated = c.DateTime(nullable: false),
                        Suspended = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.documents", "AssociationId", "dbo.associations");
            DropIndex("dbo.documents", new[] { "AssociationId" });
            DropTable("dbo.users");
            DropTable("dbo.documents");
            DropTable("dbo.associations");
        }
    }
}
