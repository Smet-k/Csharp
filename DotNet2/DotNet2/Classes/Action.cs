using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet2.Classes
{
    public class Action
    {

        private char value = ' ';
        //public char value { get; };
        //public readonly char value;
        public Action(char value) 
        {
            this.value = value;
        }



        public char getValue() { return this.value; }

        public void Calculate(Number firstNum, Number secondNum) 
        {
            switch (value) 
            {
                case '+': firstNum.Add(secondNum.GetValue()); break;
                case '-': firstNum.Subtract(secondNum.GetValue()); break;
                case '*': firstNum.Multiply(secondNum.GetValue()); break;
                case '/': firstNum.Divide(secondNum.GetValue()); break;
            }
        
        }
    }
}
