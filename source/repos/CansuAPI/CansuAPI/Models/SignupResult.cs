using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UserDataAccess;

namespace CansuAPI.Models
{
    public class SignupResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public User User { get; set; }

    }
}
