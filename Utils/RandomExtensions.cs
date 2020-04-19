using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class RandomExtensions
    {
        public static string GeneratePasswordSalt(this Random random)
        {
            var length = 7;
            var password = new StringBuilder();

            //сделать свое

            for (var i = 0; i < length; ++i)
            {
                var probability = random.Next(0, 100);
                if (probability >= 0 && probability <= 33)
                    password.Append((char)random.Next(48, 58));
                else if (probability >= 34 && probability <= 66)
                    password.Append((char)random.Next(65, 91));
                else
                    password.Append((char)random.Next(97, 123));
            }

            return password.ToString();
        }
    }
}
