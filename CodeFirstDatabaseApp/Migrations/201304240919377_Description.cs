namespace CodeFirstDatabaseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "MoreDescription", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Products", "MoreDescription");
        }
    }
}
