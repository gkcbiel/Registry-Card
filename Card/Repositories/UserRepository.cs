using Cards.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Repositories
{
    public class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User
            {
                Id = 1,
                Username = "Gabriel",
                Password = "desafio"
            });
            users
                .Add(new User
                {
                    Id = 2,
                    Username = "Hyperativa",
                    Password = "desafio"
                });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
