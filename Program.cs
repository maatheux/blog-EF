
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.Clear();

using var context = new BlogDataContext();

User user = new User
{
  Name = "André Baltieri",
  Slug = "andrebaltieri",
  Email = "andre@balta.io",
  Bio = "11x Microsoft MVP",
  Image = "https://balta.io",
  PasswordHash = "12309876"
};

Category category = new Category
{
  Name = "Backend",
  Slug = "backend"
};

Post post = new Post
{
  Author = user,
  Category = category,
  Body = "<p>Hello world</p>",
  Slug = "comecando-com-ef-core",
  Summary = "Neste artigo...",
  Title = "Começando com EF Core",
  CreateDate = DateTime.Now,
  LastUpdateDate = DateTime.Now
}; // O EF tem capacidade de referenciar os obj author e category, e conseguir inseri-los no banco

context.Posts.Add(post);
context.SaveChanges();
