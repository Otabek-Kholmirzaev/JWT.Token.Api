using Microsoft.EntityFrameworkCore;

namespace JWT.Token.Api.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{
		
	}
}
