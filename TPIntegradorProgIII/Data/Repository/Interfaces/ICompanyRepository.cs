using TPIntegradorProgIII.Entities;


namespace TPIntegradorProgIII.Data.Repository
{
   
    public interface ICompanyRepository
    {
        public Company? GetSingleMeet(int id);
        public List<Company> GetMeets();
        public void AddMeet(Company newMeet);
        public void RemoveMeet(int id);
        public void EditMeetDate(int id, string newMeetDate);
        public List<Offer> GetTrials(int id);
    }
}
