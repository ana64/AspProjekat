using AspMovie.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AspMovie.DataAccess.Configurations
{
    public class GenreConfication : EntityConfiguration<Genre>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(x => x.GenreName).HasMaxLength(30).IsRequired();

            builder.HasIndex(x=>x.GenreName).IsUnique();

            builder.HasData(
                   new Genre {Id=1, GenreName = "Action", CreatedAt = System.DateTime.UtcNow },
                   new Genre {Id=2, GenreName = "Comedy" , CreatedAt = System.DateTime.UtcNow },
                   new Genre {Id=3, GenreName = "Romance" , CreatedAt = System.DateTime.UtcNow }
                );
                      
        }
    }
}
