using CardManagementApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardManagementApp.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Card> Cards { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}