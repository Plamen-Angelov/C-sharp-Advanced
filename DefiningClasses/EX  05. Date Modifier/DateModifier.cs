using System;
using System.Globalization;

namespace EX__05._Date_Modifier
{
    public class DateModifier
    {
        public static double GetDaysBetweenDates(string dateOne, string dateTwo)
        {
            DateTime firstDate = DateTime.ParseExact(dateOne, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(dateTwo, "yyyy MM dd", CultureInfo.InvariantCulture);

            if (firstDate > secondDate)
            {
                return GetDaysBetweenDates(dateTwo, dateOne);
            }

            return (secondDate - firstDate).Days;
        }
    }
}
