namespace BitfinexCharter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingCandles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candles", "Type", c => c.String());
            DropColumn("dbo.Candles", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Candles", "Type");
        }
    }
}
