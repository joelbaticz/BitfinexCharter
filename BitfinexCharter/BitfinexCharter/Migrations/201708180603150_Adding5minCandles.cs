namespace BitfinexCharter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding5minCandles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candles", "Discriminator");
        }
    }
}
