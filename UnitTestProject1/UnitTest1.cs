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
            byte[] bytes = new byte[] { 0x55, 0x18, 0x37 };
            byte bit = bytes.GetBitValue(3);
            byte bit2 = bytes.GetBitValue(4);
            byte bit3 = bytes.GetBitValue(8);
            byte bit4 = bytes.GetBitValue(10);
            byte bit5 = bytes.GetBitValue(12);
            byte bit6 = bytes.GetBitValue(13);
            byte bit7 = bytes.GetBitValue(14);
            byte bit8 = bytes.GetBitValue(16);
            byte bit9 = bytes.GetBitValue(19);
            byte bit10 = bytes.GetBitValue(22);

            byte[] bytes1 = new byte[] { 0x37, 0x18, 0x55 };
            byte fbit = bytes1.GetBitValue(3, false);
            byte fbit2 = bytes1.GetBitValue(4, false);
            byte fbit3 = bytes1.GetBitValue(8, false);
            byte fbit4 = bytes1.GetBitValue(10, false);
            byte fbit5 = bytes1.GetBitValue(12, false);
            byte fbit6 = bytes1.GetBitValue(13, false);
            byte fbit7 = bytes1.GetBitValue(14, false);
            byte fbit8 = bytes1.GetBitValue(16, false);
            byte fbit9 = bytes1.GetBitValue(19, false);
            byte fbit10 = bytes1.GetBitValue(22, false);


            Assert.AreEqual(bit, fbit);
            Assert.AreEqual(bit2, fbit2);
            Assert.AreEqual(bit3, fbit3);
            Assert.AreEqual(bit4, fbit4);
            Assert.AreEqual(bit5, fbit5);
            Assert.AreEqual(bit6, fbit6);
            Assert.AreEqual(bit7, fbit7);
            Assert.AreEqual(bit8, fbit8);
            Assert.AreEqual(bit9, fbit9);
            Assert.AreEqual(bit10, fbit10);
        }
    }
}
