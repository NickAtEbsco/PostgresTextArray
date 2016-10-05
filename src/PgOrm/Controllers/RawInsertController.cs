using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PgOrm.EntityObjects.List;

namespace PgOrm.Controllers
{
	[Route("api/[controller]")]
	public class RawInsertController : Controller
    {
		ListDbContext _context;

		public RawInsertController(ListDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public int Get()
		{
			const string insert = "INSERT INTO test(textarray)" +
				"VALUES ('{0}') RETURNING id AS InsertedId";

			var sqlStatement = string.Format(insert, "{\"value 1\",\"value 2\"}");
			var res = _context.Database.ExecuteSqlCommand(sqlStatement);

			return res;
		}
    }
}
