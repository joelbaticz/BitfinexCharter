using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BitfinexCharter.Models
{
    public class Candle
    {
        public Guid CandleId { get; set; }

        //[Key]
        public Int64 TimeStamp { get; set; }
        public double PriceOpen { get; set; }
        public double PriceClose { get; set; }
        public double PriceLow { get; set; }
        public double PriceHigh { get; set; }
        public double Volume { get; set; }
        public string Type { get; set; }
    }   
}
