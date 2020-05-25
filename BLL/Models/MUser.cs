using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MUser
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int RoleId { get; set; }

        public string Login { get; set; }

        public string Pass { get; set; }
    }
}
