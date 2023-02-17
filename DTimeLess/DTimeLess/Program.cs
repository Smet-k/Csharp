namespace DTimeLess 
{
    public class Program 
    {
    public static void Main() 
        {
            /*
            var input = "2023/02/01";
            var strDateTime = Convert.ToDateTime(input);
            var now = DateTime.Now;
            var utcNow = DateTime.UtcNow;
            var date = new DateTime(100, 12, 10, 10, 5, 3);

            var newDate = utcNow.ToLocalTime();

            var timespan = new TimeSpan();

            now = now.AddDays(20);

            Console.WriteLine($" - {now.ToString()}");
            Console.WriteLine($"G - {now.ToString("G")}");
            Console.WriteLine($"f - {now.ToString("f")}");
            Console.WriteLine($"f - {now.ToString("MM dd yyyy hh:mm:ss")}");
            */

            TodayTomorrow date1 = new TodayTomorrow("output after tomorrow");
            date1.Print();

            AgoAhead date2 = new AgoAhead("1 day ago");
            date2.Print();

            NextLast date3 = new NextLast("last saturday");
            date3.Print();

            NextLast date4 = new NextLast("next monday");
            date4.Print();

            NextLastWeek date5 = new NextLastWeek("2 weeks ahead on monday");
            date5.Print();

            NextLastWeek date6 = new NextLastWeek("2 weeks ago on monday");
            date6.Print();
        }
    }
}