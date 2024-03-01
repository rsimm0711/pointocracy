using Pointocracy.Core.Models;

namespace Pointocracy.Infra.Models;

internal sealed class PollDao
{
    public required Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public PollState State { get; init; }
}