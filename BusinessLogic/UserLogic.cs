using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Repository;
using DTO;

namespace BusinessLogic
{
    public class UserLogic
    {
        public IRepository<User> repository = new UserRepository();
        List<User> users;
        public UserLogic()
        {
             users = repository.GetEnteties();
        }
        public void CreateNewUser(string Login,string Password,string Email)
        {
            if (users.Any(u => u.Login == Login))
            {
                throw new Exception("User already exist");
            }
            Guid salt = Guid.NewGuid();
            DateTime dateTime = DateTime.Now;
            User user = new User(Login, hash(Password, salt.ToString()), Email, salt, dateTime, dateTime,3);
            repository.AddObj(user);
        }
        public bool UserLogin(string Login,string password)
        {
            foreach(User user in users)
            {

                if((user.Login == Login) && ((checkpass(hash(password, user.Salt.ToString()),user.Password)==true))&&(checkrole(Login)==true)) { return true; }
            }
            return false;

        }
        private byte[] hash(string password,string salt)
        {
            var code = SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(password+salt));
            return code;
        }
        public bool checkpass(byte[] hashs, byte[] pass)
        {
           
            for(int i = 0; i < hashs.Length; i++)
            {
                if(hashs[i] != pass[i])
                {
                    return false;
                }
            }
            return true;
        }
        public bool checkrole(string Login)
        {
            foreach(User user in users)
            {
                if ((user.Login == Login) && (user.RoleId == 1))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
