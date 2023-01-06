using BlazorApp.Data;
using BlazorApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Service
{

    public class PostServices
    {
        public interface IPostService
        {
            Task<List<Post>> Get();
            Task<Post> GetById(int id);
            Task<Post> Add(Post post);
            Task<Post> Update(Post post);
            Task<Post> Delete(int id);
        }
        public class PostService : IPostService
        {

            private readonly ApplicationDbContext _context;

            public PostService(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Post> Add(Post post)
            {
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
                return post;
            }

            public async Task<Post> Delete(int id)
            {
                var post = await _context.Posts.FindAsync(id);
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return post;
            }

            public async Task<List<Post>> Get()
            {
                return await _context.Posts.ToListAsync();
            }

            public async Task<Post> GetById(int id)
            {
                var post = await _context.Posts.FindAsync(id);
                return post;
            }

            public async Task<Post> Update(Post post)
            {
                _context.Entry(post).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return post;
            }
        }
    }
}
