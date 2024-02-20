
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.Clear();

using var context = new BlogDataContext();
var postList = GetPosts(context, 0, 25);


static IList<Post> GetPosts(BlogDataContext context, int skip = 0, int take = 25)
{
  var posts = context.Posts
    .AsNoTracking()
    .Skip(skip)
    .Take(take)
    .ToList();
  return posts;
}
