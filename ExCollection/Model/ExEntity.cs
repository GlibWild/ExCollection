using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace ExCollection
{
    public static class ExEntity
    {
        #region xml 序列化和反序列化实现实体类深复制
        public static T DeepCopyByXml<T>(this T obj)
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    xml.Serialize(ms, obj);
                    ms.Seek(0, SeekOrigin.Begin);
                    retval = xml.Deserialize(ms);
                    ms.Close();
                }
                catch (InvalidOperationException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return (T)retval;
        }
        #endregion
        #region 实体类字段比较
        /// <summary>
        /// 比较--两个类型一样的实体类对象的值
        /// </summary>
        /// <param name="oneT"></param>
        /// <param name="twoT"></param>
        /// <param name="toChild">是否透传至子对象</param>
        /// <param name="excludeNames">不比较对象名称</param>
        /// <returns></returns>
        public static bool CompareType<T>(this T oneT, T twoT, bool toChild = true, params string[] excludeNames)
        {
            bool result = true;//两个类型作比较时使用,如果有不一样的就false
            Type typeOne = oneT.GetType();
            Type typeTwo = twoT.GetType();
            //如果两个T类型不一样  就不作比较
            if (!typeOne.Equals(typeTwo)) { return false; }
            PropertyInfo[] pisOne = typeOne.GetProperties(); //获取所有公共属性(Public)
            PropertyInfo[] pisTwo = typeTwo.GetProperties();
            ////如果长度为0返回false
            //if (pisOne.Length <= 0 || pisTwo.Length <= 0)
            //{
            //    return false;
            //}
            //如果长度不一样，返回false
            if (!(pisOne.Length.Equals(pisTwo.Length))) { return false; }
            //遍历两个T类型，遍历属性，并作比较
            for (int i = 0; i < pisOne.Length; i++)
            {
                //获取属性名
                string oneName = pisOne[i].Name;
                string twoName = pisTwo[i].Name;

                if (excludeNames.Contains(oneName) || excludeNames.Contains(twoName))
                    continue;

                //获取属性的值
                object oneValue = pisOne[i].GetValue(oneT, null);
                object twoValue = pisTwo[i].GetValue(twoT, null);
                //比较,只比较值类型
                if ((pisOne[i].PropertyType.IsValueType || pisOne[i].PropertyType.Name.StartsWith("String")) && (pisTwo[i].PropertyType.IsValueType || pisTwo[i].PropertyType.Name.StartsWith("String")))
                {
                    if (oneName.Equals(twoName))
                    {
                        if (oneValue == null)
                        {
                            if (twoValue != null)
                            {
                                result = false;
                                break; //如果有不一样的就退出循环
                            }
                        }
                        else if (oneValue != null)
                        {
                            if (twoValue != null)
                            {
                                if (!oneValue.Equals(twoValue))
                                {
                                    result = false;
                                    break; //如果有不一样的就退出循环
                                }
                            }
                            else if (twoValue == null)
                            {
                                result = false;
                                break; //如果有不一样的就退出循环
                            }
                        }
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
                else if (pisOne[i].PropertyType.IsArray && pisTwo[i].PropertyType.IsArray)
                {
                    var array1 = oneValue as Array;
                    var array2 = twoValue as Array;
                    if (array1 == null && array2 == null)
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        if ((array1 == null && array2 != null) || (array1 != null && array2 == null))
                        {
                            result = false;
                            break;
                        }

                    }
                    for (int j = 0; j < array1.Length; j++)
                    {
                        if (array1.GetValue(j).Equals(array2.GetValue(j))) continue;
                        else
                        {
                            result = false;
                            break;
                        }
                    }
                    if (!result) break;

                }
                else
                {
                    //如果对象中的属性是实体类对象，递归遍历比较
                    if (toChild)
                    {
                        bool b = CompareType(oneValue, twoValue, toChild, excludeNames);
                        if (!b) { result = b; break; }
                    }
                    else
                    {
                        bool b = CompareType(oneValue, twoValue);
                        if (!b) { result = b; break; }
                    }
                }
            }
            return result;
        }
        #endregion
    }
}
