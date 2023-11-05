using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Models
{
    public class Annual
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(100)]
        public int AnnualId { get; set; }

        [Required]
        [StringLength(300)]
        public string AnnualShortName { get; set; }

        [Required]
        [StringLength(300)]
        public string AnnualName { get; set; }

        public int Pcsm2 { get; set; }

        // Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\annuals.mdf;Integrated Security = True

        public int AreaId { get; set; }
        public int OrderId { get; set; }

        public virtual ICollection <Area> Areas{ get; set; }
        public virtual ICollection <Order> Orders { get; set; }


        private string line;
        public Annual()
        {
        
        }

        public Annual(string line)
        {
            string[] split = line.Split('#');
            AnnualId = int.Parse(split[0]);
            AnnualShortName = split[1];
            AnnualName = split[2];
            Pcsm2 = int.Parse(split[3]);
        }

        public Annual(int annualId, string annualShortName, string annualName, int pcsm2)
        {
            this.AnnualId = annualId;
            this.AnnualShortName = annualShortName;
            this.AnnualName = annualName;
            this.Pcsm2 = pcsm2;
        }

      
        
    }
}
