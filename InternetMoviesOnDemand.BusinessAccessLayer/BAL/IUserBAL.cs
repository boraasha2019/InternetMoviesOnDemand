using InternetMoviesOnDemand.BusinessAccessLayer.ViewModel;
using InternetMoviesOnDemand.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMoviesOnDemand.BusinessAccessLayer.BAL
{
    public interface IUserBAL
    {
        UserVM Login(LoginVM login);
        void Register(UserVM userVM);
        List<UserVM> GetAllUsers();
    }
}
