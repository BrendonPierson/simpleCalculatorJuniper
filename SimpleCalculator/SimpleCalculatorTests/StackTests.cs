using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void StackEnsureCanInstantiate()
        {
            Stack stack = new Stack();
            Assert.IsNotNull(stack);
        }
    }
}
