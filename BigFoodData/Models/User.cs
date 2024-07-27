using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFoodData.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string name { get; set; }

        public string email { get; set; }

        public string phoneNumber { get; set; }

        public string address { get; set; }

        public string userName { get; set; }

        public int accumulatepoint { get; set; }

        public byte status { get; set; }

        public string password { get; set; }

        public int RoleId { get; set; }

        public virtual Cart? Cart { get; set; }

        public virtual Role? Role { get; set; }

        public virtual ICollection<Bill> Bill { get; set; }
    }
}
