using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class UnicodeHelper
    {

        /// <summary>
        /// 转换对象Unicode字段
        /// </summary>
        /// <param name="obj"></param>
        public static void ConvertObjUnicodeField(object obj)
        {
            if (obj == null)
            {
                return ;
            }

            var properties = obj.GetType().GetProperties();
            if (properties == null || properties.Length == 0)
            {
                return;
            }
            else
            {
                foreach (var eachProperties in properties)
                {
                    SetUnicodeStr(obj, eachProperties);
                }
            }

            return;
        }

        /// <summary>
        /// 是否包含UnicodeFieldAttribute
        /// </summary>
        /// <param name="customeAttributes"></param>
        /// <returns></returns>
        private static bool IsContainUnicodeAttribute(IEnumerable<Attribute> customeAttributes)
        {
            bool isContain = false;
            foreach (var ca in customeAttributes)
            {
                if (ca.GetType() == typeof(UnicodeFieldAttribute))
                {
                    isContain = true;
                    break;
                }
            }
            return isContain;
        }

        /// <summary>
        /// 将Unicode编码转换为汉字字符串 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToGB2312(string str)
        {
            MatchCollection mc = Regex.Matches(str, "([\\w]+)|(\\\\u([\\w]{4}))");
            if (mc != null && mc.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Match m2 in mc)
                {
                    string v = m2.Value;
                    if (v.StartsWith("\\"))
                    {
                        string word = v.Substring(2);
                        byte[] codes = new byte[2];
                        int code = Convert.ToInt32(word.Substring(0, 2), 16);
                        int code2 = Convert.ToInt32(word.Substring(2), 16);
                        codes[0] = (byte)code2;
                        codes[1] = (byte)code;
                        sb.Append(Encoding.Unicode.GetString(codes));
                    }
                    else
                    {
                        sb.Append(v);
                    }
                }
                return sb.ToString();
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// 转换单个属性的unicode为中文
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="p"></param>
        private static void SetUnicodeStr(object entity, PropertyInfo p)
        {
            try
            {

                if (entity == null || p == null)
                {
                    return;
                }

                Type pType = p == null ? p.GetType() : p.PropertyType;
                var pValue = p == null ? p : p.GetValue(entity);

                var cas = p.GetCustomAttributes();
                if (!IsContainUnicodeAttribute(cas))
                {//没有标识为UnicodeAttribute返回
                    return;
                }


                if (pType.IsValueType || pType == typeof(string))
                {
                    if (pType == typeof(string))
                    {//string才转unicode，其他值类型不不做任何操作
                        p.SetValue(entity, ToGB2312(pValue.ToString()));
                    }
                    return;
                }
               
                if (typeof(IEnumerable).IsAssignableFrom(pType))
                { //如果成员是个集合，递归遍历
                    IEnumerable ie = pValue as IEnumerable;
                    if (ie != null)
                    {
                        IEnumerator list = ie.GetEnumerator();

                        var unicodeStringList = new List<string>();

                        while (list.MoveNext())
                        {
                            ////基本数据类型或者string
                            if (list.Current.GetType().IsValueType || list.Current.GetType() == typeof(string))
                            {
                                if (list.Current.GetType() == typeof(string))
                                {
                                    unicodeStringList.Add(ToGB2312(list.Current.ToString()));
                                }
                            }
                            ////自定义类型
                            else
                            {
                                PropertyInfo[] ps = list.Current.GetType().GetProperties();
                                foreach (PropertyInfo subP in ps)
                                {
                                    SetUnicodeStr(list.Current, subP);
                                }
                            }
                        }

                        //Set List<string> 
                        if (unicodeStringList.Count > 0)
                        {
                            p.SetValue(entity, unicodeStringList);
                        }
                    }
                }
                else
                {//引用类型
                    PropertyInfo[] fields = pType.GetProperties();
                    if (fields.Length == 0)
                    {
                        return;
                    }
                    foreach (var subField in fields)
                    {
                        SetUnicodeStr(pValue, subField);
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
