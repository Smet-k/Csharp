using DotNet2.Classes;
using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace DotNet2 
{
    //0, 10 numbers
    //0 , 999
    
    //
    public class Program 
    {


    public static void AddNumber(int number) 
        {
            number += 5;
        }

    public static void AddNumber(Number number) 
        {
            number.Add(5);
        }

        public static void Main() 
        {
            Random rnd = new Random();
                
            var a = 5;
            var b = new Number(5);

            AddNumber(a);
            AddNumber(b);

            /*
            var str = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            Console.WriteLine(str);

            Console.WriteLine($"Contrains('text'): {str.Contains("Lorem")}");
            str = str.Replace("Lorem", "Deez");
            Console.WriteLine(str);
            */


            Generator g = new Generator();
            var task = new Calculator(g.GetString());
            Console.WriteLine($"{g.GetString()} = {task.Calculate()}");

            }
        }
    /*
    public class MyClass 
    {
        //field
        //property
        //method
        public int field;

        private int property { get; set; }


        protected void Method() 
        { 
        
        }

        public MyClass(int a) 
        {
            field = a;
            property = a;
        }
    }
    */
}