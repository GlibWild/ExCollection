using System;
using System.Collections.Generic;
using System.Text;

namespace ExCollection
{
    public unsafe static class ExByte
    {
        /// <summary>
        /// 获取指定位的值(0或1)
        /// </summary>
        /// <param name="src"></param>
        /// <param name="position"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static int GetBitValue(this uint src, int position)
        {
            int temp = 1;
            return (int)(src >> position) & temp;
        }

        public static byte GetBitValue(this ushort src, int position)
        {
            int temp = 1;
            return (byte)((src >> position) & temp);
        }
        public static byte GetBitValue(this byte src, int position)
        {
            int temp = 1;
            return (byte)((src >> position) & temp);
        }
        public static byte GetBitValue(this byte[] src, int position, bool isBig = true)
        {
            int index = position / 8; ;
            int temp = 1;
            if (isBig)
            {
                index = src.Length - index - 1;

            }
            int res = position % 8;
            byte aim = src[index];
            return (byte)((aim >> res) & temp);
        }

        /// <summary>
        /// 设置指定位的值(0或1)
        /// </summary>
        /// <param name="src"></param>
        /// <param name="position"></param>
        /// <param name="val">0/1</param>
        public static uint SetBitValue(this uint src, int position, int val)
        {
            src = val == 0 ? src & (uint)(~(0x1 << position)) : src | (uint)(0x1 << position);
            return src;
        }

        /// <summary>
        /// 设置指定位的值(0或1)
        /// </summary>
        /// <param name="src"></param>
        /// <param name="position"></param>
        /// <param name="val">0/1</param>
        public static int SetBitValue(this int src, int position, int val)
        {
            src = val == 0 ? src & (~(0x1 << position)) : src | (0x1 << position);
            return src;
        }

        /// <summary>
        /// 设置指定位的值(0或1)
        /// </summary>
        /// <param name="src"></param>
        /// <param name="position"></param>
        /// <param name="val">0/1</param>
        public static byte[] SetBitValue(this byte[] src, int position, int val,bool isBig = true)
        {
            byte[] bytes = new byte[src.Length];
            src.CopyTo(bytes, 0);
            int index = position / 8;

            if (isBig)
            {
                index = bytes.Length - index - 1;

            }
            int res = position % 8;
            bytes[index] = val == 0 ? (byte)(bytes[index] & (byte)(~(0x01 << res))) : (byte)(bytes[index] | (byte)(0x01 << res));
            return bytes;
        }

        /// <summary>
        /// 字节数组转ushort
        /// </summary>
        /// <param name="data">字节数组</param>
        /// <param name="pos">数组指定开始下标</param>
        /// <param name="isBig">是否为大端模式</param>
        /// <returns></returns>
        public static ushort GetUShort(this byte[] data, int pos, bool isBig = true)
        {
            if (isBig)
            {
                ushort tmp = (ushort)((data[0 + pos] << 8) | data[1 + pos]);
                return tmp;
            }
            else
            {
                ushort tmp = (ushort)((data[1 + pos] << 8) | data[0 + pos]);
                return tmp;
            }
        }
        /// <summary>
        /// 字节数组转uint
        /// </summary>
        /// <param name="data">字节数组</param>
        /// <param name="pos">数组指定开始下标</param>
        /// <param name="isBig">是否为大端模式</param>
        /// <returns></returns>
        public static uint GetUInt(this byte[] data, int pos, bool isBig = true)
        {
            if (isBig)
            {
                uint tmp = (uint)((data[pos] << 24) | (data[1 + pos] << 16) | (data[2 + pos] << 8) | data[3 + pos]);
                return tmp;
            }
            else
            {
                uint tmp = (uint)((data[3 + pos] << 24) | (data[2 + pos] << 16) | (data[1 + pos] << 8) | data[0 + pos]);
                return tmp;
            }
        }
        /// <summary>
        /// 字节数组转long
        /// </summary>
        /// <param name="data">数组</param>
        /// <param name="pos">数组指定开始下标</param>
        /// <param name="isBig">是否为大端模式</param>
        /// <returns></returns>
        public static long GetLong(this byte[] data, int pos, bool isBig = true)
        {
            if (isBig)
            {
                long tmp = (((long)data[pos] << 56) | ((long)data[1 + pos] << 48) | ((long)data[2 + pos] << 40) | ((long)data[3 + pos] << 32) | ((long)data[4 + pos] << 24) | ((long)data[5 + pos] << 16) | ((long)data[6 + pos] << 8) | ((long)data[7 + pos]));
                return tmp;
            }
            else
            {
                long tmp = (((long)data[7 + pos] << 56) | ((long)data[6 + pos] << 48) | ((long)data[5 + pos] << 40) | ((long)data[4 + pos] << 32) | ((long)data[3 + pos] << 24) | ((long)data[2 + pos] << 16) | ((long)data[1 + pos] << 8) | ((long)data[pos]));
                return tmp;
            }
        }

