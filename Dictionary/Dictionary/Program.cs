using System.Security.Cryptography.X509Certificates;

namespace Dict
{
    public class Program
    {
       
    //65-123

    public static void Main()
        {
            Random RNG = new Random();

            //int size = RNG.Next(5, 21);

            int size = 3;

            var Students = new List<Student>();

            //(string _Name, string _Surname, string _Bday, string _Phone, string _Email, string _GroupName

            for (var i = 0;i < size;i++) 
            {
                Students.Add(new Student(generateRandomName(),
                                 generateRandomName(),
                                 generateRandomBirthdate(),
                                 generateRandomPhone(),
                                 generateRandomEmail(),
                                 RNG.Next(0, 2).ToString()));
                                 //Student.generateRandomName()));
                //"A"));

            }

            Students.ForEach(x => x.marks.Add(new Mark("Math", RNG.Next(1,13) )));
            Students.ForEach(x => x.marks.Add(new Mark("English", RNG.Next(1, 13) )));
            Students.ForEach(x => x.marks.Add(new Mark("Math", RNG.Next(1, 13) )));
            Students.ForEach(x => x.marks.Add(new Mark("Geometry", RNG.Next(1, 13) )));



            Students.ForEach(x => Console.WriteLine($"{x.Name}: {x.GetBestMarkSubject().subject} - {x.GetBestMarkSubject().mark}"));

            Console.WriteLine("------------------------------------------");

            Students.ForEach(x => { 
                if (x.MarksHigherThan(10)) 
                { 
                    Console.WriteLine($"{x.Name}, {x.Surname}, {x.Bday}, {x.Phone}, {x.Email}, {x.GroupName}"); 
                } 
            });

            Console.WriteLine("------------------------------------------");

            Students.ForEach(x =>
            {
            Console.WriteLine($"{x.Name}, {x.Surname}, {x.Bday}, {x.Phone}, {x.Email}, {x.GroupName}");
                { 
                    x.AvgMark().ForEach(y => Console.WriteLine($"   Subject: {y.subject}, Avg Mark: {y.mark}"));
                }   
            });

            #region output filtering commands
            /*
           Students.ForEach(x => Console.WriteLine($"{x.Name}, {x.Surname}, {x.Bday}, {x.Phone}, {x.Email}, {x.GroupName}"));
           Students.ForEach(x => Console.WriteLine($"{x.Name}, {x.Surname}, {x.Bday}, {x.Phone}, {x.Email}, {x.GroupName}"));


           Console.WriteLine("------------------------------------------");

           NameFirstLetter(Students,'A').ForEach(x => Console.WriteLine($"{x.Name}, {x.Surname}, {x.Bday}, {x.Phone}, {x.Email}, {x.GroupName}"));

           Console.WriteLine("------------------------------------------");

           EmailContains(Students, "gmail.com").ForEach(x => Console.WriteLine($"{x.Name}, {x.Surname}, {x.Bday}, {x.Phone}, {x.Email}, {x.GroupName}"));

           Console.WriteLine("------------------------------------------");

           StudentsInGroup(Students, "1").ForEach(x => Console.WriteLine($"{x.Name}, {x.Surname}, {x.Bday}, {x.Phone}, {x.Email}, {x.GroupName}"));

           Console.WriteLine("------------------------------------------");

           var dict = GroupedStudents(Students); ;

           Console.WriteLine("------------------------------------------");

           OlderThan(Students, 13).ForEach(x => Console.WriteLine($"{x.Name}, {x.Surname}, {x.Bday}, {x.Phone}, {x.Email}, {x.GroupName}"));
            */
            // Student. Name, Surname, Birthday, Phone, Email, GroupName
            // List<Student> 
            // Name starts with A;
            // Older than 13;
            // Email contains gmail.com'
            // Get students from one group
            // Create dictionary of students from one group
            #endregion


            Student addMark(Student student ,string subject, int mark) 
            {
                Student output = student;
                student.marks.Add(new Mark (subject, mark));
                return output;
            }

            #region Lesson material
            /*
            var dic = new Dictionary<int, string>();
            dic.Add(1, "324123");
            dic.Add(2, "1234567890");
            dic.Add(3, "0987654321");
            if (!dic.ContainsKey(4)) 
            {
                dic.Add(4, "1234567890");
            }
            Console.WriteLine(dic[1]);
        
            var list = new List<int>();
            var random = new Random();

            for (var i = 0; i < random.Next(20, 100); i++)
            {
                list.Add(random.Next(10, 1000));
            }

            //list.ForEach(x => Console.Write($"[ {x} ]"));
            //Console.WriteLine();

            Output(list.Where(x => x > 100 && x < 250).ToList());
            //Output(list);

            var first = list.First(x => x > 600); // list[0]
            var last = list.Last(); // list[List.Count - 1]
            var firstOrDefault = list.FirstOrDefault(x => x > 6000);
            var lastOrDefault = list.LastOrDefault(x => x > 6000);

            var any = list.Any(x => x == 500);
            var max = list.Max();
            var min = list.Min();
            list.Sort();
            list.Reverse();
            //var selected = list.Select(x => x);
            var selected = list.Select(x => Convert.ToString(x));
                */
            #endregion
        }

