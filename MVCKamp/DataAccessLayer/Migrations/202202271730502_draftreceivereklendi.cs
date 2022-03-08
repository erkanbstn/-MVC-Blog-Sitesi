namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class draftreceivereklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drafts", "DraftReceiver", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drafts", "DraftReceiver");
        }
    }
}
