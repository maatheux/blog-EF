
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.Clear();

using (var contex = new BlogDataContext())
{
  
  IEnumerable<Tag> tags = contex
    .Tags
    .AsNoTracking()
    .ToList(); // nao ira trazer os metadados do bd, nao esta tendo um tracking. Recomendado quando nao for usar para Delete, Update

  foreach (Tag tag in tags)
  {
    Console.WriteLine(tag.Name);
  }

}
