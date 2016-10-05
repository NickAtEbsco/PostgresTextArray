using Microsoft.AspNetCore.Mvc;
using PgOrm.EntityObjects.List;
using System.Collections.Generic;

namespace PgOrm.Controllers
{
	[Route("api/[controller]")]
    public class ListController : Controller
	{
		ListDbContext _context;

		public ListController(ListDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public int Get()
		{
			var testData = new test
			{
				textarray = new List<string>
					{
						"value 1",
						"value 2"
					}
			};
			_context.TestAsList.Add(testData);
			_context.SaveChanges();

			return testData.id;
		}
	}
}
