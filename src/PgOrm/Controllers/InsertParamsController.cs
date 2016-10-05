using Microsoft.AspNetCore.Mvc;
using PgOrm.EntityObjects.List;
using Microsoft.EntityFrameworkCore;

namespace PgOrm.Controllers
{
	[Route("api/[controller]")]
    public class InsertParamsController : Controller
    {
		ListDbContext _context;

		public InsertParamsController(ListDbContext context)
		{
			_context = context;
		}

		[HttpGet]
        public int Get()
        {
			const string insert = "INSERT INTO test(textarray)" +
				 "VALUES ($1) RETURNING id AS InsertedId";

			var res = _context.Database.ExecuteSqlCommand(insert, "{\"value 1\",\"value 2\"}");

			return res;
		}
    }
}
