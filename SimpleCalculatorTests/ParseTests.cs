using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class ParseTests
    {
        /*Prove you can extract the terms of the expression.
        Prove you can extract the operation embedded in the expression.
        Ensure you have examples of GOOD and BAD input and have the class throw an exception where there are errors.*/
        [TestMethod]
        public void ParseEnsureCaneInstantiate()
        {
            Parse parse = new Parse();
            Assert.IsNotNull(parse);
        }
    }
}
