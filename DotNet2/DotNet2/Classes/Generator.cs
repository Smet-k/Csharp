using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet2.Classes
{
    public class Generator
    {
        Random RNG = new Random();
        private string value = "";

        Number[] numbers;
        Action[] actions;


        public Generator()
        {

            string output = "";

            var NumberAmount = RNG.NextInt64(2, 11);

            numbers = new Number[NumberAmount];
            actions = new Action[NumberAmount - 1];

            for (var i = 0; i < NumberAmount; i++)
            {
                numbers[i] = new Number(RNG.NextInt64(0, 999)) ;
            }

            for (var i = 0; i < NumberAmount - 1; i++)
            {
                var actionID = RNG.NextInt64(0, 4);
                switch (actionID)
                {
                    case 0: actions[i] = new Action('+'); break;
                    case 1: actions[i] = new Action('-'); break;
                    case 2: actions[i] = new Action('*'); break;
                    case 3: actions[i] = new Action('/'); break;
                }
            }
        }

        public string GetString()
        {
            var output = "";
            for (var i = 0; i < numbers.Length; i++)
            {
                output += numbers[i].GetValue();
                if (i < numbers.Length - 1)
                {
                    output += actions[i].getValue();
                }
            }
            return output;
        }
    }
}
