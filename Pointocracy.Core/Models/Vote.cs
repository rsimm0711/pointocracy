namespace Pointocracy.Core.Models;

public record struct VoteValue(int Int);

public record struct Vote(ParticipantName ParticipantName, VoteValue Value);