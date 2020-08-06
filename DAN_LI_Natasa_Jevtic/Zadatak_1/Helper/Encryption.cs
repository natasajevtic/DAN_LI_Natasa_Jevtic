using System;
using System.Text;

namespace Zadatak_1.Helper
{
    class Encryption
    {
        public string EncryptPassword(string password)
        {

            byte[] b = Encoding.UTF8.GetBytes(password);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
    }
}