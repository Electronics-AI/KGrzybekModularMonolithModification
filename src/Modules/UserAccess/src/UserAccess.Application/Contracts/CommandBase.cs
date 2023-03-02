using MediatR;

namespace CompanyName.MyMeetings.Modules.UserAccess.Application.Contracts;

public abstract class CommandBase : ICommand, IRequest<MediatR.Unit>
{
    public Guid Id { get; }

    protected CommandBase()
    {
        this.Id = Guid.NewGuid();
    }

    protected CommandBase(Guid id)
    {
        this.Id = id;
    }
}

public abstract class CommandBase<TResult> : ICommand<TResult>, IRequest<TResult>
{
    public Guid Id { get; }

    protected CommandBase()
    {
        this.Id = Guid.NewGuid();
    }

    protected CommandBase(Guid id)
    {
        this.Id = id;
    }
}
