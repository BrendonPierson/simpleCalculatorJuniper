using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Evaluate
    {
        public int ArgOne { get; set; }
        public int ArgTwo { get; set; }
        public string Operation { get; set; }
        private Stack commands;
        public Stack Commands
        {
            get { return commands; }
        }


        public Evaluate() { commands = new Stack(); }
        public Evaluate(int argOne, int argTwo, string operation)
        {
            ArgOne = argOne;
            ArgTwo = argTwo;
            Operation = operation;
            commands = new Stack();
        }

        public int Compute()
        {
            commands.Lastq = ArgOne.ToString() + Operation + ArgTwo.ToString();
            switch (Operation)
            {
                case "+":
                    commands.Last = Add(ArgOne, ArgTwo);
                    return Add(ArgOne, ArgTwo);
                case "-":
                    return Sub(ArgOne, ArgTwo);
                case "*":
                    return Mult(ArgOne, ArgTwo);
                case "/":
                    return Div(ArgOne, ArgTwo);
                case "%":
                    return Mod(ArgOne, ArgTwo);
            }
            return 0;
        }

        

        public int Add( int a, int b)
        {
            return a + b;
        }
        public int Sub(int a, int b)
        {
            return a - b;
        }
        public int Mult(int a, int b)
        {
            return a * b;
        }
        public int Div(int a, int b)
        {
            return a / b;
        }
        public int Mod(int a, int b)
        {
            return a % b;
        }
    }
}
