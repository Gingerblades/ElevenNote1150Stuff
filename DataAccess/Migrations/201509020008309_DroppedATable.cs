namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroppedATable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.OkToDelete");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OkToDelete",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SomeColumn = c.String(),
                        Meh = c.String(),
                        Eh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
