using InternetMoviesOnDemand.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InternetMoviesOnDemand.Data
{
    public class InMemoryDataContext : DbContext
    {
        public InMemoryDataContext(DbContextOptions<InMemoryDataContext> context) : base(context)
        {

        }

        private List<User> users = new List<User>
        {
            new User { Id = 1, UserName = "fred", Password = "F@123", Email="Fred@gmail.com", Role = "Administrator"},
            new User { Id = 2, UserName = "alice", Password = "456", Email="Alice1@gmail.com", Role = "Viewer"},
        };


        private List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, CategoryName = "Comedy" },
            new Category { Id = 2, CategoryName = "Horrer" }
        };

        private List<Video> videos = new List<Video> {
            new Video{ Id = 1, CategoryId = 1, VideoName= "Golmaal: Fun Unlimited", VideoDescription="This is a comedy movie and first in the golmaal series  directed by Rohit Shetty. Casting Ajay Devgn, Arshad Warsi and Tusshar Kapoor.", VideoPath="C:\\Movies\\Golmaal", VideoSize = "700 MB"},
            new Video{ Id = 2, CategoryId = 1, VideoName= "Golmaal Returns", VideoDescription="This is a comedy movie and Second in the golmaal series  directed by Rohit Shetty. Casting Ajay Devgn, Kareena Kapoor, Amrita Arora, Shreyas Talpade, Celina Jaitley, Arshad Warsi and Tusshar Kapoor.", VideoPath="C:\\Movies\\Golmaal", VideoSize = "700 MB"}
        };

        public List<Category> Categories { get => _categories; set => _categories = value; }

        public List<Video> Videos { get => videos; set => videos = value; }
        public List<User> Users { get => users; set => users = value; }
    }
}
