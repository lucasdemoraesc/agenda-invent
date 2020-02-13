using AgendaInvent.Api.Helpers;
using AgendaInvent.Api.Security;
using AgendaInvent.Domain.Contracts.Services;
using AgendaInvent.Startup;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using Unity;

namespace AgendaInvent.Api
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			HttpConfiguration config = new HttpConfiguration();

			var container = new UnityContainer();
			DependencyResolver.Resolve(container);
			config.DependencyResolver = new UnityResolver(container);

			ConfigureWebApi(config);
			ConfigureOAuth(app);

			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			app.UseWebApi(config);
		}

		public static void ConfigureWebApi(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}

		public void ConfigureOAuth(IAppBuilder app)
		{
			OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/api/security/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
				Provider = new AuthorizationServerProvider()
			};

			// Token Generation
			app.UseOAuthAuthorizationServer(OAuthServerOptions);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
		}
	}
}