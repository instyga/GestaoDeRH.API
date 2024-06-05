using System.Text.RegularExpressions;

namespace GestaoDeRH.Dominio.Util
{
    public static class Helpers
    {
        public static bool EmailEhValido(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string emailPattern = @"^[\w.-]+@(?:[a-zA-Z\d-]+\.)+[a-zA-Z]{2,}(?:\.[a-zA-Z]{2,})?$";

            return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
        }
    }
}
