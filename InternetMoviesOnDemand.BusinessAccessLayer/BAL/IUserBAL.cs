using InternetMoviesOnDemand.BusinessAccessLayer.ViewModel;
using System.Collections.Generic;

namespace InternetMoviesOnDemand.BusinessAccessLayer.BAL
{
    public interface IUserBAL
    {
        /// <summary>
        /// To login user/admin
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        UserVM Login(LoginVM login);

        /// <summary>
        /// To register users
        /// </summary>
        /// <param name="userVM"></param>
        void Register(UserVM userVM);

        /// <summary>
        /// Get all the users along with administrator
        /// </summary>
        /// <returns></returns>
        List<UserVM> GetAllUsers();
    }
}
