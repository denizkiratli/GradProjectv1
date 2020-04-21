using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
    }

}
