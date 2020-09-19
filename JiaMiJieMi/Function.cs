using System.Text;
using System.Security.Cryptography;
namespace JiaMiJieMi
{
    public class Function
    {
        //MD5加密
        public static string Encypt(string source, int length = 32)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }

            HashAlgorithm provider = CryptoConfig.CreateFromName("MD5") as HashAlgorithm;
            byte[] bytes = Encoding.UTF8.GetBytes(source);

        }
    }
}