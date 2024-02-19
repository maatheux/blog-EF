using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings;

public class PostMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Post", "dbo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
          .ValueGeneratedOnAdd()
          .UseIdentityColumn();
        
        builder.Property(x => x.LastUpdateDate)
          .IsRequired()
          .HasColumnName("LastUpdateDate")
          .HasColumnType("SMALLDATETIME")
          //.HasDefaultValueSql("GETDATE()"); /* gerado no sql */
          .HasDefaultValue(DateTime.Now.ToUniversalTime()); // gerado no .NET
        
        
        builder.HasIndex(x => x.Slug, "IX_Post_Slug")
          .IsUnique();

        // RELACIONAMENTOS
        builder.HasOne(x => x.Author)
          .WithMany(x => x.Posts)
          .HasConstraintName("FK_Post_Author")
          .OnDelete(DeleteBehavior.Cascade); // relacionamento 1-N

        builder.HasOne(x => x.Author)
          .WithMany(x => x.Posts)
          .HasConstraintName("FK_Post_Category")
          .OnDelete(DeleteBehavior.Cascade);

        // se fosse relacinamento 1-1 -> builder.OwnsOne()

        builder.HasMany(x => x.Tags)
          .WithMany(x => x.Posts)
          .UsingEntity<Dictionary<string, object>>(
            "PostTag",
            post => post.HasOne<Tag>() /* outra forma de ref o relacionamento */
              .WithMany() /* nao precisa especificar pq eh uma classe virtual */
              .HasForeignKey("PostId")
              .HasConstraintName("FK_PostTag_PostId")
              .OnDelete(DeleteBehavior.Cascade),
            tag => tag.HasOne<Post>()
              .WithMany()
              .HasForeignKey("TagId")
              .HasConstraintName("FK_PostTag_TagId")
              .OnDelete(DeleteBehavior.Cascade)
          );
    }
}