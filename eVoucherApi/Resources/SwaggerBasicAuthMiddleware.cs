using System.Net;
using System.Text;

namespace eVoucher.Server.Resources
{
    public class SwaggerBasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly IUserService _userService;
        public SwaggerBasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
            //_userService = userService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //Make sure we are hitting the swagger path, and not doing it locally as it just gets annoying :-)
            if (context.Request.PathBase.StartsWithSegments("/swagger") || context.Request.Path.StartsWithSegments("/swagger"))
            {
                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("Basic "))
                {
                    // Get the encoded username and password
                    var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();

                    // Decode from Base64 to string
                    var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                    // Split username and password
                    var username = decodedUsernamePassword.Split(':', 2)[0];
                    var password = decodedUsernamePassword.Split(':', 2)[1];

                    // Check if login is correct
                    //if (_userService.AuthenticateSwagger(username, password))
                    //{
                    //    await _next.Invoke(context);
                    //    return;
                    //}
                }

                // Return authentication type (causes browser to show login dialog)
                context.Response.Headers["WWW-Authenticate"] = "Basic";

                // Return unauthorized
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                await _next.Invoke(context);
            }
        }

    }
}
