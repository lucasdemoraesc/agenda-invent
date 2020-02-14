using AgendaInvent.Common.Resources;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaInvent.Api.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        // Valida token existente
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        // Gera novo token
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, "Administrator"));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, "Admin"));

                GenericPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception)
            {
                context.SetError("invalid_grant", Errors.ServerTokenError);
            }
        }
    }
}