namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Conferences", "typeConference", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Conferences", "typeConference", c => c.String());
        }
    }
}
