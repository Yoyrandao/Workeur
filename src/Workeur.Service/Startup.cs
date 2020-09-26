using System;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Workeur.Common;
using Workeur.External;
using Workeur.External.DataAccess;
using Workeur.External.DataAccess.Repository;
using Workeur.External.Models;
using Workeur.External.Parsers;
using Workeur.External.Parsers.Providers;
using Workeur.Service;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Workeur.Service
{
	public class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			builder.Services.AddTransient<IContentProvider, WebRequestContentProvider>();
			
			builder.Services.AddTransient<PostLinkProvider>();
			builder.Services.AddTransient<PostTitleProvider>();
			builder.Services.AddTransient<PostAuthorProvider>();
			builder.Services.AddTransient<PostDescriptionProvider>();
			
			builder.Services.AddTransient<PostCommentsProvider>();

			builder.Services.AddTransient<IContentParser<Post>, ZenContentParser>(
				x => new ZenContentParser(
					x.GetService<IContentProvider>(),
					x.GetService<PostAuthorProvider>(),
					x.GetService<PostDescriptionProvider>(),
					x.GetService<PostTitleProvider>(),
					x.GetService<PostLinkProvider>(),
					x.GetService<PostCommentsProvider>()));
			
			var configuration = new ConfigurationBuilder()
			    .SetBasePath(builder.GetContext().ApplicationRootPath)
				.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables()
				.Build();

			var connectionString = configuration["WorkeurDatabase"] ?? Environment.GetEnvironmentVariable("WORKEUR_DATABASE");
			builder.Services.AddTransient<ISqlQueryExecutor, SqlQueryExecutor>(
				x => new SqlQueryExecutor(connectionString));

			builder.Services.AddTransient<IPostRepository, PostRepository>();
		}
	}
}