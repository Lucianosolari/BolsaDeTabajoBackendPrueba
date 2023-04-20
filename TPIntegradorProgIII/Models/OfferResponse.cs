using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Models
{
    public class OfferResponse
    {
        public int Id { get; set; }
        public int Distance { get; set; }
        public string Style { get; set; }
        public string MeetName { get; set; }
        public int MeetId { get; set; }

        public List<Student> RegisteredSwimmers { get; set; } = new List<Student>();
    }
}
