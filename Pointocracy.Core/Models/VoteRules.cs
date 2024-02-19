namespace Pointocracy.Core.Models;

public sealed record VoteRules(uint VotesPositive, uint VotesNegative, uint LimitPositive, uint LimitNegative)
{
    public static VoteRules Default = new(3, 2, 3, 2);
}
