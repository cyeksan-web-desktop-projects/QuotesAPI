using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UserDataAccess;

namespace CansuAPI.Models
{
    public class QuotesResult
    {
        public bool IsSuccess { get; set; }

        
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Quote> Quotes { get; set; }
    }
}
