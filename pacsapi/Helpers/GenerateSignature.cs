using System.Security.Cryptography;
using System.Text;

namespace FingerDocAPI.Helpers
{
    public class GenerateSignature
    {

        public async Task<string> GetSignature(string clientKey, string secretKey, int timpestamp)
        {
            var data = $"{clientKey}{timpestamp}";

            var hashObject = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));

            var signature = hashObject.ComputeHash(Encoding.UTF8.GetBytes(data));
            var encodedSignature = Convert.ToBase64String(signature);

            return encodedSignature;
        }
    }

}
