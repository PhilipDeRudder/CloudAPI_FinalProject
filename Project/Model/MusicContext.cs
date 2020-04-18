using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options): base(options)
        {

        }

        public DbSet<Album> Albums {get; set;}
        public DbSet<Artist> Artists {get; set;}
        public DbSet<Track> Tracks {get; set;}


    }
}