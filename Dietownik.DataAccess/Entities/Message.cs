namespace Dietownik.DataAccess.Entities
{
    public class Message : EntityBase
    {
        public string Content { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}