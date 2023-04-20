using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Data.Repository.Interfaces
{
    public interface IStudentRepository
    {
        public Student? GetSingleSwimmer(int id);
        public List<Student> GetSwimmers();
        public void AddSwimmer(Student swimmer);
        public void RemoveSwimmer(int id);
        public void EditSwimmerName(int id, string newName);
        public void EditSwimmerSurname(int id, string surname);
        public Student? ValidateSwimmer(AuthenticationRequestBody swimmer);
        List<Offer> GetExistingTrials();
        public string GetAttendedTrial(int id);
    }
}
