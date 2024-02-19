
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.Clear();

User user = new User
{
  Bio = "Teste",
  Email = "matheus@mail.com",
  GitHub = "maatheux",
  Image = "https://balta.io",
  Name = "Matheus",
  PasswordHash = "1234",
  Slug = "matheus-lima"
};

using var context = new BlogDataContext();
context.Users.Add(user);
context.SaveChanges();

// dotnet tool install --global dotnet-ef  --> instalacao ferramenta para criar as migrations

// dotnet ef migrations add/remove <nome-migration>  --> criando migration

// dotnet ef database update  --> executando migration no bd
