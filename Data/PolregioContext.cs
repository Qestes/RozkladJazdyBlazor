using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RozkladJazdyBlazor.Data
{
	public class PolregioContext : DbContext
	{
		public DbSet<Agency> Agencies
		{ get; set; }
		public DbSet<Calendar_Dates> Calendar_Dates
		{ get; set; }
		public DbSet<Routes> Routes
		{ get; set; }
		public DbSet<Stop_Times> Stop_Times
		{ get; set; }
		public DbSet<Stops> Stops
		{ get; set; }
		public DbSet<Transfers> Transfers
		{ get; set; }
		public DbSet<Trips> Trips
		{ get; set; }

		protected readonly IConfiguration Configuration;
		public PolregioContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

        //public PolregioContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(Configuration.GetConnectionString("PolregioDB"));
		}
	
	}
}