        #region Generators
        public static string generateRandomPhone()
        {
            string output = "+380";
            Random RNG = new Random();

            for (int i = 0; i < 13; i++)
            {
                switch (i)
                {
                    case 0: output += "("; break;
                    case 3: output += ")"; break;
                    case 7: output += "-"; break;
                    case 10: output += "-"; break;
                    default: output += RNG.Next(0, 10).ToString(); break;
                }
            }

            return output;
        }

        public static string generateRandomBirthdate()
        {
            Random RNG = new Random();
            return (RNG.Next(1, 30).ToString() + "." + RNG.Next(1, 13).ToString() + "." + RNG.Next(2005, 2016).ToString());
        }

        public static string generateRandomEmail()
        {
            Random RNG = new Random();
            int length = RNG.Next(3, 16);
            string output = "";

            for (int i = 0; i < length; i++)
            {
                int letter = (RNG.Next(65, 123));
                if (letter >= 65 && letter <= 90 || letter >= 97 && letter <= 122)
                {
                    output += (Char)letter;
                }
                else { i--; }
            }

            switch (RNG.Next(0, 5))
            {
                case 0: output += "@gmail.com"; break;
                case 1: output += "@email.com"; break;
                case 2: output += "@mail.com"; break;
                case 3: output += "@uamail.com"; break;
                case 4: output += "@mail"; break;
            }

            return output;
        }

        public static string generateRandomName()
        {
            Random RNG = new Random();
            int length = RNG.Next(3, 16);
            string output = "";

            for (int i = 0; i < length; i++)
            {
                int letter = (RNG.Next(65, 123));
                if (letter >= 65 && letter <= 90 || letter >= 97 && letter <= 122)
                {
                    output += (Char)letter;
                }
                else { i--; }
            }
            return output;
        }

        public static string generateRandomGroup()
        {
            Random RNG = new Random();
            int length = RNG.Next(3, 16);
            string output = "";

            for (int i = 0; i < length; i++)
            {
                int letter = (RNG.Next(65, 123));
                if (letter >= 65 && letter <= 90 || letter >= 97 && letter <= 122 || letter == 95 || letter == 45)
                {
                    output += (Char)letter;
                }
                else { i--; }
            }
            return output;
        }
        #endregion

        #region Filtering

        public static List<Student> NameFirstLetter(List<Student> Students, char letter)
        {
            var output = new List<Student>();

            output = Students.Where(x => x.Name.StartsWith(letter)).ToList();

            return output;
        }

        public static List<Student> OlderThan(List<Student> Students, int age)
        {
            var output = new List<Student>();

            Students.ForEach(x =>
            {
                if (2023 - Convert.ToInt32(x.Bday.Split('.', 4)[2]) > age) 
                {
                    output.Add(x);
                }
            });

            return output;
        }

        public static List<Student> EmailContains(List<Student> Students, string Domain)
        {
            var output = new List<Student>();

            output = Students.Where(x => x.Email.Contains(Domain)).ToList();

            return output;
        }

        public static List<Student> StudentsInGroup(List<Student> Students, string _GroupName)
        {
            var output = new List<Student>();

            output = Students.Where(x => x.GroupName == _GroupName).ToList();

            return output;
        }

        public static Dictionary<String, List<Student>> GroupedStudents(List<Student> Students)
        {
            var groups = new Dictionary<String, List<Student>>();

            Students.ForEach(x =>
            {
                if (groups.ContainsKey(x.GroupName))
                {
                    groups[x.GroupName].Add(x);
                }
                else
                {
                    groups.Add(x.GroupName, new List<Student> { x });
                }

            });
            return groups;
        }

        #endregion
    }

}

