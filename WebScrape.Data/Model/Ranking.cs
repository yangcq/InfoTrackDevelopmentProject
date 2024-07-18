using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrape.Data.Model
{
    public class Ranking
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Rank { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public int SearchId { get; set; }
        [Required]
        public virtual Search Search { get; set; }
    }
}
