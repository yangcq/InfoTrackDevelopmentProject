using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebScrape.Service.DTOs
{
    public abstract class BaseResult
    {
        [JsonIgnore]
        public List<string>? Errors { get; set; }
    }
}
