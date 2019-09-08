using InternetMoviesOnDemand.Data;
using InternetMoviesOnDemand.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetMoviesOnDemand.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private InMemoryDataContext _context;
        public UserRepository(InMemoryDataContext context)
        {
            _context = context;
        }
        public User GetUserByUserName(string userName)
        {
            return _context.Users.Where(x => x.UserName == userName).SingleOrDefault();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users;
        }

        public void RegisterUser(User user)
        {
            try
            {
                _context.Users.Add(new User { Id = _context.Users.Count + 1, Email = user.Email, UserName = user.UserName, Password = user.Password, Role = user.Role });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
