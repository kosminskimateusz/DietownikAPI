using System.Collections.Generic;

namespace Dietownik.DataAccess.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool SpecialUser { get; set; }
        public UserProfile Profile { get; set; }
    }
}