using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class EvaluateTests
    {
        [TestMethod]
        public void EvaluateEnsureCanInstantiate()
        {
            Evaluate eval = new Evaluate();
            Assert.IsNotNull(eval);
        }
        [TestMethod]
        public void EvaluateCanInstantiateWithParseObj()
        {
            Parse parse = new Parse("1 / 3");
            parse.Compute();
            Evaluate eval = new Evaluate(parse);
            Assert.AreEqual(parse, eval.ParsedInput);
            Assert.AreEqual(1, eval.ParsedInput.FirstNumArg);
        }
        [TestMethod]
        public void EvaluateCanReturnBlankExecuteCommand()
        {
            Parse parse = new Parse("lastq");
            Evaluate eval = new Evaluate(parse);
            eval.ExecuteCommand();
            Assert.AreEqual("There are no commands stored.", eval.Answer);
        }
        [TestMethod]
        public void EvaluateCanReturnExecuteCommand()
        {
            Parse parse = new Parse("1 + 5");
            Evaluate eval = new Evaluate(parse);
            eval.Execute();
            Parse parseTwo = new Parse("lastq");
            eval.ParsedInput = parseTwo;
            eval.Execute();
            Assert.AreEqual("1 + 5", eval.Answer);
        }
        [TestMethod]
        public void EvaluateCanAssignConstant()
        {
            Parse parse = new Parse("q= 7");
            Evaluate eval = new Evaluate(parse);
            eval.Execute();
            Assert.AreEqual("Stored: q = 7", eval.Answer);
        }
        [TestMethod]
        public void EvaluateCanExecuteBasicOperation()
        {
            Parse parse = new Parse("1 + 5");
            Evaluate eval = new Evaluate(parse);
            eval.Execute();
            Assert.AreEqual("6", eval.Answer);
        }
        [TestMethod]
        public void EvaluateCanSubstitueConstants()
        {
            Parse parse = new Parse("q= 7");
            Evaluate eval = new Evaluate(parse);
            eval.Execute();
            Parse parseTwo = new Parse("q + 5");
            eval.ParsedInput = parseTwo;
            eval.SubstituteConstants();
            Assert.AreEqual(7, eval.ParsedInput.FirstNumArg);
        }
        [TestMethod]
        public void EvaluateCanExecuteExpressionWithConstants()
        {
            Parse parse = new Parse("q= 7");
            Evaluate eval = new Evaluate(parse);
            eval.Execute();
            Parse parseTwo = new Parse("q + 5");
            eval.ParsedInput = parseTwo;
            eval.Execute();
            Assert.AreEqual("12", eval.Answer);
        }
    }
}
