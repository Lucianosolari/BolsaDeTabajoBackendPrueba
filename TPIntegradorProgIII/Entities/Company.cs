using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPIntegradorProgIII.Entities
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public string MeetName { get; set; }

        [Required]
        public string MeetDate { get; set; }

        [Required]
        public string MeetPlace { get; set; }
        public List<Offer> Trials { get; set; } = new List<Offer>();
    }
}
