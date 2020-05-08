using lab8._2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var path = @"C:\Users\mikl1\Downloads\Apteki.xml";
            var res = check_class.check_tree(path);
            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var path = @"C:\Users\mikl1\Downloads\Apteki2.xml";
            var res = check_class.check_tree(path);
            Assert.AreEqual(res, false);
        }
    }
}