using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace Richnova.CEMS.Framework.Utility.Encrypt
{
    public partial class EncryptHelper
    {
        #region MD5函数
        /// <summary>
        /// MD5函数,需引用：using System.Security.Cryptography;
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str)
        {
            //微软md5方法参考return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
            byte[] b = Encoding.Default.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');
            return ret;
        }

        public static string MD5(string str, int code)
        {
            string strEncrypt = string.Empty;
            if (code == 16)
            {
                strEncrypt = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
            }
            if (code == 32)
            {
                strEncrypt = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }
            return strEncrypt;
        }
        #endregion
    }
}