        /// <summary>
        /// WORD字节码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this ushort value)
        {
            ushort tmp = value;
            byte[] data = new byte[2];
            for (int i = data.Length - 1; i >= 0; i--)
            {
                data[i] = (byte)(tmp & 0xFF);
                tmp = (ushort)(tmp >> 8);
            }
            return data;
        }

        /// <summary>
        /// DWORD字节码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this uint value)
        {
            byte[] data = new byte[4];
            byte[] high = GetBytes((ushort)((value >> 16) & 0xFFFF));
            byte[] low = GetBytes((ushort)(value & 0xFFFF));
            Buffer.BlockCopy(high, 0, data, 0, 2);
            Buffer.BlockCopy(low, 0, data, 2, 2);
            return data;
        }

        /// <summary>
        /// 获取字符串字节码(GBK编码)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this string str)
        {
            return Encoding.GetEncoding("GBK").GetBytes(str);
        }

        /// <summary>
        /// 填充数组
        /// </summary>
        /// <param name="data">原数组</param>
        /// <param name="totalLength">总长度</param>
        /// <param name="pad">填充位置</param>
        /// <param name="c">填充数据</param>
        /// <returns></returns>
        public static byte[] FixBytes(this byte[] data, int totalLength, Pad pad, char c)
        {
            byte fill = (byte)c;
            byte[] bytes = new byte[totalLength];
            if (data.Length < totalLength)
            {
                int offset = totalLength - data.Length;
                byte[] temp = new byte[offset];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = fill;
                }
                switch (pad)
                {
                    case Pad.padLeft:
                        Array.Copy(temp, 0, bytes, 0, temp.Length);
                        Array.Copy(data, 0, bytes, temp.Length, data.Length);
                        break;
                    case Pad.padRight:
                        Array.Copy(data, 0, bytes, 0, data.Length);
                        Array.Copy(temp, 0, bytes, data.Length, temp.Length);
                        break;
                }
            }
            else
            {
                Array.Copy(data, 0, bytes, 0, data.Length);
            }
            return bytes;
        }

        /// <summary>
        /// DateTime转BCD码字节数组
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static byte[] GetDateTimeBCD(this DateTime dateTime)
        {
            string timeStr = dateTime.ToString("yyMMddHHmmss");
            byte[] data = new byte[6];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)((Convert.ToByte(timeStr[i * 2].ToString()) << 4) | Convert.ToByte(timeStr[i * 2 + 1].ToString()));
            }
            return data;
        }
        public static DateTime ParseDateTime(this byte[] data)
        {
            StringBuilder timeStrBuf = new StringBuilder();
            timeStrBuf.Append("20");
            for (int i = 0; i < data.Length; i++)
            {
                timeStrBuf.Append(Convert.ToString((data[i] >> 4) & 0xF));
                timeStrBuf.Append(Convert.ToString(data[i] & 0xF));
                if (i < 2)
                {
                    timeStrBuf.Append("-");
                }
                else if (i < 3)
                {
                    timeStrBuf.Append(" ");
                }
                else if (i < data.Length - 1)
                {
                    timeStrBuf.Append(":");
                }
            }
            return Convert.ToDateTime(timeStrBuf.ToString());
        }
        /// <summary>
        /// bytes 转double
        /// </summary>
        /// <param name="m_buffer"></param>
        /// <returns></returns>
        public static double ReadDouble(this byte[] m_buffer)
        {
            uint num = (uint)(m_buffer[0] | (m_buffer[1] << 8) | (m_buffer[2] << 16) | (m_buffer[3] << 24));
            uint num2 = (uint)(m_buffer[4] | (m_buffer[5] << 8) | (m_buffer[6] << 16) | (m_buffer[7] << 24));
            ulong num3 = ((ulong)num2 << 32) | num;
            return *(double*)(&num3);
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
        /// <summary>
        /// 方向
        /// </summary>
        public enum Pad
        {
            padLeft = 0,
            padRight = 1
        }
    }
}
