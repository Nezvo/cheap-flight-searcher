using System.Data.Entity;

namespace test
{
	class AirportContext : DbContext
	{
		//public DbSet<>

		public AirportContext(string connection) : base(connection)
		{

		}
	}
}
