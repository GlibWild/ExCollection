using System;
using System.Collections.Generic;
using System.Text;

namespace ExCollection
{
    public static class ExDateTime
    {
        /// <summary>
        /// 根据传入日期获取该日期所在的季度的开始时间以及季度的结束时间，以及是第几季度
        /// </summary>
        /// <param name="Time">输入的日期</param>
        /// <param name="startTime">返回季度开始时间</param>
        /// <param name="stopTime">返回季度结束时间</param>
        /// <returns>返回所属季度</returns>
        public static int GetQuarterTime(this DateTime Time, out DateTime startTime, out DateTime stopTime)
        {
            int baseMonth = Time.Month - 1;
            int MonthLen = baseMonth / 3;
            startTime = new DateTime(Time.Year, 1 + MonthLen * 3, 1);
            stopTime = startTime.AddMonths(3).AddMilliseconds(-1);
            return (startTime.Month + 2) / 3;
        }
        /// <summary>
        /// 比较两个时间点是否属于同一自然周
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="Time2"></param>
        /// <returns></returns>
        public static bool IsInWeek(this DateTime Time, DateTime Time2)
        {
            bool flag = false;
            var largerTime = Time > Time2 ? Time : Time2;
            var lessTime = Time < Time2 ? Time : Time2;
            var ts = largerTime - lessTime;
            var totalDays = ts.TotalDays;
            var largerWeek = (int)largerTime.DayOfWeek;
            if (largerWeek == 0)
            {
                largerWeek = 7;
            }
            if (totalDays >= 7 || totalDays >= largerWeek)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// 比较两个时间点是否属于同一自然月
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="Time2"></param>
        /// <returns></returns>
        public static bool IsInMonth(this DateTime Time, DateTime Time2)
        {
            bool flag = true;
            if (Time.Year == Time2.Year && Time.Month == Time2.Month)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// 比较两个时间点是否属于同一季度
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="Time2"></param>
        /// <returns></returns>
        public static bool IsInQuarterTime(this DateTime Time, DateTime Time2)
        {
            int quarter1 = Time.GetQuarterTime(out _, out _);
            int quarter2 = Time.GetQuarterTime(out _, out _);
            return quarter1 == quarter2;
        }
        /// <summary>
        /// 比较两个时间点是否属于同一半年（自然年）
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="Time2"></param>
        /// <returns></returns>
        public static bool IsInHalfYear(this DateTime Time, DateTime Time2)
        {
            bool flag = false;
            if (Time.Year == Time2.Year)
            {
                var t1 = Time.Month / 7 > 0;
                var t2 = Time2.Month / 7 > 0;
                if (t1 == t2)
                {
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// 比较两个时间点是否属于同一年（自然年）
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="Time2"></param>
        /// <returns></returns>
        public static bool IsInYear(this DateTime Time, DateTime Time2)
        {
            bool flag = false;
            if (Time.Year == Time2.Year)
            {
                flag = true;
            }
            return flag;
        }
    }
}
