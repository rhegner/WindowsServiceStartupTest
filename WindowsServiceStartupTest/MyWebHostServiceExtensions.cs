using Microsoft.AspNetCore.Hosting;
using System.ServiceProcess;

namespace WindowsServiceStartupTest
{
	public static class MyWebHostServiceExtensions
	{

		public static void RunAsService(this IWebHost host)
		{
			var myWebHostService = new MyWebHostService(host);
			ServiceBase.Run(myWebHostService);
		}

	}
}
