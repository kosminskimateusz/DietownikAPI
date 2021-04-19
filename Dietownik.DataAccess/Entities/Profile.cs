using System.Collections.Generic;

namespace Dietownik.DataAccess.Entities
{
    public class Profile : EntityBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Day> Days { get; set; }
        public List<Message> Messages { get; set; }
        public int UserId { get; set; }
    }
}