using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Groups
{
    public class Edit
    {
         public class Command : IRequest{
            public Group Group {get;set;}
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
               
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
               var group = await _context.Groups.FindAsync(request.Group.Id);
               //group.Name = request.Group.Name ?? group.Name;
               //group.Status = request.Group.Status;

                _mapper.Map(request.Group,group);
                
               await _context.SaveChangesAsync();
               return Unit.Value;
            }
        }
    }
}