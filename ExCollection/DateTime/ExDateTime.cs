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
    }
}
