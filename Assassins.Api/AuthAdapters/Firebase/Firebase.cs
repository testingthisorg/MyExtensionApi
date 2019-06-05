using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assassins.Api.AuthAdapters.Firebase
{
    public class Firebase : IAuthAdapter
    {
        private static readonly string apiKey = "key=AIzaSyAb0ezalm7KvfhYYTVd5DNjNLSh5o0icgs";
        private static readonly Uri baseUri = new Uri("https://www.googleapis.com/identitytoolkit/v3/relyingparty/");
        public async Task<LoginResponseViewModel> Authenticate(LoginViewModel vm)
        {
            var client = new HttpClient();
            var uri = new Uri(baseUri, "verifyPassword?" + apiKey);
            var response =
                await client.PostAsJsonAsync(uri, new { email = vm.Email, password = vm.Password, returnSecureToken = true });

            FirebaseLoginResponse fbvm = null;

            if (response.IsSuccessStatusCode)
            {
                fbvm = await response.Content.ReadAsAsync<FirebaseLoginResponse>();
                var respVm = new LoginResponseViewModel()
                {
                    IdToken = fbvm.IdToken,
                    ExpiresIn = fbvm.ExpiresIn,
                    Email = fbvm.Email,
                    ExternalId = fbvm.LocalId,
                    RefreshToken = fbvm.RefreshToken
                };

                return respVm;
            }
            else
            {
                // error occurred
                var obj = await response.Content.ReadAsAsync<FirebaseError>();
                var innerExc = string.Empty;
                if (obj.Error.Errors != null && obj.Error.Errors.Count > 0)
                    innerExc = string.Join(Environment.NewLine,
                                    obj.Error.Errors.Select(k => k.Domain + " - " + k.Reason + " - " + k.Message));

                throw new Exception(obj.Error.Message, new Exception(innerExc));
            }


        }

        public async Task<LoginRefreshViewModel> RefreshAuth(string refreshToken)
        {
            var client = new HttpClient();
            var uri = new Uri("https://securetoken.googleapis.com/v1/token?" + apiKey);
            var response =
                await client.PostAsJsonAsync(uri, new { grant_type = "refresh_token", refresh_token = refreshToken });

            FirebaseRefreshResponse fbvm = null;

            if (response.IsSuccessStatusCode)
            {
               // var obj = await response.Content.ReadAsAsync(typeof(object));
               fbvm =  await response.Content.ReadAsAsync<FirebaseRefreshResponse>();
                var respVm = new LoginRefreshViewModel()
                {
                    IdToken = fbvm.id_token,
                    ExpiresIn = fbvm.expires_in,
                    RefreshToken = fbvm.refresh_token
                };

                return respVm;
            }
            else
            {
                // error occurred
                var obj = await response.Content.ReadAsAsync<FirebaseError>();
                var innerExc = string.Empty;
                if (obj.Error.Errors != null && obj.Error.Errors.Count > 0)
                    innerExc = string.Join(Environment.NewLine,
                                    obj.Error.Errors.Select(k => k.Domain + " - " + k.Reason + " - " + k.Message));

                throw new Exception(obj.Error.Message, new Exception(innerExc));
            }


        }
        /// <summary>
        /// Registers the user with Firebase authentication
        /// </summary>
        /// <param name="vm"></param>
        /// <returns>The Firebase Id for the new user</returns>
        public async Task<string> SignUpUser(SignUpViewModel vm)
        {
            var client = new HttpClient();
            var uri = new Uri(baseUri, "signupNewUser?" + apiKey);
            var response =
                await client.PostAsJsonAsync(uri, new { email = vm.Email, password = vm.Password, returnSecureToken = true });

            if (response.IsSuccessStatusCode)
            {
                FirebaseSignUpResponse fbvm = null;

                fbvm = await response.Content.ReadAsAsync<FirebaseSignUpResponse>();
                return fbvm.LocalId;
            }
            else
            {
                // error occurred
                var obj = await response.Content.ReadAsAsync<FirebaseError>();
                var innerExc = string.Empty;
                if (obj.Error.Errors != null && obj.Error.Errors.Count > 0)
                    innerExc = string.Join(Environment.NewLine,
                                    obj.Error.Errors.Select(k => k.Domain + " - " + k.Reason + " - " + k.Message));

                throw new Exception(obj.Error.Message, new Exception(innerExc));
            }
        }

    }

    public class FirebaseLoginResponse
    {
        public string Kind { get; set; }
        public string LocalId { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string IdToken { get; set; }
        public bool Registered { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiresIn { get; set; }
    }
    public class FirebaseRefreshResponse
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public string id_token { get; set; }
        public string user_id { get; set; }
        public string project_id { get; set; }
    }
    public class FirebaseSignUpResponse
    {
        public string Kind { get; set; }
        public string IdToken { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiresIn { get; set; }
        public string LocalId { get; set; }

    }
    public class FirebaseError
    {
        public Error Error { get; set; }
    }
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<SubError> Errors { get; set; }
    }
    public class SubError
    {
        public string Message { get; set; }
        public string Domain { get; set; }
        public string Reason { get; set; }
    }

}
