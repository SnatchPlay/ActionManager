using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] Password { get; set; }
        public string Email { get; set; }
        public Guid Salt { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public User(string Login,byte[] Password,string Email,Guid Salt,DateTime RowInsertTime,DateTime RowUpdateTime,int id=0)
        {
            this.Login = Login;
            this.Password = Password;
            this.Email = Email;
            this.Salt = Salt;
            this.RowInsertTime = RowInsertTime;
            this.RowUpdateTime = RowUpdateTime;
            this.Id = id;

        }
    }
}
