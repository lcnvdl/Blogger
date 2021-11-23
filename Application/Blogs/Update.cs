using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Blogs
{
    public class Update
    {
        public class Command : IRequest
        {
            public Blog Blog { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _mapper = mapper;
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var blog = await _dataContext.Blogs.FindAsync(request.Blog.Id);

                _mapper.Map(request.Blog, blog);

                await _dataContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}