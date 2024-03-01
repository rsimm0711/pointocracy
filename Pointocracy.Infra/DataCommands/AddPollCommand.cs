﻿using Pointocracy.Core.Models;
using Pointocracy.Infra.Models;

namespace Pointocracy.Infra.DataCommands;

internal sealed class AddPollCommand(PointocracyDb db) : IAddPollCommand
{
    public void Add(Poll poll)
    {
        var dao = new PollDao
        {
            Id = poll.Id.Guid
        };

        db.Add(dao);
    }
}