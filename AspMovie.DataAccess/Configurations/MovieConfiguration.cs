using AspMovie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AspMovie.DataAccess.Configurations
{
    public class MovieConfiguration : EntityConfiguration<Movie>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ReleaseDate).IsRequired();
            builder.Property(x => x.RunTimeInMinutes).IsRequired();
            builder.Property(x => x.Poster).HasMaxLength(300);

            builder.HasMany(x => x.Actors)
                   .WithOne(x => x.Movie)
                   .HasForeignKey(x => x.MovieId)
                   .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
