using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App;

namespace test_time_out
{
    [TestClass]
    public class UnitTest1
    {
        ///TestMethod1:
        game g = new game("Adam");
        ///TestMethod2,TestMethod3:
        Playing p = new Playing("Adam", "Yosef");
        ///TestMethod4:
        ShowFrindList s = new ShowFrindList("Adam");


        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(g.MyUsername=="Adam");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsTrue(p.MyUserName == "Adam");
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.IsTrue(p.VsPlayer == "Yosef");
        }
        [TestMethod]
        public void TestMethod4()
        {
            Assert.IsTrue(s.MyUserName == "Adam");
        }
      
    }
}
