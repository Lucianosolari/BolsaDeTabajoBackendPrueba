using TPIntegradorProgIII.Entities;

namespace TPIntegradorProgIII.Models
{
    public class CompanyResponse
    {
        public int Id { get; set; }
        public string MeetName { get; set; }
        public string MeetDate { get; set; }
        public string MeetPlace { get; set; }
        public List<Offer> Trials { get; set; } = new List<Offer>();
    }
}
