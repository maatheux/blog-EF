
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.Clear();

using var context = new BlogDataContext();

var post = context.Posts
  .Include(x => x.Author)
  .Include(x => x.Category)
  .OrderByDescending(x => x.LastUpdateDate)
  .FirstOrDefault();

post.Author.Name = "Teste";

context.Posts.Update(post);
context.SaveChanges();

Console.WriteLine("Success!");
