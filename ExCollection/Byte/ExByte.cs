using System;
using System.Collections.Generic;
using System.Text;

namespace ExCollection
{
    public static class ExByte
    {
        /// <summary>
        /// int转bytes数组
        /// </summary>
        /// <param name="data">值</param>
        /// <param name="big_Endian">是否为大端  举例：0x123456  big_endian:byte[0] = 0x12 byte[2] = 0x34 byte[3] = 0x56   little_endian:byte[0] = 0x56 byte[1] = 0x34 byte[2] = 0x12</param>
        /// <returns></returns>
        public static byte[] Int2Bytes(this int data, bool big_Endian = true)
        {
            byte[] result = new byte[4];
            if (big_Endian)
            {
                result[3] = (byte)((data >> 0) & 0xFF);
                result[2] = (byte)((data >> 8) & 0xFF);
                result[1] = (byte)((data >> 16) & 0xFF);
                result[0] = (byte)((data >> 24) & 0xFF);
            }
            else
            {
                result[0] = (byte)((data >> 0) & 0xFF);
                result[1] = (byte)((data >> 8) & 0xFF);
                result[2] = (byte)((data >> 16) & 0xFF);
                result[3] = (byte)((data >> 24) & 0xFF);
            }
            return result;
        }
        /// <summary>
        /// bytes转int，bytes.length>4时，截取最后四位字节数组
        /// </summary>
        /// <param name="data">byte数组</param>
        /// <param name="big_Endian">是否为大端  举例：0x123456  big_endian:byte[0] = 0x12 byte[2] = 0x34 byte[3] = 0x56   little_endian:byte[0] = 0x56 byte[1] = 0x34 byte[2] = 0x12</param>
        /// <returns></returns>
        public static int Bytes2Int(this byte[] data, bool big_Endian = true)
        {
            byte[] temp = null;
            if (data.Length > 4)
            {
                temp = new byte[4];
                System.Array.Copy(data, data.Length - 4, temp, 0, temp.Length);
            }
            else 
            {
                temp = data;
            }
            int result = 0;
            if (big_Endian)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    result |= (temp[i] << (temp.Length - 1 - i) * 8);
                }
            }
            else
            {
                for (int i = temp.Length - 1; i >= 0; i--)
                {
                    result |= (temp[i] << (i * 8));
                }
            }
            return result;
        }

        /// <summary>
        /// 将字节数组转换成16进制的字符串
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static string ToHexString(this byte[] body)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in body)
            {
                string data = item.ToString("X2");
                sb.Append(data);
                sb.Append(" ");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取使用BinaryWriter写入的String类型的字节长度以及数据字节长度
        /// </summary>
        /// <param name="data">字节数组</param>
        /// <param name="pos">字符串所在的下标位置</param>
        /// <param name="headLength">返回的字符串的表示长度的位数</param>
        /// <param name="dataLength">返回字符串实际数据长度</param>
        public static void GetStringLength(this byte[] data, int pos, out int headLength, out int dataLength)
        {
            dataLength = 0;
            headLength = 1;
            if (data != null && data.Length > 0 && data.Length > pos)
            {
                int index = 0;
                for (int i = pos; i < data.Length; i++)
                {
                    if (((data[i] >> 7) & 0x7f) > 0)
                    {
                        index++;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = index; i >= 0; i--)
                {
                    dataLength |= ((data[pos + i] & 0x7F) << (7 * i));
                }
                headLength = index + 1;
            }
            else
            {
                headLength = 0;
                dataLength = 0;
            }
        }
    }
}
