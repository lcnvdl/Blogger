using Domain;
using MediatR;
using Persistence;

namespace Application.Blogs

{
    public class Detail
    {
        public class Query : IRequest<Blog>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Blog>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Blog> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dataContext.Blogs.FindAsync(request.Id);
            }
        }
    }
}