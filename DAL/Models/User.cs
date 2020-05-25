using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
      
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public string Login { get; set; }

        public string Pass { get; set; }

    }
}
