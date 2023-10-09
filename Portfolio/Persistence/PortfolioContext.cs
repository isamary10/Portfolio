using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Persistence
{
	public class PortfolioContext : DbContext
	{
		public DbSet<Project>? Projects { get; set; }
		public PortfolioContext(DbContextOptions options) : base(options) { }
	}
}
