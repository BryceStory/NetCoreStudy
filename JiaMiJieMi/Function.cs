using System.Text;
using System.Security.Cryptography;
namespace JiaMiJieMi
{
    public static class Function
    {
        //MD5加密
        public static string Encypt(string source, int length = 32)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }

            HashAlgorithm provider = CryptoConfig.CreateFromName("MD5") as HashAlgorithm;
            byte[] bytes = Encoding.UTF8.GetBytes(source);  //此处需要注意编码
            byte[] hashValue = provider.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            switch (length)
            {

                case 32:
                    for (int i = 0; i < 16; i++)
                    {
                        sb.Append(hashValue[i].ToString("x2"));
                    }
                    break;
            }
            return sb.ToString();
        }
    }
}