using Microsoft.EntityFrameworkCore;

namespace PgOrm.EntityObjects.List
{
	public class ListDbContext : DbContext
	{
		public ListDbContext() { }

		public ListDbContext(DbContextOptions<ListDbContext> options) : base(options)
		{
		}

		public virtual DbSet<test> TestAsList { get; set; }
	}
}
