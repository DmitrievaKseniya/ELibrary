using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Repository
{
    public class UserRepository
    {
        private AppContext db = new AppContext();
        public Users SelectByID(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<Users> SelectAll()
        {
            return db.Users.ToList();
        }

        public void Add(string name, string email, string role)
        {
          
            var user = new Users { Name = name, Email = email, Role = role };
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = SelectByID(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void UpdateUserName(int id, string newName)
        {
            var user = SelectByID(id);
            user.Name = newName;
            db.SaveChanges();
        }
    }
}
