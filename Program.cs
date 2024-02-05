
using Blog.Data;
using Blog.Models;

Console.Clear();

using (var contex = new BlogDataContext())
{
  // CREATE
  // Tag tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
  // contex.Tags.Add(tag);
  // contex.SaveChanges(); // o contex salva em memoria, para persistir as alteracoes no banco utilizar o SaveChanges


  // UPDATE
  // Tag tag = contex.Tags.FirstOrDefault(x => x.Id == 5); // realizar o tracking, trazendo os dados do bd ao inves de criar usando New

  // tag.Name = ".NET";
  // tag.Slug = "dotnet";

  // contex.Tags.Update(tag);
  // contex.SaveChanges();


  // DELETE
  // Tag tag = contex.Tags.FirstOrDefault(x => x.Id == 5);

  // contex.Tags.Remove(tag);
  // contex.SaveChanges();


  // SELECT
  // IEnumerable<Tag> tags = contex.Tags; // nao executa no bd, eh uma referencia, mas tras os dados de Tags

  IEnumerable<Tag> tags = contex.Tags.ToList();
  // ATENTAR A ORDEM DOS FILTROS
  // IEnumerable<Tag> tags = contex
  //   .Tags
  //   .ToList()
  //   .Where(x => x.Name.Contains(".NET"));
  // O where ira executar em memoria e nao no sql no bd, reduz a performace -> ToList como ultimo!


  foreach (Tag tag in tags)
  {
    Console.WriteLine(tag.Name);
  }

}
