using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUnit.Extend
{
    public static class String
    {
        /// <summary>
        /// 字符串格式的Guid 转 Guid对象，转换失败返回Guid.Empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                Guid g;
                if (Guid.TryParse(str, out g))
                {
                    return g;
                }
                else
                {
                    return Guid.Empty;
                }
            }
            else
            {
                return Guid.Empty;
            }
        }

    }
}
