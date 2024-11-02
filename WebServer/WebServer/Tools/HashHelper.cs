using System.Security.Cryptography;

namespace WebServer.Tools
{
    public class HashHelper
    {

        

        public static string HashPassword(string password)
        {
            
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }


        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
