
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.Clear();

using var context = new BlogDataContext();
var posts = context.Posts
  .Include(x => x.Author)
    .ThenInclude(x => x.Roles) /* vai executar um subselect */
  .Include(x => x.Category);

foreach (var post in posts)
{
  foreach (var role in post.Author.Roles)
  {
    
  }
}
