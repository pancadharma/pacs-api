using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahas.Helpers
{
    public static class DateTimeExtension
    {
        public static string ToFullAge(this DateTime tanggal)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(tanggal).Ticks).Year - 1;
            DateTime PastYearDate = tanggal.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;

            //int Hours = Now.Subtract(PastYearDate).Hours;
            //int Minutes = Now.Subtract(PastYearDate).Minutes;
            //int Seconds = Now.Subtract(PastYearDate).Seconds;

            return string.Format("{0} Tahun {1} Bulan {2} Hari",
            Years, Months, Days);
        }

        public static long GetTimeStamp(this DateTime date)
        {
            date = date.ToUniversalTime();

            var unixTime = ((DateTimeOffset)date).ToUnixTimeMilliseconds();

            return unixTime;
        }

        public static DateTime GetDateTime(this long unixTime)
        {
            DateTime dateTime = new (1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            
            dateTime = dateTime.AddMilliseconds(unixTime).ToLocalTime();

            return dateTime;
        }
    }
}
