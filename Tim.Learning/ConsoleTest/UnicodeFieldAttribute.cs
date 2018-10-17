using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    /// <summary>
    /// 标识字段是不是Unicode，然后将Unicode转回中文
    /// </summary>
    public class UnicodeFieldAttribute:Attribute
    {
        public UnicodeFieldAttribute()
        {

        }
    }
}
