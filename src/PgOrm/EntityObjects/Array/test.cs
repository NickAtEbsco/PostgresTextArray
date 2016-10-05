using System.ComponentModel.DataAnnotations;

namespace PgOrm.EntityObjects.Array
{
	public class test
    {
		[Key]
		public int id { get; set; }
		public string[] textarray { get; set; }
	}
}
