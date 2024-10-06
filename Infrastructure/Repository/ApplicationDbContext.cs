using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repository
{
	public class ApplicationDbContext : DbContext
	{
		private readonly string _connectionString;

        public ApplicationDbContext()
        {
			IConfiguration configuration = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.Build();

			_connectionString = configuration.GetConnectionString("ConnectionString");

		}
        public ApplicationDbContext(string connectionString)
        {
			_connectionString = connectionString;
		}

        public DbSet<Cliente> Cliente { get; set; }
		public DbSet<Livro> Livro { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_connectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// modo automático que valida toda classe que utiliza a interface IEntityTypeConfiguration
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}
