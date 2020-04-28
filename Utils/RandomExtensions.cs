using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public static class RandomExtensions
    {
        public static string GenerateSalt(this Random random)
        {
            var init = Guid.NewGuid().ToString("N");//генерация строки
            var salt = init.Substring(0,7);//для сокращения до 7 символов

            return salt;
        }
    }
}
