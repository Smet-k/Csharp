using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DTimeLess
{
    // Inherit Print(), abstract parse()
    // today, yesterday, 1 day ahead, 35 minutes, next Monday, next Monday, last friday;
    public abstract class DateTimeParser
    {
        protected DateTime date;
        public DateTimeParser(string input)
        {
            date = Parse(input);
        }
        public void Print()
        {
            Console.WriteLine(date.ToString());
        }
        DateTime dateValue = new DateTime(2008, 6, 11);
        //Console.WriteLine((int) dateValue.DayOfWeek);
        public abstract DateTime Parse(string input);
    }
    public class TodayTomorrow : DateTimeParser
    {
        public TodayTomorrow(string input) : base(input)
        {
        }
        public override DateTime Parse(string input)
        {
            var words = new List<string>();
            var output = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    output += input[i];
                }
                else
                {
                    words.Add(output);
                    output = "";
                }
            }

            words.Add(output);

            int add = 1;
            if (words.Contains("before") || words.Contains("after")) { add++; }
            var Doutput = DateTime.UtcNow.ToLocalTime();
            words.ForEach(x =>
            {
                if (String.Equals(x.Trim(), "today", StringComparison.OrdinalIgnoreCase))
                {
                    Doutput = DateTime.UtcNow.ToLocalTime();
                }
                else if (String.Equals(x.Trim(), "tomorrow", StringComparison.OrdinalIgnoreCase))
                {
                    Doutput = DateTime.UtcNow.ToLocalTime().AddDays(add);
                }
                else if (String.Equals(x.Trim(), "yesterday", StringComparison.OrdinalIgnoreCase))
                {
                    Doutput = DateTime.UtcNow.ToLocalTime().AddDays(-add);
                }
            });

            return Doutput;
        }
    }

    public class AgoAhead : DateTimeParser
    {
        public AgoAhead(string input) : base(input)
        {
        }
        public override DateTime Parse(string input)
        {
            var Days = new List<string>() {"1", "2", "3", "4", "5", "6", "7", "8", "9" };
            var targets = new List<string>() { "years", "months", "days", "hours", "minutes", "seconds", "year", "month", "day", "hour", "minute", "second","week","weeks" };
            var Doutput = DateTime.UtcNow.ToLocalTime();
            var output = "";
            var words = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    output += input[i];
                }
                else
                {
                    words.Add(output);
                    output = "";
                }
            }
            words.Add(output);

            var increment = -1;
            var act = "";
            var target = "";
            words.ForEach(x =>
                {
                    if (Days.Contains(Convert.ToString(x.First())))
                    {
                        increment = Convert.ToInt32(x);
                    }

                    if (targets.Contains(x))
                    {
                        target = x.Trim().ToLower();
                    }

                    if (String.Equals(x.Trim(), "ago", StringComparison.OrdinalIgnoreCase))
                    {
                        act = "-";
                    }
                    else if (String.Equals(x.Trim(), "ahead", StringComparison.OrdinalIgnoreCase))
                    {
                        act = "+";
                    }

                    if (act != "" && increment >= 0 && target != "")
                    {
                        if (act == "-") { increment = -increment; }
                        switch (target)
                        {
                            case "years": case "year": Doutput = Doutput.AddYears(increment); act = ""; target = ""; increment = -1; break;
                            case "months":case "month":Doutput = Doutput.AddMonths(increment); act = ""; target = ""; increment = -1; break;
                            case "days":case "day": Doutput = Doutput.AddDays(increment); act = ""; target = ""; increment = -1; break;
                            case "hours":case "hour": Doutput = Doutput.AddHours(increment); act = ""; target = ""; increment = -1; break;
                            case "minutes":case "minute": Doutput = Doutput.AddMinutes(increment); act = ""; target = ""; increment = -1; break;
                            case "seconds":case "second": Doutput = Doutput.AddSeconds(increment); act = ""; target = ""; increment = -1; break;
                            case "weeks":case "week": Doutput = Doutput.AddDays(increment * 7); act = ""; target = ""; increment = -1; break;
                        }
                    }

                });

            return Doutput;
        }
    }

    public class NextLast : DateTimeParser
    {
        public NextLast(string input) : base(input)
        {
        }
        public override DateTime Parse(string input)
        {
            var outputDate = DateTime.UtcNow.ToLocalTime();
            var words = new List<string>();
            var days = new List<string>() { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday"};
            var output = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    output += input[i];
                }
                else
                {
                    words.Add(output);
                    output = "";
                }
            }

            words.Add(output);

            
            var Today = (int)outputDate.DayOfWeek;
            var target = -1;
            var lastnext = "";
            words.ForEach(x => 
            {
                if (x.ToLower() == "last") 
                {
                    lastnext = "last";
                }
                else if (x.ToLower() == "next") 
                {
                    lastnext = "next";
                }

                if (days.Contains(x.ToLower())) 
                {
                    target = getDayIndex(x.ToLower());
                }

                if(lastnext == "last" && target != -1) 
                {
                    if (Today == target) { outputDate = outputDate.AddDays(-7); }
                    else{ outputDate = DateTime.UtcNow.ToLocalTime().AddDays(target - Today); }
                }
                else if(lastnext == "next" && target != -1) 
                {
                    if (Today == target) { outputDate = outputDate.AddDays(7); }
                    else 
                    {
                        while(Today != target) 
                        {
                            
                            outputDate = outputDate.AddDays(1);
                            Today++;
                            if (Today > 7) { Today = 1; }
                        }

                    }
                }
            });


            return outputDate;
        }


        int getDayIndex(string input) 
        {
            int output = 1;
            var days = new List<string>() { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };
            var increment = 1;
            days.ForEach(x => 
            { 
                if(x != input) 
                {
                    output += increment ;
                }
                else { increment = 0; }
            });
            return output;
        }
    }

    public class NextLastWeek : DateTimeParser
    {

        public NextLastWeek(string input) : base(input)
        {
        }
        public override DateTime Parse(string input)
        {
            var outputDate = DateTime.UtcNow.ToLocalTime();
            var words = new List<string>();
            var daysDate = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            var days = new List<string>() { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };
            var output = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    output += input[i];
                }
                else
                {
                    words.Add(output);
                    output = "";
                }
            }

            words.Add(output);

            var lastnext = "";
            var increment = 1;
            bool action = false;
            words.ForEach(x =>
            {

                if (daysDate.Contains(Convert.ToString(x.First())))
                {
                    increment *= Convert.ToInt32(x);
                }
                if (x.ToLower() == "ago")
                {
                    lastnext = "ago";
                    increment *= -1;
                }
                else if (x.ToLower() == "ahead")
                {
                    lastnext = "ahead";
                }

                if (x.ToLower() == "week" || x.ToLower() == "weeks")
                {
                    increment *= 7;
                    action = true;
                }

                if (lastnext != "" && action == true) 
                {
                    outputDate = outputDate.AddDays(increment);
                    action = false; 
                    lastnext = "";
                    increment = 1;
                }

            });

            words.ForEach(x =>
            {
                var Today = (int)outputDate.DayOfWeek;

                if (days.Contains(x.ToLower()))
                {
                    outputDate = outputDate.AddDays(getDayIndex(x.ToLower()) - Today);

                }
            });



            return outputDate;
        }


        int getDayIndex(string input)
        {
            int output = 1;
            var days = new List<string>() { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };
            var increment = 1;
            days.ForEach(x =>
            {
                if (x != input)
                {
                    output += increment;
                }
                else { increment = 0; }
            });
            return output;
        }
    }
}
