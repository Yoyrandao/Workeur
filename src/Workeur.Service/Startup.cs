using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

using Workeur.Common;

[assembly: FunctionsStartup(typeof(Workeur.Service.Startup))]

namespace Workeur.Service
{
	public class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			builder.Services.AddTransient<IContentProvider, WebClientContentProvider>();
		}
	}
}