using System;
using System.Collections.Generic;

namespace Thirain.Helper
{
    public static class InitHelper
    {

        public static List<DateTime> GetAllSpawntimes()
        {
            /*List<string> spawntimes = new()
            {
                "0:30",
                "1:30",
                "2:30",
                "3:30",
                "4:30",
                "5:30",
                "6:30",
                "7:30",
                "8:30",
                "9:30",
                "10:30",
                "11:30",
                "12:30",
                "13:30",
                "14:30",
                "15:30",
                "16:30",
                "17:30",
                "18:30",
                "19:30",
                "20:30",
                "21:30",
                "22:30",
                "23:30"
            };*/

            List<DateTime> spawntimes = new()
            {
                DateTime.MinValue.AddMinutes(30),
                DateTime.MinValue.AddHours(1).AddMinutes(30),
                DateTime.MinValue.AddHours(2).AddMinutes(30),
                DateTime.MinValue.AddHours(3).AddMinutes(30),
                DateTime.MinValue.AddHours(4).AddMinutes(30),
                DateTime.MinValue.AddHours(5).AddMinutes(30),
                DateTime.MinValue.AddHours(6).AddMinutes(30),
                DateTime.MinValue.AddHours(7).AddMinutes(30),
                DateTime.MinValue.AddHours(8).AddMinutes(30),
                DateTime.MinValue.AddHours(9).AddMinutes(30),
                DateTime.MinValue.AddHours(10).AddMinutes(30),
                DateTime.MinValue.AddHours(11).AddMinutes(30),
                DateTime.MinValue.AddHours(12).AddMinutes(30),
                DateTime.MinValue.AddHours(13).AddMinutes(30),
                DateTime.MinValue.AddHours(14).AddMinutes(30),
                DateTime.MinValue.AddHours(15).AddMinutes(30),
                DateTime.MinValue.AddHours(16).AddMinutes(30),
                DateTime.MinValue.AddHours(17).AddMinutes(30),
                DateTime.MinValue.AddHours(18).AddMinutes(30),
                DateTime.MinValue.AddHours(19).AddMinutes(30),
                DateTime.MinValue.AddHours(20).AddMinutes(30),
                DateTime.MinValue.AddHours(21).AddMinutes(30),
                DateTime.MinValue.AddHours(22).AddMinutes(30),
                DateTime.MinValue.AddHours(23).AddMinutes(30),
            };

            return spawntimes;
        }
    }
}
