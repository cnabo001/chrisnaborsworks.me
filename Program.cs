using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ChrisNaborsWorks
{
    public class Program
    {
        public static void Main(string[] args)
        {

			var host = new WebHostBuilder()
			   .UseKestrel()
			   .UseContentRoot(Directory.GetCurrentDirectory())
			   .UseIISIntegration()
			   .UseStartup<Startup>()
			   .Build();

			host.Run();
			//#if NET40
			//        Console.WriteLine("Target framework: .NET Framework 4.0");
			//#elif NET45
			//        Console.WriteLine("Target framework: .NET Framework 4.5");
			//#else
			//			Console.WriteLine("Target framework: .NET Core 2.0");
			//#endif
			//			Console.ReadKey();
			//BuildWebHost(args).Run();
        }

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .Build();
    }
}
