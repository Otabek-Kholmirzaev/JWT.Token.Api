using JWT.Token.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWT.Token.Api.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{

	}

	public DbSet<User> Users { get; set; }
}
