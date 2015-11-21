using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Evaluate
    {
        private Memory mem;
        private Operation op;
        public Parse ParsedInput { get; set; }
        public string Answer { get; set; }

        public Evaluate()
        {
            mem = new Memory();
            op = new Operation();
        }
        public Evaluate(Parse parse)
        {
            ParsedInput = parse;
            op = new Operation();
            mem = new Memory();
        }
        
        public void Execute()
        {
            if (ParsedInput.IsCommand)
            {
                ExecuteCommand();
            }
            else if (!ParsedInput.IsGoodInput)
            {
                Answer = "I'm sorry, that isn't formatted correctly";
            }
            else if (ParsedInput.IsConstantAssignment)
            {
                mem.Lastq = ParsedInput.Input;
                mem.AddConstant(ParsedInput.FirstConstArg, ParsedInput.SecondNumArg);
                Answer = $"Stored: {ParsedInput.FirstConstArg} = {mem.Constants[ParsedInput.FirstConstArg]}";
            }
            else
            {
                mem.Lastq = ParsedInput.Input;
                Answer = Compute().ToString();
            }
        }

        public void ExecuteCommand()
        {
            switch (ParsedInput.Command)
            {
                case "last":
                    Answer = mem.Last;
                    break;
                case "lastq":
                    Answer = mem.Lastq;
                    break;
                case "exit":
                    Answer = "exit";
                    break;
            }
        }

        public void SubstituteConstants()
        {
            if (ParsedInput.IsFirstConst)
            {
                ParsedInput.FirstNumArg = mem.Constants[ParsedInput.FirstConstArg];
            }
            if (ParsedInput.IsSecondConst)
            {
                ParsedInput.SecondNumArg = mem.Constants[ParsedInput.SecondConstArg];
            }
        }

        public int Compute()
        {
            SubstituteConstants();
            switch (ParsedInput.Operand)
            {
                case "+":
                    mem.Last = op.Add(ParsedInput.FirstNumArg, ParsedInput.SecondNumArg).ToString();
                    return op.Add(ParsedInput.FirstNumArg, ParsedInput.SecondNumArg);
                case "-":
                    mem.Last = op.Sub(ParsedInput.FirstNumArg, ParsedInput.SecondNumArg).ToString();
                    return op.Sub(ParsedInput.FirstNumArg, ParsedInput.SecondNumArg);
                case "*":
                    mem.Last = op.Mult(ParsedInput.FirstNumArg, ParsedInput.SecondNumArg).ToString();
                    return op.Mult(ParsedInput.FirstNumArg, ParsedInput.SecondNumArg);
                case "/":
                    mem.Last = op.Div(ParsedInput.FirstNumArg, ParsedInput.SecondNumArg).ToString();
                    return op.Div(ParsedInput.FirstNumArg, ParsedInput.SecondNumArg);
                case "%":
                    mem.Last = op.Mod(ParsedInput.FirstNumArg, ParsedInput.SecondNumArg).ToString();
                    return op.Mod(ParsedInput.FirstNumArg, ParsedInput.SecondNumArg);
            }   
            return 0;
        }
    }
}
