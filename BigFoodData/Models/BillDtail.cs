using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFoodData.Models
{
    public class BillDtail
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public double PriceCurrent { get; set; }

        public double PriceSale { get; set; }

        public int BillId { get; set; }

        public Guid FoodId { get; set; }

        public virtual Bill? Bill { get; set; }

        public virtual Food? Food { get; set; }
    }
}
