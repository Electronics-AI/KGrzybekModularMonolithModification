﻿using CompanyName.MyMeetings.Modules.UserAccess.Application.Contracts;

namespace CompanyName.MyMeetings.Modules.UserAccess.Application.Configuration.Commands;

public abstract class InternalCommandBase : ICommand
{
    public Guid Id { get; }

    protected InternalCommandBase(Guid id)
    {
        this.Id = id;
    }
}

public abstract class InternalCommandBase<TResult> : ICommand<TResult>
{
    public Guid Id { get; }

    protected InternalCommandBase()
    {
        this.Id = Guid.NewGuid();
    }

    protected InternalCommandBase(Guid id)
    {
        this.Id = id;
    }
}
