using Blog.Data.Mappings;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data;

public class BlogDataContext : DbContext
{
  public DbSet<Category> Categories { get; set; }
  public DbSet<Post> Posts { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<Tag> Tags { get; set; }
  
  public DbSet<PostWithTagsCount> postWithTagsCount { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) 
      => options.UseSqlServer("Server=localhost,1433;Initial Catalog=BlogFluentMap;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new PostMap());

        modelBuilder.Entity<PostWithTagsCount>(x => 
        {
          x.ToSqlQuery(@"
            SELECT 
              [Title] AS [Name],
              SELECT COUNT([Id]) FROM [Tag] WHERE [PostId] = [Id] AS [Count]
            FROM
              [Posts]
          ");
        });
    }

}
