using CodelineAirlines.Shared.Models.DTOs.UserDTOs;
using CodelineAirlines.Shared.Models;

namespace CodelineAirlines.Website.Services.ClientServices
{
    public interface IUserService
    {
        bool Register(UserInputDTOs userInput);
        public User login(string email, string password);
        public UserOutputDTO GetUserByID(int id);
        public string GenerateJwtToken(string userId, string username, string role);
        public void UpdateUsers(UserInputDTOs userInputDTO, int id);
        public void DeactivateUser(int userId);
        public void ReactivateUser(int userId);

        User GetUserByIdWithRelatedData(int userId);
    }
}