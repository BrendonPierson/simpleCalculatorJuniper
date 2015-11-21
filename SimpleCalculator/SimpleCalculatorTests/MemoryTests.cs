using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class MemoryTests
    {
        [TestMethod]
        public void MemoryEnsureCanInstantiate()
        {
            Memory mem = new Memory();
            Assert.IsNotNull(mem);
        }
        [TestMethod]
        public void MemoryEnsureCanAddLastCommand()
        {
            Memory mem = new Memory();
            mem.Lastq = " 3 + 1";
            Assert.AreEqual(" 3 + 1", mem.Lastq);
        }
        [TestMethod]
        public void MemoryEnsureCanAddLastAnswer()
        {
            Memory mem = new Memory();
            mem.Last = "43";
            Assert.AreEqual("43", mem.Last);
        }
        [TestMethod]
        public void MemoryEnsureCanAddConstant()
        {
            Memory mem = new Memory();
            mem.AddConstant("c",-2);
            Assert.AreEqual(-2, mem.Constants["c"]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MemoryEnsureExceptionWhenAddingSameConstant()
        {
            Memory mem = new Memory();
            mem.AddConstant("c", -2);
            mem.AddConstant("c", 2);
        }
        [TestMethod]
        public void MemoryEnsureConstantCanBeRetrieved()
        {
            Memory mem = new Memory();
            mem.AddConstant("z", -21);
            Assert.AreEqual(-21, mem.Constants["z"]);
        }
        [TestMethod]
        public void MemoryEnsureEmptyMemoryDoesntFail()
        {
            Memory mem = new Memory();
            Assert.AreEqual("There are no commands stored.", mem.Lastq);
        }
    }
}
