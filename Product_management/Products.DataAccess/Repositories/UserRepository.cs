using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.DataAccess.Models;

namespace Products.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly ProductsDbContext _context;
        public UserRepository(ProductsDbContext context)
        {  _context = context; }
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public int UpdateUser(User user)
        {
            var existingUser = GetUserById(user.Id);
            if (existingUser == null)
                return -1;

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password; 
            existingUser.Role = user.Role;

            _context.SaveChanges();
            return 1;
        }

        public int DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user == null)
                return -1;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return 1;
        }

        public User? Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

    }
}
