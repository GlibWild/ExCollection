using System;
using System.Collections.Generic;
using System.IO;
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
    }
}
