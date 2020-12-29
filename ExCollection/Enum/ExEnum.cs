using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace ExCollection
{
    public static class ExEnum
    {
        /// <summary>
        /// 获取枚举描述 搭配<Description>特性使用
        /// </summary>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var field = type.GetField(enumValue.ToString());
            var desc = field.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (desc != null)
            {
                return desc.Description;
            }
            return string.Empty;
        }

        public static T GetCustomAttribute<T>(this Enum enumValue) where T:class
        {
            var type = enumValue.GetType();
            var field = type.GetField(enumValue.ToString());
            var desc = field.GetCustomAttribute(typeof(T)) as T;
            if (desc != null)
            {
                return desc;
            }
            return null;
        }
    }
}
