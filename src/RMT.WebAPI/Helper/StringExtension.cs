using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using RMT.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMT.WebAPI.Helper
{
    public static class StringExtension
    {
        public static string ToHashString(this string password)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var Hashed = KeyDerivation.Pbkdf2(
                    password: password,
                    salt: Encoding.UTF8.GetBytes(config.GetValue<string>("Key:hash")),
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8
                    );
            return Convert.ToBase64String(Hashed);
        }
        public static bool Compare(this string input, string inputHashed)
        {
            if (input.ToHashString() == inputHashed)
            {
                return true;
            }
            return false;
        }
        public static string RandomString(int length)
        {
            StringBuilder rs = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < length; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                rs.Append(ch);
            }
            return rs.ToString();
        }
        public static bool IsMailFormat(this string input)
        {
            char[] list = input.ToCharArray();
            if (Array.IndexOf(list, '@') != -1 && Array.IndexOf(list, '.') != -1)
            {
                return true;
            }
            return false;
        }
        public static bool IsStatus(this string input)
        {
            if (StatusList.Statuses().Where(s => s.Name == input).Count() != 0)
            {
                return true;
            }
            return false;
        }
        public static void ToLogFile(this string input)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "log.txt");
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            using (StreamWriter sw = new StreamWriter(filePath,true))
            {
                sw.WriteLine(input);
                sw.Close();
            }
        }
    }
}
