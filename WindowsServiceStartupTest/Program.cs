using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WindowsServiceStartupTest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateWebHostBuilder(args).Build();

			if (args.Contains("--initialize"))
				LongRunningInitialization(host);

			if (args.Contains("--console"))
				host.Run();
			else
				host.RunAsService();
		}

		private static void LongRunningInitialization(IWebHost host)
		{
			var logger = host.Services.GetRequiredService<ILogger<Program>>();
			logger.LogInformation("Doing long-running initialization (sleep for 35 seconds)");
			Task.Delay(35000).Wait();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
