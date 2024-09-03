using System.Security.Cryptography;
using System.Text;

namespace FingerDocAPI.Helpers
{
    public class GenerateTimestamp
    {
        public async Task<int> GetTimestamp()
        {
            return (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
