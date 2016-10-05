using Microsoft.EntityFrameworkCore;

namespace PgOrm.EntityObjects.Array
{
	public class ArrayDbContext : DbContext
	{
		public ArrayDbContext() { }

		public ArrayDbContext(DbContextOptions<ArrayDbContext> options) : base(options)
		{
		}

		public virtual DbSet<test> TestAsArray { get; set; }
	}
}
