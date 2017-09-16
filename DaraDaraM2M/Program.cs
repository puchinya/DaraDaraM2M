using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using DaraDaraM2M.Data;
using DaraDaraM2M.Model;

namespace DaraDaraM2M
{
	public class Program
	{
		public static void StartServer()
		{
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

			using (var db = new OM2MDbContext())
			{
				db.Database.EnsureDeleted();
				db.Database.EnsureCreated();
			}

			var host = new WebHostBuilder()
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseIISIntegration()
				.UseStartup<Startup>()
				.Build();

			host.Run();
		}
		
		public static void Main(string[] args)
		{
			StartServer();
		}
	}
}
