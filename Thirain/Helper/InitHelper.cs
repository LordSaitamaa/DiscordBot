using System;
using System.Collections.Generic;

namespace Thirain.Helper
{
    public static class InitHelper
    {

        public static List<DateTime> GetAllSpawntimes()
        {
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
