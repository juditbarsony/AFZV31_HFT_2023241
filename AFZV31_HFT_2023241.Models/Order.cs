using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public string OrderCompany { get; set; }
        public string OrderPackaging { get; set; }
        public int Price { get; set; }

        public string AnnualCode { get; set; }

        private string line;

        [NotMapped]
        public virtual Annual Annuals { get; set; }
        public Order()
        {
     
        }

        public Order(int orderId, string orderCompany, string orderPackaging, int price)
        {
            this.OrderId = orderId;
            this.OrderCompany = orderCompany;
            this.OrderPackaging = orderPackaging;
            this.Price = price;
        }

        public Order(string line)
        {
            string[] split = line.Split('#');
            OrderId = int.Parse(split[0]);
            AnnualCode = split[1];
            OrderCompany = split[2];
            OrderPackaging = split[3];
            Price = int.Parse(split[4]);
        }


    }
}
