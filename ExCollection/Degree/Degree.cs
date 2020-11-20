using System;
using System.Collections.Generic;
using System.Text;

namespace ExCollection
{
    public class Degree
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x">经度</param>
        /// <param name="y">纬度</param>
        public Degree(double x, double y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// 经度
        /// </summary>
        private double x;
        /// <summary>
        /// 经度
        /// </summary>
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        private double y;
        /// <summary>
        /// 纬度
        /// </summary>
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
