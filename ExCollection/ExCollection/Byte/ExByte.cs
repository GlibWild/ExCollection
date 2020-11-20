using System;
using System.Collections.Generic;
using System.Text;

namespace ExCollection
{
    public static class ExByte
    {
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
