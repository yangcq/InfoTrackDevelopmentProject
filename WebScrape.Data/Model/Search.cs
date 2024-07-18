using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SearchEngine.Library;

namespace WebScrape.Data.Model
{
    [Index(nameof(HashValue))]
    public class Search
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public SearchEngineType SearchEngine { get; set; }

        [Required]
        public string KeyWord { get; set; }

        [Required]
        public string TargetURL { get; set; }

        [Required]
        public int SearchCount { get; set; } = 1;

        [Required]
        public string HashValue { get; set; }

        public virtual ICollection<Ranking> Rankings { get; set; }

        public new string GetHashCode()
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return Convert.ToBase64String(algorithm.ComputeHash(Encoding.UTF8.GetBytes(SearchEngine + KeyWord + TargetURL)));
        }
    }
}
