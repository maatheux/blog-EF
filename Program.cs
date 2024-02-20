
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.Clear();

using var context = new BlogDataContext();

// Lazy Loading
var posts = context.Posts;
foreach (var post in posts)
{
  foreach (var tag in post.Tags)
  {

  }
}
// Com a list de tags utilizando o mod de acesso 'virtual' permite utilizar o recurso de lazy loading, carregando apenas quando tags for chamada
// Porem no EF nao eh mt interessante pois nao ira realizar o inner join e sim um select atras do outro


// Eager Loading (default) -> so ira trazer os dados caso seja requerido a inclusao
var postList = context.Posts.Include(x => x.Tags).Select(x => new
{
  Id = x.Id,
  // ...
}); // o select melhora na performace
