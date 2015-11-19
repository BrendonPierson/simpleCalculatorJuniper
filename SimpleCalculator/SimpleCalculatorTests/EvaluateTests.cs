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
        public void EvaluateCanAdd()
        {
            Evaluate eval = new Evaluate();
            int actual = eval.Add(5, 2);
            Assert.AreEqual(7, actual);
        }
        [TestMethod]
        public void EvaluateCanSubtract()
        {
            Evaluate eval = new Evaluate();
            int actual = eval.Sub(5, 2);
            Assert.AreEqual(3, actual);
        }
        [TestMethod]
        public void EvaluateCanMultiply()
        {
            Evaluate eval = new Evaluate();
            int actual = eval.Mult(5, 2);
            Assert.AreEqual(10, actual);
        }
        [TestMethod]
        public void EvaluateCanDivide()
        {
            Evaluate eval = new Evaluate();
            int actual = eval.Div(10, 2);
            Assert.AreEqual(5, actual);
        }
        [TestMethod]
        public void EvaluateCanModulus()
        {
            Evaluate eval = new Evaluate();
            int actual = eval.Mod(10, 2);
            Assert.AreEqual(0, actual);
        }
        [TestMethod]
        public void EvaluateCanChooseCorrectOperation()
        {
            Evaluate eval = new Evaluate(3, 4, "+");
            var actual = eval.Compute();
            Assert.AreEqual(7, actual);
        }
        [TestMethod]
        public void EvaluateCanUseParsedString()
        {
            Parse parse = new Parse("3 + 9");
            Evaluate eval = new Evaluate(parse.FirstArg, parse.SecondArg, parse.Operand);
            var actual = eval.Compute();
            Assert.AreEqual(12, actual);
        }
    }
}
