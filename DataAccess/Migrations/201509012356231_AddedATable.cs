namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedATable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OkToDelete",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SomeColumn = c.String(),
                        Meh = c.String(),
                        Eh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OkToDelete");
        }
    }
}
