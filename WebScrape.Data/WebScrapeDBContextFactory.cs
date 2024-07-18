using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrape.Data
{
    public class WebScrapeDBContextFactory : IDesignTimeDbContextFactory<WebScrapeDB>
    {
        public WebScrapeDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebScrapeDB>();
            //optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=WebScrape;Integrated Security=True");
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=WebScrape;Integrated Security=True;TrustServerCertificate=True");

            return new WebScrapeDB(optionsBuilder.Options);
        }
    }
}
