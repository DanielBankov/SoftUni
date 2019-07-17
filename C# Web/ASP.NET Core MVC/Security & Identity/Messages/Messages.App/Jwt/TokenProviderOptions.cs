using Microsoft.IdentityModel.Tokens;
using System;

namespace Messages.App.Jwt
{
    public class TokenProviderOptions
    {
        public string Path { get; set; } = "api/users/login";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expitarion { get; set; } = TimeSpan.FromDays(15);

        public SigningCredentials SigningCredentials { get; set; }
    }
}
