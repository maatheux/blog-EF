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
        

        // builder.Property(x => x.Bio);
        // builder.Property(x => x.Email);
        // builder.Property(x => x.Image);
        // builder.Property(x => x.PasswordHash);
        
        // builder
        // .HasIndex(x => x.Slug, "IX_User_Slug")
        // .IsUnique();

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
    }
}