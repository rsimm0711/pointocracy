namespace Pointocracy.Core.Models;

public record struct OptionIndex(int Int);
public record struct OptionValue(string String);
public record struct OptionDescription(string? String);

public sealed record Option(OptionIndex Index, OptionValue Value, OptionDescription Description);