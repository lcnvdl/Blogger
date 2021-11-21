using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Blogs.Any()) return;

            var blogs = new List<Blog>
            {
                new Blog
                {
                    Title = "Story about Eric",
                    Content = "Once upon a time, ....."
                },
                new Blog
                {
                    Title = "SQL vs NoSQL",
                    Content = "What's the difference between ....."
                },
            };

            await context.Blogs.AddRangeAsync(blogs);
            await context.SaveChangesAsync();
        }
    }
}