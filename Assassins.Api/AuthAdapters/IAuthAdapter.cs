using System.Threading.Tasks;

namespace Assassins.Api.AuthAdapters
{
    public interface IAuthAdapter
    {
        Task<LoginResponseViewModel> Authenticate(LoginViewModel vm);
        Task<LoginRefreshViewModel> RefreshAuth(string refreshToken);
        Task<string> SignUpUser(SignUpViewModel vm);
    }
}
