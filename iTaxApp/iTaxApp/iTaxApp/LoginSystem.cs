
namespace Core
{
    public static class LoginSystem
    {
        public static bool Login(string username, string password)
        {
            //TODO: Login function
            if (username.Equals("iTax") && password.Equals("pass"))
            {
                return true;
            }
            else
            {
                return false;
            }
            /*
            SqlCommand cmd = new SqlCommand("login", On);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@value", txtValue.Text);
            int rowAffected = cmd.ExecuteNonQuery();
            */
        }
        public static bool Register(string email, string username, string password)
        {
            //TODO: Register function
            if (username.Equals("iTax") && password.Equals("pass"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        static readonly string[] digits = {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                    return 2 + i;
            }
            return null;
        }
    }
}