using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitfinexCharter.Services
{
    public class DateTimeService
    {
        public static DateTime GetDateTimeFromEpochTime(Int64 millisecondsSinceEpoch)
        {
         
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime();
            epoch = epoch.AddMilliseconds(millisecondsSinceEpoch);
            return epoch;
        }

        public static Int64 GetEpochTimeNow()
        {
            DateTime now = DateTime.Now.ToLocalTime();
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime(); //, DateTimeKind.Utc
            Int64 totalMilliseconds = (long)(now.Subtract(epoch)).TotalMilliseconds;
            return totalMilliseconds;
        }

    }
}
