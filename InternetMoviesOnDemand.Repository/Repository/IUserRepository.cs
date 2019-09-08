using InternetMoviesOnDemand.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMoviesOnDemand.Repository.Repository
{
    public interface IUserRepository
    {
        User GetUserByUserName(string userName);

        void RegisterUser(User user);

        List<User> GetAllUsers();
    }
}
