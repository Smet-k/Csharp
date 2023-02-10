using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dict
{
    // Student. Name, Surname, Birthday, Phone, Email, GroupName
    // List<Student> 
    // Name starts with A;
    // Older than 13;
    // Email contains gmail.com
    // Get students from one group
    // Create dictionary of students from one group


    public class Student
    {


        public readonly string Name;
        public readonly string Surname;
        public readonly string Bday;
        public readonly string Phone;
        public readonly string Email;
        public readonly string GroupName;
        public List<Mark> marks = new List<Mark> ();

        public static bool isPhoneValid(string phone)
        {
            return phone[0] == '+'
                && phone[1] == '3'
                && phone[2] == '8'
                && phone[3] == '0'
                && phone[4] == '('
                && phone[5] > 47 && phone[5] < 58
                && phone[6] > 47 && phone[6] < 58
                && phone[7] == ')'
                && phone[8] > 47 && phone[8] < 58
                && phone[9] > 47 && phone[9] < 58
                && phone[10] > 47 && phone[10] < 58
                && phone[11] == '-'
                && phone[12] > 47 && phone[12] < 58
                && phone[13] > 47 && phone[13] < 58
                && phone[14] == '-'
                && phone[15] > 47 && phone[15] < 58
                && phone[16] > 47 && phone[16] < 58
                && phone.Length == 17;
        }

        public Student()
        {
            Name = "";
            Surname = "";
            Bday = "";
            Phone = "";
            Email = "";
            GroupName = "";
        }


        public Student(string _Name, string _Surname, string _Bday, string _Phone, string _Email, string _GroupName)
        {
            Name = _Name;
            Surname = _Surname;
            Bday = _Bday;
            if (isPhoneValid(_Phone)) { Phone = _Phone; }
            else { Phone = "+380(00)000-00-00"; }
            Email = _Email;
            GroupName = _GroupName;
        }

        public List<Mark> AvgMark ()
        {
            List<Mark> output = new List<Mark> (); 
            int number = 0;
            int divideBy = 0;

            marks.ForEach(y => {
                marks.ForEach(x =>
                {
                    if (string.Equals(x.subject, y.subject, StringComparison.OrdinalIgnoreCase))
                    {
                        number += x.mark;
                        divideBy++;
                    }
                }

             );
             output.Add(new Mark(y.subject, number / divideBy));
             divideBy = 0;
             number = 0;
            }
            
            );

            return output;
           
        }

        public bool MarksHigherThan(int compareTo) 
        {
            bool output = false;
            marks.ForEach(x =>
            {
                if (x.mark > compareTo)
                {
                    output = true;
                }
            }
            );

            return output;

        }

        public Mark GetBestMarkSubject() 
        {
            Mark Comparator = new Mark("", 0);

            marks.ForEach(x =>
            {
                if (x.mark > Comparator.mark) 
                {
                    Comparator = x;
                }
            }
            );

            return Comparator;
        }
    }
}
