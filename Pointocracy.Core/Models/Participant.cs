namespace Pointocracy.Core.Models;

public record struct ParticipantName(string String);

public sealed class Participant(ParticipantName name, uint votesPositve, uint votesNegative);