using System.Collections.Generic;
using System.Linq;
using MobileQuiz.Models;

namespace MobileQuiz.Services
{
    public class UserService
    {
        readonly MobileQuizEntities _dbContext = new MobileQuizEntities();

        public bool AddUser(string name, string email, string password)
        {
            if (_dbContext.UserSets.Any(x => x.Email == email))
            {
                return false;
            }
            else
            {
                _dbContext.UserSets.Add(new UserSet
                {
                    Name = name,
                    Email = email,
                    Password = password,
                });
                _dbContext.SaveChanges();
                return true;
            }
        }

        public void UpdateUser(int id, string name, string email, string password)
        {
            var user = _dbContext.UserSets.First(x => x.Id == id);
            user.Name = name;
            user.Email = email;
            user.Password = password;
            _dbContext.SaveChanges();
        }

        public UserSet GetUserById(int id)
        {
            return _dbContext.UserSets.First(x => x.Id == id);
        }

        public List<UserSet> GetAllUsers()
        {
            return _dbContext.UserSets.ToList();
        }

        public int Login(string email, string password) 
        {
            var user = _dbContext.UserSets.FirstOrDefault(x => x.Email == email && x.Password == password);
            return user == null ? 0 : user.Id;
        }
    }
}