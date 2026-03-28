using Microsoft.EntityFrameworkCore;
using EcommerceWebApiDemo.Models;

namespace EcommerceWebApiDemo.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options) { }
	}

}
