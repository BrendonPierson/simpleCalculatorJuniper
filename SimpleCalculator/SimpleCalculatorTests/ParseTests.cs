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
        public void ParseCanGetOperand()
        {
            Parse parse = new Parse("1 + 2");
            parse.GetOperand();
            Assert.AreEqual("+", parse.Operand);
        }
        [TestMethod]
        public void ParseCanGetArgs()
        {
            Parse parse = new Parse("1 + 2");
            parse.GetArgs();
            Assert.AreEqual(1, parse.FirstArg);
            Assert.AreEqual(2, parse.SecondArg);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseNoOperatorError()
        {
            Parse parse = new Parse("1 2");
            parse.GetOperand();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseTwoOperatorError()
        {
            Parse parse = new Parse("1+ - 2");
            parse.GetOperand();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseOneArgumentError()
        {
            Parse parse = new Parse("1+");
            parse.GetArgs();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseThreeArgumentError()
        {
            Parse parse = new Parse("1 + 2 / 4");
            parse.GetArgs();
        }
    }
}
