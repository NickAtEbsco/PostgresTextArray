using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PgOrm.EntityObjects.List
{
	public class test
    {
		[Key]
		public int id { get; set; }
		public List<string> textarray { get; set; }
	}
}
