namespace Pointocracy.Core.Models;

public sealed record VoteRules(uint PositiveVotes, uint NegativeVotes, uint PositiveLimit, uint NegativeLimit);