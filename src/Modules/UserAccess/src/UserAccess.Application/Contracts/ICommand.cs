using MediatR;

namespace CompanyName.MyMeetings.Modules.UserAccess.Application.Contracts;

public interface ICommand<out TResult> : IRequest<TResult>
{
    Guid Id { get; }
}

public interface ICommand : IRequest<MediatR.Unit>
{
    Guid Id { get; }
}
