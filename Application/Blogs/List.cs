using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Blogs
{
    public class List
    {
        public class Query : IRequest<List<Blog>> { }

        public class Handler : IRequestHandler<Query, List<Blog>>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<List<Blog>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dataContext.Blogs.ToListAsync(cancellationToken);
            }
        }
    }
}