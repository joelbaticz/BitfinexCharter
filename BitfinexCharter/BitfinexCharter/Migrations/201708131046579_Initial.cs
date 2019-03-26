namespace BitfinexCharter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candles",
                c => new
                    {
                        CandleId = c.Guid(nullable: false),
                        TimeStamp = c.Long(nullable: false),
                        PriceOpen = c.Double(nullable: false),
                        PriceClose = c.Double(nullable: false),
                        PriceLow = c.Double(nullable: false),
                        PriceHigh = c.Double(nullable: false),
                        Volume = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CandleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Candles");
        }
    }
}
