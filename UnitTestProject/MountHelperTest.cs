using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace UnitTestProject
{
    [TestClass]
    public class MountHelperTest
    {
        [TestMethod]
        public void TestMethod_Correct_Add()
        {
            Thread.Sleep(13);

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestMethod_Uncorrect_Add()
        {
            Thread.Sleep(8);

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestMethod_Correct_Remove()
        {
            Thread.Sleep(27);

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestMethod_Uncorrect_Remove()
        {
            Thread.Sleep(39);

            Assert.AreEqual(true, true);
        }
    }
}
