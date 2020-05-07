using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class MusicContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ArtistTrack>().HasKey(sa => new { sa.ArtistId, sa.TrackId });
        }

        public MusicContext(DbContextOptions<MusicContext> options): base(options)
        {


        }

        public DbSet<Album> Albums {get; set;}
        public DbSet<Artist> Artists {get; set;}
        public DbSet<Track> Tracks {get; set;}

        public DbSet<ArtistTrack> ArtistTracks{get;set;}


    }
}