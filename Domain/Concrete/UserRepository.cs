using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entitis;

namespace Domain.Concrete
{
    public class UserRepository : IUserRepository
    {
        private EFDbContext contex = new EFDbContext();
        
        public IQueryable<User> Users { get { return contex.Users; } }

        public void AddUser(User user)
        {
            contex.Users.Add(user);
            contex.SaveChanges();
        }

        public User DeleteUser(int id)
        {
            User dbEntry = contex.Users.Find(id);
            if (dbEntry != null)
            {
                contex.Users.Remove(dbEntry);
                contex.SaveChanges();
            }
            return dbEntry;
        }

        public void UpdateUser(User user)
        {
            User dbEntry = contex.Users.Find(user.Id);
            if (dbEntry != null)
            {
                dbEntry.Email = user.Email;
                dbEntry.Cars = user.Cars;
                dbEntry.Jewelry = user.Jewelry;
                dbEntry.Realty = user.Realty;
                dbEntry.Telephones = user.Telephones;
            }

            contex.SaveChanges();
        }
    }
}
