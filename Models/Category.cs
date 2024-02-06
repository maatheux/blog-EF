using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models;

[Table("Category")] // Mapeamento Data Annotations / caso nao informe o nome da tabela ira pegar o nome do DbSet
public class Category
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // gerado o id pelo banco
  public int Id { get; set; }
  public string Name { get; set; }
  public string Slug { get; set; }
  
}
