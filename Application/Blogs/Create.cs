using Domain;
using MediatR;
using Persistence;

namespace Application.Blogs
{
    public class Create
    {
        public class Command : IRequest
        {
            public Blog Blog { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _dataContext.Blogs.Add(request.Blog);

                await _dataContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}