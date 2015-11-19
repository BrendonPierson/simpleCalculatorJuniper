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
        public void ParseCanCheckIfFirstIsNegative()
        {
            Parse parse = new Parse("-1 + 2");
            parse.CheckIfFirstArgIsNegative();
            Assert.IsTrue(parse.FirstNeg);
        }
        [TestMethod]
        public void ParseCanParseTwoNegativeNumbers()
        {
            Parse parse = new Parse("-1 + -2");
            parse.CreateEquation();
            Assert.AreEqual(-1, parse.FirstArg);
            Assert.AreEqual(-2, parse.SecondArg);
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
        public void ParseCanHaveNegativeFirstArg()
        {
            Parse parse = new Parse("-1 + 2");
            parse.CheckIfFirstArgIsNegative();
            parse.GetArgs();
            parse.GetOperand();
            Assert.AreEqual(-1, parse.FirstArg);
            Assert.AreEqual(2, parse.SecondArg);
        }
        [TestMethod]
        public void ParseCanRemoveNegSigns()
        {
            Parse parse = new Parse("-1 + -2");
            parse.CheckIfFirstArgIsNegative();
            parse.GetOperand();
            Assert.AreEqual("1 + 2", parse.Input);
        }
        [TestMethod]
        public void ParseCanSubtractNegatives()
        {
            Parse parse = new Parse("-1 - -2");
            parse.CreateEquation();
            Assert.AreEqual(-1, parse.FirstArg);
            Assert.AreEqual(-2, parse.SecondArg);
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
            Parse parse = new Parse("1+ *2");
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
