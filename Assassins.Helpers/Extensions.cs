using System;

namespace Assassins.Helpers
{
    public static class Extensions
    {
        public static string Norm(this string str)
        {
            return str.Replace(" ", string.Empty)
                        .Replace(Environment.NewLine, string.Empty)
                        .Replace("&", "and")
                        .Trim()
                        .ToLower();
        }

    }
}
