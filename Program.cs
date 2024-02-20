
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.Clear();



static async Task Execute()
{
  using var context = new BlogDataContext();
  
  //var posts = await context.Posts.AsNoTracking().ToListAsync();
  
  var post = await context.Posts.FirstOrDefaultAsync();
  var tags = await context.Tags.FirstOrDefaultAsync();

  var posts = await GetPosts(context);

} // o task permite executarmos a funcao de forma assincrona

static async Task<IList<Post>> GetPosts(BlogDataContext context)
{
  return await context.Posts.ToListAsync();
}
