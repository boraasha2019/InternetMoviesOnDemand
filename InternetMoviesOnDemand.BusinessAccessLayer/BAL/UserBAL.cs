using InternetMoviesOnDemand.BusinessAccessLayer.ViewModel;
using InternetMoviesOnDemand.Repository.Model;
using InternetMoviesOnDemand.Repository.Repository;
using System.Collections.Generic;

namespace InternetMoviesOnDemand.BusinessAccessLayer.BAL
{
    public class UserBAL : IUserBAL
    {
        private IUserRepository _userRepository;
        public UserBAL(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// MEthod to check if user exists in Context
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public UserVM Login(LoginVM login)
        {
            //check if the user exists in the list
            var user = _userRepository.GetUserByUserName(login.Username);

            if (user != null && user.Password == login.Password)
            {
                return new UserVM { UserId = user.Id, UserName = user.UserName, Email = user.Email, Role = user.Role };
            }
            return null;
        }


        public void Register(UserVM userVM)
        {
            var user = new User { UserName = userVM.UserName, Email = userVM.Email, Id = userVM.UserId, Password = userVM.Password, Role = userVM.Role };
            if (_userRepository.GetUserByUserName(user.UserName) == null)
                _userRepository.RegisterUser(user);

        }

        public List<UserVM> GetAllUsers()
        {
            var userVM = new List<UserVM>();
            var users = _userRepository.GetAllUsers();
            if (users.Count != 0)
            {
                foreach (var user in users)
                {
                    userVM.Add(new UserVM { UserId = user.Id, Email = user.Email, UserName = user.UserName, Password = user.Password, Role = user.Role });
                }
            }
            return userVM;
        }

    }
}
