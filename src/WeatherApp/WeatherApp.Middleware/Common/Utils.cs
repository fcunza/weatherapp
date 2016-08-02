using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Middleware.Common
{
    public class Utils
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var source = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

            return source.AddSeconds(unixTimeStamp).ToLocalTime();
        }
    }
}
