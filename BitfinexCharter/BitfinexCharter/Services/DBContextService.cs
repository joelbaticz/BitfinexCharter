using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BitfinexCharter.Models;

namespace BitfinexCharter.Services
{
    public class DBContextService : DbContext
    {
        public DbSet<Candle> Candles { get; set; }

        public DBContextService() : base("name=BitfinexCharter")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
