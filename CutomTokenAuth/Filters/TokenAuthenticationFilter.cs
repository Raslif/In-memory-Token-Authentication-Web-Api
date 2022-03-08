using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CutomTokenAuth.Filters
{
    public class TokenAuthenticationFilter : AuthorizationFilterAttribute
    {
        public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Authorization-denied",
                                                actionContext.ControllerContext.Configuration.Formatters.JsonFormatter);
            }

            else
            {
                string token = actionContext.Request.Headers.Authorization.Parameter;
                var tokenManager =  InjectionResolver.GetType<ITokenManager>();
                if (!await tokenManager.VerifyToken(token))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Authorization-denied",
                                                actionContext.ControllerContext.Configuration.Formatters.JsonFormatter);
                }
            }
        }
    }
}