using F3WOT.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace F3WOT.Business
{
    public class FeedDbContext : DbContext
    {
        public DbSet<NuFeed> Feeds {  get; set; }
        public FeedDbContext()
        {

        }
    }
}
