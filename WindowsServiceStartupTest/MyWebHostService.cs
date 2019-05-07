using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WindowsServiceStartupTest
{
	public class MyWebHostService : WebHostService
	{
		private readonly ILogger<MyWebHostService> Logger;

		public MyWebHostService(IWebHost host)
			: base(host)
		{
			AutoLog = true;
			CanHandlePowerEvent = false;
			CanHandleSessionChangeEvent = false;
			CanPauseAndContinue = false;
			CanShutdown = false;
			CanStop = true;
			ServiceName = "MyTestService";

			Logger = host.Services.GetRequiredService<ILogger<MyWebHostService>>();
		}

		protected override void OnStarting(string[] args)
		{
			Logger.LogInformation("MyWebHostService.OnStarting");

			//  This doesn't help...
			RequestAdditionalTime(60000);

			base.OnStarting(args);
		}

		protected override void OnStarted()
		{
			Logger.LogInformation("MyWebHostService.OnStarted");
			base.OnStarted();
		}
	}
}
