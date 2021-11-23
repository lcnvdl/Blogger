using MediatR;
using Persistence;

namespace Application.Blogs
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                var blog = await _dataContext.Blogs.FindAsync(request.Id);

                _dataContext.Remove(blog);

                await _dataContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}