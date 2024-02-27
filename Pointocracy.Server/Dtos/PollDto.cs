using System.ComponentModel.DataAnnotations;
using Pointocracy.Core.Models;

namespace Pointocracy.Server.Dtos;

public sealed class PollDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public string? Description { get; set; }
    [Required]
    public PollState State { get; set; }

    public static PollDto Create(Poll poll)
    {
        var dto = new PollDto
        {
            Id = poll.Id.Guid,
            Name = poll.Name.String,
            Description = poll.Description.String,
            State = poll.State,
        };

        return dto;
    }
}