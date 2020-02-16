using AgendaInvent.Api.Helpers;
using AgendaInvent.Api.Security;
using AgendaInvent.Startup;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
			// Remover o XML
			var formatters = config.Formatters;
			formatters.Remove(formatters.XmlFormatter);

			// Modificar a identação
			var JsonSettings = formatters.JsonFormatter.SerializerSettings;
			JsonSettings.Formatting = Formatting.Indented;
			JsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			// Modificar a serialização
			formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

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