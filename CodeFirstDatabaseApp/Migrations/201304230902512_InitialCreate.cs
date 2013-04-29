namespace CodeFirstDatabaseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        WishlistId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.WishlistId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        WishlistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Wishlists", t => t.WishlistId, cascadeDelete: true)
                .Index(t => t.WishlistId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "WishlistId" });
            DropForeignKey("dbo.Products", "WishlistId", "dbo.Wishlists");
            DropTable("dbo.Products");
            DropTable("dbo.Wishlists");
        }
    }
}
