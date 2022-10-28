using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Groups
{
    public class Details
    {
        public class Query : IRequest<Result<Group>>{
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Group>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<Group>> Handle(Query request, CancellationToken cancellationToken)
            {
              var group = await _context.Groups.FindAsync(request.Id);
              return Result<Group>.Success(group);
            }
        }
    }
}