using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Parse
    {
        public string Input { get; set; }
        public int FirstArg { get; set; }
        public int SecondArg { get; set; }
        public string Operand { get; set; }
        public bool FirstNeg { get; set; }
        public bool SecondNeg { get; set; }
        private char[] delimiters = new char[] { '+', '-', '*', '/', '%' };

        public Parse() { }
        public Parse(string input)
        {
            Input = input;
        }

        public void CreateEquation()
        {
            CheckIfFirstArgIsNegative();
            GetOperand();
            GetArgs();
        }

        public void CheckIfFirstArgIsNegative()
        {
            if (Input[0] == '-')
            {
                FirstNeg = true;
                Input = Input.Remove(0, 1);
            }
        }

        public void GetOperand()
        {   
            List<string> ops = new List<string>();
            foreach(var c in Input)
            {
                if (delimiters.Contains(c))
                {
                    ops.Add(c.ToString());
                }
            }

            if(ops.Count == 1)
            {
                Operand = ops[0];
            } else if(ops.Count == 2 && ops[1] == "-")
            {
                Operand = ops[0];
                SecondNeg = true;
                Input = Input.Remove(Input.IndexOf("-"),1);
            } else 
            {
                throw new ArgumentException("Incorrect operator format");
            }
        }

        public void GetArgs()
        {
            if(Input.Count() > 3)
            {
                string[] args = Input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToArray();
                if (args.Count() == 2)
                {
                    FirstArg = FirstNeg ? -1 * int.Parse(args[0]) : int.Parse(args[0]);
                    
                    SecondArg = SecondNeg ? -1 * int.Parse(args[1]) : int.Parse(args[1]);
                } else
                {
                    throw new ArgumentException("Incorrect equation format");
                }
            }
            else
            {
                throw new ArgumentException("Incorrect equation format");
            }
        }
    }
}
