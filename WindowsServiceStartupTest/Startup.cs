using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace WindowsServiceStartupTest
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app)
			=> app.Run(async (context) => await context.Response.WriteAsync("Hello World!"));
	}
}
