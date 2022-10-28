using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Groups
{
    public class List
    {
         public class Query : IRequest<Result<List<Group>>>{}

        public class Handler : IRequestHandler<Query, Result<List<Group>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Group>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Group>>.Success(await _context.Groups.ToListAsync());
            }
        }
    }
}