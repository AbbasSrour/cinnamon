using MediatR;

namespace Application.Common.Interfaces;

public interface ICommand : IRequest { }

public interface ICommand<TResult> : IRequest<TResult> { }

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
  where TCommand : ICommand { }

public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
  where TCommand : ICommand<TResult> { }