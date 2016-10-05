using System;
using Microsoft.AspNetCore.Mvc;
using PgOrm.EntityObjects.Array;

namespace PgOrm.Controllers
{
	[Route("api/[controller]")]
    public class ArrayController : Controller
    {
		ArrayDbContext _context;

		public ArrayController(ArrayDbContext context)
		{
			_context = context;
		}

		// GET api/values
		[HttpGet]
        public int Get()
        {
			try
			{
				var testData = new test
				{
					textarray = new string[]
					{
						"value 1",
						"value 2"
					}
				};
				_context.TestAsArray.Add(testData);
				_context.SaveChanges();

				return testData.id;
			}
			catch (Exception ex)
			{
				// Log message here
				throw ex;
			}
		}
    }
}
