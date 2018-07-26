namespace MarvelPhases.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetables : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Series", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Series", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
