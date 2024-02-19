
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.Clear();

using var context = new BlogDataContext();

// context.Users.Add(new User
// {
//   Bio = "Teste",
//   Email = "matheus@mail.com",
//   Image = "https://balta.io",
//   Name = "Matheus",
//   PasswordHash = "1234",
//   Slug = "matheus-lima"
// });

var user = context.Users.FirstOrDefault();

var post = new Post
{
  Author = user,
  Body = "Meu artigo",
  Category = new Category
  {
    Name = "Backend",
    Slug = "backend"
  },
  CreateDate = System.DateTime.Now,
  // LastUpdateDate = // Default Value
  Slug = "meu-artigo",
  Summary = "Neste artigo...",
  // Tags = null,
  Title = "Meu artigo"
};

context.Posts.Add(post);

context.SaveChanges();
