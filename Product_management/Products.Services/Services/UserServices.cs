using Products.DataAccess.Models;
using Products.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Services.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public User? GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public int UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        public int DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public User? Login(string email, string password)
        {
            return _userRepository.Login(email, password);
        }
    }
}
