using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class ParseTests
    {
        [TestMethod]
        public void ParseEnsureCanInstantiate()
        {
            Parse parse = new Parse();
            Assert.IsNotNull(parse);
        }
        [TestMethod]
        public void ParseCanAcceptStringArgument()
        {
            Parse parse = new Parse("1 + 2");
            Assert.AreEqual("1 + 2", parse.Input);
        }
        [TestMethod]
        public void ParseCanCheckForGoodInput()
        {
            Parse parse = new Parse("1 + 2");
            Assert.IsTrue(parse.CheckInput());
        }
        [TestMethod]
        public void ParseCheckForConstantAssignment()
        {
            Parse parse = new Parse("c =2");
            parse.CheckForConstAssignment();
            Assert.IsTrue(parse.IsConstantAssignment);
        }
        [TestMethod]
        public void ParseCanFindCommands()
        {
            Parse parse = new Parse("last");
            parse.CheckForCommand();
            Assert.AreEqual("last", parse.Command);
            Assert.IsTrue(parse.IsCommand);
        }
        [TestMethod]
        public void ParseCanPullOutTwoArgumentNumbers()
        {
            Parse parse = new Parse("1 + -2");
            parse.PullOutArguments();
            Assert.AreEqual(1, parse.FirstNumArg);
            Assert.AreEqual(-2, parse.SecondNumArg);
        }
        [TestMethod]
        public void ParseCanPullOutnumberAndConstant()
        {
            Parse parse = new Parse("c + -2");
            parse.PullOutArguments();
            Assert.AreEqual("c", parse.FirstConstArg);
            Assert.AreEqual(-2, parse.SecondNumArg);
        }
        [TestMethod]
        public void ParseCanStoreOperator()
        {
            Parse parse = new Parse("1 + 2");
            parse.GetOperator();
            Assert.AreEqual("+", parse.Operand);
        }
        [TestMethod]
        public void ParseCanOperatorWithNegatives()
        {
            Parse parse = new Parse("c = -2");
            parse.GetOperator();
            Assert.AreEqual("=", parse.Operand);
        }
        [TestMethod]
        public void ParseNoOperatorError()
        {
            Parse parse = new Parse("1 2");
            parse.CheckInput();
            Assert.IsFalse(parse.IsGoodInput);
        }
        [TestMethod]
        public void ParseTwoOperatorError()
        {
            Parse parse = new Parse("1+ *2");
            parse.CheckInput();
            Assert.IsFalse(parse.IsGoodInput);
        }
        [TestMethod]
        public void ParseOneArgumentError()
        {
            Parse parse = new Parse("1+");
            parse.CheckInput();
            Assert.IsFalse(parse.IsGoodInput);
        }
        [TestMethod]
        public void ParseThreeArgumentError()
        {
            Parse parse = new Parse("1 + 2 / 4");
            parse.CheckInput();
            Assert.IsFalse(parse.IsGoodInput);
        }
        [TestMethod]
        public void ParseTwoLetterConstant()
        {
            Parse parse = new Parse("bb + 3");
            parse.CheckInput();
            Assert.IsFalse(parse.IsGoodInput);
        }
        [TestMethod]
        public void ParseCanComputeAllNumVariables()
        {
            Parse parse = new Parse("-2 * 11");
            parse.Compute();
            Assert.AreEqual(-2, parse.FirstNumArg);
            Assert.AreEqual("*", parse.Operand);
            Assert.AreEqual(11, parse.SecondNumArg);
        }
        [TestMethod]
        public void ParseCanComputeAllConstVariables()
        {
            Parse parse = new Parse("c - d");
            parse.Compute();
            Assert.AreEqual("c", parse.FirstConstArg);
            Assert.AreEqual("-", parse.Operand);
            Assert.AreEqual("d", parse.SecondConstArg);
        }
    }
}
