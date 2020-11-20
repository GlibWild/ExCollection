using System;
using System.Collections.Generic;
using System.Text;

namespace ExCollection
{
    public class ExDegree
    {
        private const double EARTH_RADIUS = 6378137.0;//地球赤道半径(单位：m。6378137m是1980年的标准，比1975年的标准6378140少3m）

        /// <summary>
        /// 角度数转换为弧度公式
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double radians(double d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        /// 弧度转换为角度数公式
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double degrees(double d)
        {
            return d * (180 / Math.PI);
        }

        /// <summary>
        /// 计算两点之间的距离
        /// 单位：米
        /// </summary>
        /// <param name="Degree1"></param>
        /// <param name="Degree2"></param>
        /// <returns></returns>
        public static double GetDistance(Degree Degree1, Degree Degree2)
        {
            double radLat1 = radians(Degree1.Y);
            double radLat2 = radians(Degree2.Y);
            double a = radLat1 - radLat2;
            double b = radians(Degree1.X) - radians(Degree2.X);

            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }

        /// <summary>
        /// 计算两个经纬度之间的直接距离(google 算法)
        /// </summary>
        public static double GetDistanceGoogle(Degree Degree1, Degree Degree2)
        {
            double radLat1 = radians(Degree1.Y);
            double radLng1 = radians(Degree1.X);
            double radLat2 = radians(Degree2.Y);
            double radLng2 = radians(Degree2.X);

            double s = Math.Acos(Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Cos(radLng1 - radLng2) + Math.Sin(radLat1) * Math.Sin(radLat2));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }

        /// <summary>
        /// 以一个经纬度为中心计算出四个顶点
        /// </summary>
        /// <param name="Degree1">中心点</param>
        /// <param name="distance">半径(米)</param>
        /// <returns></returns>
        public static Degree[] GetDegreeCoordinates(Degree Degree1, double distance)
        {
            double dlng = 2 * Math.Asin(Math.Sin(distance / (2 * EARTH_RADIUS)) / Math.Cos(Degree1.X));
            dlng = degrees(dlng);//一定转换成角度数

            double dlat = distance / EARTH_RADIUS;
            dlat = degrees(dlat);//一定转换成角度数

            return new Degree[] { new Degree(Math.Round(Degree1.X - dlng,6), Math.Round(Degree1.Y + dlat,6)),//left-top
                                   new Degree(Math.Round(Degree1.X - dlng,6), Math.Round(Degree1.Y - dlat,6)),//left-bottom
                                   new Degree(Math.Round(Degree1.X + dlng,6), Math.Round(Degree1.Y + dlat,6)),//right-top
                                   new Degree(Math.Round(Degree1.X + dlng,6), Math.Round(Degree1.Y - dlat,6)) //right-bottom
            };
        }
    }
}
