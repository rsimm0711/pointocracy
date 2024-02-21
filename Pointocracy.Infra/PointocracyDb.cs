using Microsoft.EntityFrameworkCore;
using Pointocracy.Infra.Models;

namespace Pointocracy.Infra;

internal sealed class PointocracyDb(DbContextOptions<PointocracyDb> options) : DbContext(options)
{
    public DbSet<PollDao> Polls { get; init; } = null!;
}