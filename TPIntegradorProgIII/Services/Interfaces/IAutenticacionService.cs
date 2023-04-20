using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Services.Interfaces
{
    public interface ICustomAuthenticationService
    {
        Student? ValidateSwimmer(AuthenticationRequestBody authenticationRequestBody);
    }
}
