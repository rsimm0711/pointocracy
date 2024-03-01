using System.ComponentModel.DataAnnotations;
using Pointocracy.Core.Models;

namespace Pointocracy.Server.Dtos;

public sealed class PollDto
{
    [Required]
    public required Guid Id { get; init; }
    [Required]
    public required string Name { get; init; }
    [Required]
    public required PollState State { get; init; }
    public string? Description { get; init; }

    public static PollDto Create(Poll poll)
    {
        var dto = new PollDto
        {
            Id = poll.Id.Guid,
            Name = poll.Name.String,
            State = poll.State,
            Description = poll.Description.String,
        };

        return dto;
    }
}