
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.Clear();

using var context = new BlogDataContext();

var posts = context.Posts
  .AsNoTracking()
  .Include(x => x.Author) // realizando o join
  .OrderByDescending(x => x.LastUpdateDate)
  .ToList();

foreach (var post in posts)
  Console.WriteLine($"{post.Title} escrito por {post.Author?.Name}");
