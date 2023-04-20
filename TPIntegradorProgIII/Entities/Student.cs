using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using TPIntegradorProgIII.Helpers;

namespace TPIntegradorProgIII.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        // inicio datos personales
        public int File { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string AltEmail { get; set; }
        public string DocumentType { get; set; } // Ver tabla aparte (se repite la palabra)

        public int DocumentNumber { get; set; }

        public int CUIL_CUIT { get; set; }

        public DateTime Birth { get; set; }

        public string Sex { get; set; } //Ver tabla aparte (se repite la palabra)
        public string CivilStatus { get; set; } // Ver tabla aparte (se repite la palabra)

        // Domicilio familiar

        public string Street { get; set; }
        public int StreetNumber { get; set; }

        public string StreetLetter { get; set; }

        public int Floor { get; set; }

        public string Department { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string Location { get; set; }

        public int PersonalPhone { get; set; }

        public int OtherPhone { get; set; }

        //Domicilio Personal  ?


        // Datos universitarios? Va aca?

        public string Specialty { get; set; }
        public int ApprovedSubjects { get; set; }

        public int SpecialtyPlan { get; set; }
        public int StudyYear{ get; set; }
        public int Turn { get; set; }
        public int AverageWithPostponement { get; set; }
        public int AverageWithoutPostponement { get; set; }
        public string CollegeDegree { get; set; }


        // Otros datos

        public string SecondaryDegree { get; set; }

        public string CVFile { get; set; } // public HttpPostedFileBase Archivo { get; set; }

        public string Observations { get; set; }

        // Actualizar Contenido

        public string Knowledge { get; set; }
        public string Value { get; set; }



        [ForeignKey("TrialId")]
        public Offer Trial { get; set; }
        public int TrialId { get; set; }
    }
}
