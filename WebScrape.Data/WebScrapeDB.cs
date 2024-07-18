using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Data.Model;

namespace WebScrape.Data
{
    public class WebScrapeDB : DbContext
    {
        public virtual DbSet<Search> Searches { get; set; }
        public virtual DbSet<Ranking> Rankings { get; set; }

        public WebScrapeDB(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Search>()
                .HasMany(e => e.Rankings)
                .WithOne(e => e.Search)
                .HasForeignKey(e => e.SearchId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Search>().HasData(
                new Search() { Id = 1, SearchEngine = 0, KeyWord = "land registry searches", TargetURL = "www.infotrack.co.uk", SearchCount = 10, HashValue = "Gy5UjIUl1iE4N2YN/26EkLQ9mj55bSVB7Z/kGLvRXkU=" }
                );
            modelBuilder.Entity<Ranking>().HasData(
                new Ranking() { Id = 1, Rank = 42, Created = new DateTime(2024, 7, 1, 10, 0, 0), SearchId = 1 },
                new Ranking() { Id = 2, Rank = 33, Created = new DateTime(2024, 7, 2, 10, 0, 0), SearchId = 1 },
                new Ranking() { Id = 3, Rank = 56, Created = new DateTime(2024, 7, 3, 10, 0, 0), SearchId = 1 },
                new Ranking() { Id = 4, Rank = 12, Created = new DateTime(2024, 7, 4, 10, 0, 0), SearchId = 1 },
                new Ranking() { Id = 5, Rank = 56, Created = new DateTime(2024, 7, 5, 10, 0, 0), SearchId = 1 },
                new Ranking() { Id = 6, Rank = 45, Created = new DateTime(2024, 7, 6, 10, 0, 0), SearchId = 1 },
                new Ranking() { Id = 7, Rank = 33, Created = new DateTime(2024, 7, 7, 10, 0, 0), SearchId = 1 },
                new Ranking() { Id = 8, Rank = 45, Created = new DateTime(2024, 7, 8, 10, 0, 0), SearchId = 1 },
                new Ranking() { Id = 9, Rank = 34, Created = new DateTime(2024, 7, 9, 10, 0, 0), SearchId = 1 },
                new Ranking() { Id = 10, Rank = 67, Created = new DateTime(2024, 7, 10, 10, 0, 0), SearchId = 1 }
                );
        }
    }
}