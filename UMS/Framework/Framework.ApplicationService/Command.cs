using MediatR;

namespace Framework.ApplicationService;

public class Command : IRequest
{
    public Command() => ExecutedDateTime = DateTime.Now;

    public DateTime ExecutedDateTime { get; set; }
}