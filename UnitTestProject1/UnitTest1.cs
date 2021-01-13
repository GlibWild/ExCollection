using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExCollection;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestGetBitValue();
        }
        [TestMethod]
        public void TestMethod2() 
        {
            TestSetBitValue();
        }
        [TestMethod]
        public void TestMethod3() 
        {
            TestGetAttribute();
        }
        [TestMethod]
        public void TestMethod4() {
            TestHasBitValue();
        }

        private void TestHasBitValue()
        {
            byte[] temp = new byte[10];
            bool flag1 = temp.HasBitValue();
            temp = new byte[2] { 0xFF, 0xFF };
            bool flag2 = temp.HasBitValue(ExByte.Bit.Zero);
            bool flag3 = temp.HasBitValue(ExByte.Bit.One);
        }

        private void TestGetAttribute()
        {
            var state = GpsState.Test2State.GetCustomAttribute<StateAttribute>();
            Console.WriteLine($"{state.Description}");
        }

        public class StateAttribute : Attribute
        {

            public Dictionary<int, string> Description { get; set; }
            /// <summary>
            /// 设置状态描述,以:,进行分隔
            /// 注意<paramref name="Description">在状态内容中不允许出现:与,，否则可能导致异常</paramref>
            /// 例如：State("0:关闭,1:打开")
            /// 如果值与下标一致 则可以简写为：State("关闭,打开")
            /// 或者：State("关闭,2:打开") 使用此模式，后面参数必须均携带序号，否则异常
            /// </summary>
            /// <param name="Description"></param>
            public StateAttribute(string Description)
            {
                string[] item = Description.Split(new string[] { "," }, StringSplitOptions.None);
                this.Description = new Dictionary<int, string>();
                bool flag = false;
                for (int i = 0; i < item.Length; i++)
                {
                    if (!item[i].Contains(":"))
                    {
                        if (!flag)
                            this.Description.Add(i, item[i]);
                        else
                            throw new Exception("参数异常");
                    }
                    else
                    {
                        flag = true;
                        var data = item[i].Split(":");
                        if (data.Length > 1)
                        {
                            try
                            {
                                this.Description.Add(int.Parse(data[0]), data[1]);
                            }
                            catch
                            {
                                throw new Exception("参数异常");
                            }
                        }
                        else
                            throw new Exception("参数异常");
                    }
                }
            }
        }
        public enum GpsState
        {
            [State("1:测试")]
            TestState = 0,
            [State("测试1,测试2")]
            Test2State = 1,
        }

        private static void TestGetBitValue()
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

        private void TestSetBitValue()
        {
            byte[] bytes = new byte[] { 0x55, 0x18, 0x37 };
            byte[] result = bytes.SetBitValue(0, 0);
            byte[] result2 = bytes.SetBitValue(3, 1);
            byte[] result3 = bytes.SetBitValue(4, 0);
            byte[] result4 = bytes.SetBitValue(11, 0);


            byte[] bytes1 = new byte[] { 0x37, 0x18, 0x55 };
            byte[] fresult = bytes1.SetBitValue(0, 0, false);
            byte[] fresult2 = bytes1.SetBitValue(3, 1, false);
            byte[] fresult3 = bytes1.SetBitValue(4, 0, false);
        }
    }
}
