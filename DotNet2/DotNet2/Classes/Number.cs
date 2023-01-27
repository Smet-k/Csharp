using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet2.Classes
{ 
    public class Number
    {
        private double value;

        #region Math
        public Number(double value)
        {
            this.value = value;
        }

        public void Add(double value) 
        {
            this.value += value;

            
        }

        public void Subtract(double value)
        {
            this.value -= value;

            
        }

        public void Multiply(double value)
        {
            this.value *= value;


        }

        public void Divide(double value)
        {
            if (value != 0)
            {
                this.value /= value;
            }
            else { value = 0; }

            
        }

        public double GetValue() 
        { 
            return this.value;
        }

        #endregion
    }
}
