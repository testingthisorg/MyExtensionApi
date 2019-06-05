using System.ComponentModel.DataAnnotations;

namespace Assassins.Api.AuthAdapters
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public string AvatarUrl { get; set; }
        public string FullName { get; set; }
        public int AppUserId { get; set; }
        public string ExternalId { get; set; }
        public string IdToken { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiresIn { get; set; }
        public string Email { get; set; }
        public string AdAssassinId { get; set; }
        public string[] Roles { get; set; }
    }
    public class LoginRefreshViewModel
    {
        public string ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public string IdToken { get; set; }
        public string UserId { get; set; }
    }
    public class SignUpViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InviteCode { get; set; }
        public int RoleId { get; set; }
    }

}
