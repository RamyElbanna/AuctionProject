using Auction.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

namespace Auction.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Bidder> Bidders { get; set; }
        public DbSet<AuctionWinnerDetails> AuctionWinnerDetails { get; set; }
    }
}
