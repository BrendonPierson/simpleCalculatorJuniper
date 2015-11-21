using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Parse
    {
        public string Input { get; set; }
        public int FirstNumArg { get; set; }
        public bool IsFirstConst { get; set; }
        public string FirstConstArg { get; set; }
        public int SecondNumArg { get; set; }
        public bool IsSecondConst { get; set; }
        public string SecondConstArg { get; set; }
        public bool IsCommand { get; set; }
        public string Command { get; set; }
        public string Operand { get; set; }
        public bool IsConstantAssignment { get; private set; }

        public Parse() { }
        public Parse(string input)
        {
            Input = input;
            Compute();
        }

        public void Compute()
        {
            CheckForCommand();
            if (IsCommand) { return; }
            CheckInput();
            CheckForConstAssignment();
            PullOutArguments();
            GetOperator();
        }

        public void CheckForCommand()
        {
            switch (Input.ToLower().Trim())
            {
                case "last":
                    IsCommand = true;
                    Command = "last";
                    break;
                case "lastq":
                    IsCommand = true;
                    Command = "lastq";
                    break;
                case "exit":
                    IsCommand = true;
                    Command = "exit";
                    break;
                case "quit":
                    IsCommand = true;
                    Command = "exit";
                    break;
                default:
                    IsCommand = false;
                    break;
            }
        }

        public bool CheckForConstAssignment()
        {
            Regex regex = new Regex(@"[a-z]\s?=\s?-?\d+");
            Match match = regex.Match(Input);
            if (match.Success)
            {
                IsConstantAssignment = true;
            } else
            {
                IsConstantAssignment = false;
            }
            return IsConstantAssignment;
        }

        public bool CheckInput()
        {
            Regex regex = new Regex(@"^\s?(-?[a-z]|-?\d+)\s?[%\/\+\*=-]\s?(-?[a-z]|-?\d+)\s?$", RegexOptions.IgnoreCase);
            Match match = regex.Match(Input);
            if (!match.Success)
            {
                throw new ArgumentException();
            }
            return match.Success;
        }

        public void PullOutArguments()
        {
            Regex regex = new Regex(@"([a-z]|-?\d+)", RegexOptions.IgnoreCase);
            Match match = regex.Match(Input);
            if (match.Success)
            {
                StoreArgOne(match.Groups[1].Value);
                match = match.NextMatch();
                if (match.Success)
                {
                StoreArgTwo(match.Groups[1].Value);
                }
            } 
        }

        public void StoreArgOne(string s)
        {
            int num;
            CultureInfo provider = CultureInfo.InvariantCulture;
            bool result = int.TryParse(s, NumberStyles.AllowLeadingSign, provider, out num);
            if (result)
            {
                FirstNumArg = num;
                IsFirstConst = false;
            } else
            {
                FirstConstArg = s;
                IsFirstConst = true;
            }
        }

        public void StoreArgTwo(string s)
        {
            int num;
            CultureInfo provider = CultureInfo.InvariantCulture;
            bool result = int.TryParse(s, NumberStyles.AllowLeadingSign, provider, out num);
            if (result)
            {
                SecondNumArg = num;
                IsSecondConst = false;
            }
            else
            {
                SecondConstArg = s;
                IsSecondConst = true;
            }
        }

        public void GetOperator()
        {
            Regex regex = new Regex(@"[\d+|a-z]\s?([%\/\+\*=-])\s?-?[\d+|a-z]", RegexOptions.IgnoreCase);
            Match match = regex.Match(Input);
            if (match.Success)
            {
                Operand = match.Groups[1].Value;
            }
        }
    }
}
