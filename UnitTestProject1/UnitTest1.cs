using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExCollection;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int i = -330;
            byte[] bytes = i.Int2Bytes();
            byte[] bytes1 = i.Int2Bytes(false);

            int t1 = bytes.Bytes2Int();
            int t2 = bytes1.Bytes2Int(false);
            

            Assert.AreEqual(i, t1);
            Assert.AreEqual(i, t2);
        }
    }
}
