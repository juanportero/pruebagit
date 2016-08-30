using PicoYPlacaPredictor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictorClasses
{
    public class PicoYPlacaCalculator
    {

        public string CalculatePicoyPlacaRule(string platenumber, string date, string time)
        {
   
            int lastdigit = Convert.ToInt32(platenumber.Substring(7, 1));
            int day = Convert.ToInt32(date.Substring(0, 2));
            int month = Convert.ToInt32(date.Substring(3, 2));
            int year = Convert.ToInt32(date.Substring(6, 4));

            DateTime dateValue = new DateTime(year, month, day);
            int dayofweek = (int)dateValue.DayOfWeek;

            TimeSpan hour = TimeSpan.Parse(time);
            int part = 0;
            string result = "";

            if (hour < TimeSpan.Parse("12:00"))
                part = 1;
            else
                part = 2;


            using (var db = new PicoyPlacaPredictorEntities())
            {
                var picoYPlacaRule = db.PicoYPlaca.Where(p => p.LicensePlateNumber == lastdigit && p.IdDayOfWeek == dayofweek).ToList();
                var sch = db.Schedule.Where(s => s.Id == part && (hour >= s.StartTime || hour <= s.EndTime)).ToList();

                if (picoYPlacaRule.Count() > 0 && sch.Count() > 0)

                    result = String.Format("It is {0} {1} in the {2}, so your car can't be on the road",
                        picoYPlacaRule[0].DayOfWeek.DayName.ToString(),
                        hour,
                        sch[0].ScheduleName.ToString());
                else
                {
                    var day1 = db.DayOfWeek.Where(d => d.Id == dayofweek).ToList();
                    var sch1 = db.Schedule.Where(s => s.Id == part).ToList();

                    result = String.Format("It is {0} {1} in the {2}, so your car can be on the road",
                        day1[0].DayName.ToString(),
                        hour,
                        sch1[0].ScheduleName.ToString());
                }
            }

            return result;

        }
    }
}
