namespace Pointocracy.Core.Models;

public sealed record VoteRules(uint VotesPositive, uint VotesNegative, uint LimitPositive, uint LimitNegative);