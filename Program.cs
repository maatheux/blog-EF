
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.Clear();

using (var contex = new BlogDataContext())
{
  
  Tag? tag = contex
    .Tags
    .AsNoTracking()
    .FirstOrDefault(x => x.Id == 3);
    //.Single() => so pega se o item for unico

  Console.WriteLine(tag?.Name);

}
