namespace ProductsSrvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
