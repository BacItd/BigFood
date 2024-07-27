using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFoodData.Models
{
    public class CartDetail
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public byte Status { get; set; }

        public double Total { get; set; }

        public Guid CartId { get; set; }

        public Guid FoodId { get; set; }

        public virtual Cart? Carts { get; set; }
    }
}
