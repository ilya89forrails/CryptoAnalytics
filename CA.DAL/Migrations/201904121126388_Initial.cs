namespace CA.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
            "dbo.Cryptocurrencies",
            c => new
            {
                Id = c.Int(nullable: false, identity: true),
                Rank = c.Int(nullable: false),
                Name = c.String(),
                Symbol = c.String(),
                MarketCap = c.Decimal(nullable: false, precision: 18, scale: 2),
                PriceUSD = c.Decimal(nullable: false, precision: 18, scale: 2),
                DailyVolume = c.Decimal(nullable: false, precision: 18, scale: 2),
                CirculatingSupply = c.Decimal(nullable: false, precision: 18, scale: 2),
                TimeStamp = c.DateTime(nullable: false, defaultValueSql: null),
            })
            .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Cryptocurrencies");
        }
    }
}
