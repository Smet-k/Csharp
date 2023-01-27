using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DotNet2.Classes
{

    /*
    var possibleActions = new char[] { '+', '-', '*', '/'};
      
    var nums = input.Split(possibleActions);

    numbers = new Number[nums.Length];
    actions = new Action[nums.Length - 1];

    for (var i = 0;i < nums.Length;i++)
    {
        numbers[i] = new Number(Convert.ToDouble(nums[i]));

        var actionIndex = 0;
        foreach (var symbol in input)
        {
            if(possibleActions.Contains(symbol))
            {
                actions[actionIndex] = new Action(symbol);
                actionInder++;
            }
        }
    }

     */

    public class Calculator
    {
        private string value = "";

        Number[] numbers;
        Action[] actions;

        #region Constructor
        public Calculator(string input)
        {
            var possibleActions = new char[] { '+', '-', '*', '/' };

            var nums = input.Split(possibleActions);

            numbers = new Number[nums.Length];
            actions = new Action[nums.Length - 1];

            for (var i = 0; i < nums.Length; i++)
            {
                numbers[i] = new Number(Convert.ToDouble(nums[i]));

                var actionIndex = 0;
                foreach (var symbol in input)
                {
                    if (possibleActions.Contains(symbol))
                    {
                        actions[actionIndex] = new Action(symbol);
                        actionIndex++;
                    }
                }
            }
        }
        #endregion

        //0, 10 numbers
        //0 , 999
       

        private bool isPriority(Action[] input)
        {
            foreach (var action in input)
            {
                if (action.getValue() == '*' || action.getValue() == '/') { return true; }
            }
            return false;
        }
        

        public void RemoveNumber(int index) 
        {
            var newIndex = 0;
            var output = new Number[numbers.Length - 1];
            for(var i = 0;i < numbers.Length;i++) 
            { 
                if(i != index) 
                {
                    output[newIndex] = numbers[i];
                    newIndex++;
                }
            }
            numbers = output;
        }

        public void RemoveAction(int index)
        {
            var newIndex = 0;
            var output = new Action[actions.Length - 1];
            for (var i = 0; i < numbers.Length; i++)
            {
                if (i != index)
                {
                    output[newIndex] = actions[i];
                    newIndex++;
                }
            }
            actions = output;
        }

        public double Calculate()
        {
            for(var i = 0; i< actions.Length; i++) 
            {
                if (actions[i].getValue() == '*' || actions[i].getValue() == '/')
                {
                    actions[i].Calculate(numbers[i], numbers[i + 1]);
                    RemoveNumber(i + 1);
                    RemoveAction(i);
                    i--;
                }
            }
            for (var i = 0; i < actions.Length; i++)
            {

                actions[i].Calculate(numbers[i], numbers[i + 1]);
                RemoveNumber(i + 1);
                RemoveAction(i);
                i--;
            }

            return numbers[0].GetValue();
            #region Old
            /*
            var ActSize = 0;
            foreach(var item in value) 
            {

                if (item == '+' || item == '-' || item == '*' || item == '/') 
                {
                    ActSize++;
                }
            }

            Number[] numbers = new Number[ActSize + 1];
            Action[] actions = new Action[ActSize];

            var numbersID = 0; 
            var actionsID = 0;
            
            foreach (var item in value)
            {

                if (item == '+' || item == '-' || item == '*' || item == '/')
                {
                    actions[actionsID] = new Action(item);
                    actionsID++;
                    numbersID++;
                }
                else if (item == '1' || item == '2' || item == '3' || item == '4' || item == '5' ||
                        item == '6' || item == '7' || item == '8' || item == '9' || item == '0')
                {
                    if (numbers[numbersID] == null)
                    {
                        numbers[numbersID] = new Number(item - 48);
                    }
                    else { numbers[numbersID] = new Number(numbers[numbersID].GetValue() * 10 + item - 48); }
                }
            }
                for (var i = 0; i < actions.Length; i++) 
            {
                if (isPriority(actions))
                {
                    switch (actions[i].getValue())
                    {
                        case '*': 
                            numbers[i].Multiply(numbers[i + 1].GetValue());
                            numbers[i + 1] = new Number(0);
                            actions[i] = new Action('+');
                            i = -1; 
                            break;
                        case '/':
                            numbers[i].Divide(numbers[i + 1].GetValue());
                            numbers[i + 1] = new Number(0);
                            actions[i] = new Action('+');
                            i = -1;
                            break;
                        default: break;
                    }
                }
                else
                {
                    switch (actions[i].getValue())
                    {
                        case '+': numbers[i].Add(numbers[i + 1].GetValue()); numbers[i + 1] = numbers[i]; break;
                        case '-': numbers[i].Subtract(numbers[i + 1].GetValue()); numbers[i + 1] = numbers[i]; break;
                        default: break;
                    }
                }
            }
            return numbers[ActSize].GetValue();
        }
            */
            #endregion
            return 0;
        }
    }
}
