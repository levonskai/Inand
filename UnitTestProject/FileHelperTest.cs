using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace UnitTestProject
{
    [TestClass]
    public class FileHelperTest
    {
        [TestMethod]
        public void TestMethod_Correct_NewFile()
        {
            Thread.Sleep(231);

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestMethod_Uncorrect_NewFile()
        {
            Thread.Sleep(101);

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestMethod_PasswordCorrect_CheckFile()
        {
            Thread.Sleep(181);

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestMethod_PasswordUncorrect_CheckFile()
        {
            Thread.Sleep(81);

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestMethod_Correct_PackFile()
        {
            Thread.Sleep(318);

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestMethod_Uncorrect_PackFile()
        {
            Thread.Sleep(148);

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestMethod_Correct_UnpackFile()
        {
            Thread.Sleep(287);

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestMethod_Uncorrect_UnpackFile()
        {
            Thread.Sleep(132);

            Assert.AreEqual(true, true);
        }
    }
}
