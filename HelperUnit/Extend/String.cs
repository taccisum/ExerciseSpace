using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HelperUnit.Extend
{
    public static class String
    {
        #region 字符串格式的Guid 转 Guid对象，转换失败返回Guid.Empty
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
        #endregion

        #region MD5加密字符串
        /// <summary>
        /// 对字符串进行MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMD5(this string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = Encoding.UTF8.GetBytes(str);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < md5data.Length; i++)
            {
                sBuilder.Append(md5data[i].ToString("X2"));
            }
            return sBuilder.ToS();
        }
        #endregion

        #region 对象转换为string，失败返回空字符串
        /// <summary>
        /// 对象转换为string，失败返回空字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToS(this object str)
        {
            if (str != null)
            {
                return str.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
