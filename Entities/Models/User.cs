using System;
using Newtonsoft.Json;

namespace Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonRequired]
        public string Username { get; set; }
        [JsonRequired]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
