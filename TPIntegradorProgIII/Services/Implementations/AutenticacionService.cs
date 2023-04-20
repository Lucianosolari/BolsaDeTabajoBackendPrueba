using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;
using TPIntegradorProgIII.Services.Interfaces;

namespace TPIntegradorProgIII.Services.Implementations
{
    public class AutenticacionService : ICustomAuthenticationService
    {
        private readonly IStudentRepository _swimmerRepository;

        public AutenticacionService(IStudentRepository swimmerRepository)
        {
            _swimmerRepository = swimmerRepository;
        }
        
        public Student? ValidateSwimmer(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;
            return _swimmerRepository.ValidateSwimmer(authenticationRequest);
        }
    }
}
