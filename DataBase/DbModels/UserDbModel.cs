using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbModels
{
    public class UserDbModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        private UserDbModel()
        {

        }

        public UserDbModel(string name, string email, string password, string role)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Role = role;
        }
    }
}
