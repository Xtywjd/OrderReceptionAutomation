using Microsoft.EntityFrameworkCore;
using OrderReceptionAutomation.Domain.Entities;

namespace OrderReceptionAutomation.Infrastructure.Data
{
	public class DatabaseContext : DbContext
	{
		/// <summary>
		/// Конфигурация WebApi.
		/// </summary>
		private readonly IConfiguration _configuration;

		/// <summary>
		/// Создание контекста базы данных.
		/// </summary>
		/// <param name="options"></param>
		/// <param name="configuration"></param>
		public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options) 
		{
			_configuration = configuration;
		}

		/// <summary>
		/// Конфигурирование контекста.
		/// </summary>
		/// <param name="optionsBuilder"></param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection"));
		}

		/// <summary>
		/// Таблица "Товары".
		/// </summary>
		public DbSet<Product> Products { get; set; }

		/// <summary>
		/// Таблица "Заказы".
		/// </summary>
		public DbSet<Order> Orders { get; set; }

		/// <summary>
		/// Таблица "Заказчики."
		/// </summary>
		public DbSet<Customer> Customers { get; set; }
	}
}
