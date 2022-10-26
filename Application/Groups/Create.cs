using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Groups
{
    public class Create
    {
        public class Command : IRequest{
            public Group Group {get;set;}
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly ILogger<Handler> _logger;

            public Handler(DataContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("creando -----");
               _context.Groups.Add(request.Group);
               await _context.SaveChangesAsync();

               return Unit.Value;
            }
        }
    }
}