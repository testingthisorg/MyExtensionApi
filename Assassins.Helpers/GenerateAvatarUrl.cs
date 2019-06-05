namespace Assassins.Helpers
{
    public partial class Avatars
    {
        public static string GetAvatarUrl(string firstName, string lastName, string username)
        {
            var root = "https://i0.wp.com/cdn.auth0.com/avatars/";
            var suffix = ".png?ssl=1";
            char firstLetter = 'Q';
            char secondLetter = 'Q';
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && firstName.Length > 1 && lastName.Length > 1)
            {
                firstLetter = firstName.ToCharArray()[0];
                secondLetter = lastName.ToCharArray()[0];
            }
            else
            {
                if (!string.IsNullOrEmpty(firstName) && firstName.Length > 1)
                {
                    firstLetter = firstName.ToCharArray()[0];
                    secondLetter = firstName.ToCharArray()[1];
                }
                else if (!string.IsNullOrEmpty(lastName) && lastName.Length > 1)
                {
                    firstLetter = lastName.ToCharArray()[0];
                    secondLetter = lastName.ToCharArray()[1];
                }
                else if (!string.IsNullOrEmpty(username) && username.Length > 1)
                {
                    firstLetter = username.ToCharArray()[0];
                    secondLetter = username.ToCharArray()[1];
                }
            }
            return root + char.ToLower(firstLetter) + char.ToLower(secondLetter) + suffix;
        }

    }
}
