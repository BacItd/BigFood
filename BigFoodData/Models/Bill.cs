using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFoodData.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }

        public double total { get; set; }

        public DateTime DateCreate { get; set; }

        public byte Status { get; set; }

        public Guid UserId { get; set; }

        public virtual User? User { get; set; }

        public virtual ICollection<BillDtail>? BillDetail { get; set; }
    }
}
