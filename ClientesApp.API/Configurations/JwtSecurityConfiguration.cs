using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ClientesApp.API.Configurations
{
    public class JwtSecurityConfiguration
    {
        public static void AddJwtSecurity(IServiceCollection services)
        {
            var secretKey = "EB1AB146-C07B-48D0-81FD-C42AF391790F";

            services.AddAuthentication(
            auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }

            ).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters

    {
                 ValidateIssuer = false,
                 ValidateAudience = false,
                 ValidateLifetime = true,

                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

    };
            });
        }
    }
}
