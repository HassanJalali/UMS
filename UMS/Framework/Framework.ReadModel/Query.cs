using MediatR;

namespace Framework.ReadModel;

public record Query<T> : IRequest<T>;