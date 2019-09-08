using InternetMoviesOnDemand.Repository.Model;
using System.Collections.Generic;

namespace InternetMoviesOnDemand.Repository.Repository
{
    public interface IUserRepository
    {
        User GetUserByUserName(string userName);

        void RegisterUser(User user);

        List<User> GetAllUsers();
    }
}
