using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      // Tabela
      builder.ToTable("Category", "dbo");

      // Chave Primária
      builder.HasKey(x => x.Id);

      // Identity
      builder.Property(x => x.Id)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn(); // PRIMARY KEY IDENTITY (1, 1)
      
      // Propriedades
      builder.Property(x => x.Name)
        .IsRequired()
        .HasColumnName("Name")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80);
    
      builder.Property(x => x.Slug)
        .IsRequired()
        .HasColumnName("Slug")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80);

      
    }
}
