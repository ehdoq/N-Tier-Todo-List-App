using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace TodoList.Extension.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration _configuration;

        public BasicAuthenticationHandler(IConfiguration configuration,
                                          IOptionsMonitor<AuthenticationSchemeOptions> options,
                                          ILoggerFactory logger,
                                          UrlEncoder encoder,
                                          ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _configuration = configuration;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string? userName = string.Empty;

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');

                userName = credentials.FirstOrDefault();
                var password = credentials.LastOrDefault();

                var cUsername = _configuration["BasicAuthentication:Username"].ToString();
                var cPassword = _configuration["BasicAuthentication:Password"].ToString();
                var isAuthed = userName.Equals(cUsername) && password.Equals(cPassword);

                if (!isAuthed)
                    throw new ArgumentException("Invalid credentials");
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Authentication failed: {ex.Message}");
            }

            var claims = new[] { new Claim(ClaimTypes.Name, userName) };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}