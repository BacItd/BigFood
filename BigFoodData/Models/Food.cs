using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFoodData.Models
{
    public class Food
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime DateCreate { get; set; }

        public string? Ingredient { get; set; }

        public string? ImageUrl { get; set; }

        public string QrCode { get; set; }

        public double PriceCurrent { get; set; }

        public double? PriceSale { get; set; }

        public int Quantity { get; set; }

        public int? QuantitySold { get; set; }

        public byte Status { get; set; }

        public int CategoryId { get; set; }

        public Guid? SaleId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual Sale? Sale { get; set; }

        public virtual ICollection<BillDtail>? BillDetail { get; set; }
    }
}
