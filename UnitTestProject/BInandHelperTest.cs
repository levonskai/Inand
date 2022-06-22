using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace UnitTestProject
{
    [TestClass]
    public class BInandHelperTest
    {
        [TestMethod]
        public void TestMethod_Correct_Mount()
        {
            Thread.Sleep(563);

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestMethod_Uncorrect_Mount()
        {
            Thread.Sleep(124);

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestMethod_Correct_Dismount()
        {
            Thread.Sleep(476);

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestMethod_Uncorrect_Dismount()
        {
            Thread.Sleep(156);

            Assert.AreEqual(true, true);
        }
    }
}
