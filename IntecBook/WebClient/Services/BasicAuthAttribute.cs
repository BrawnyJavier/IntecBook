using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebClient.Services
{

    public class BasicAuthAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Verificamos si el usuario esta autentificado, de lo contrario negamos el acceso.
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            // Autorizamos al usuario
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                string[] credentials = decodedAuthToken.Split(':');
                string Username = credentials[0];
                string Password = credentials[1];
                if (IntecBookSecurity.Login(Username, Password))
                {
                    // We set the identity for the current thread with our authentified Username
                    // No roles implemented yet
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }

    }
}