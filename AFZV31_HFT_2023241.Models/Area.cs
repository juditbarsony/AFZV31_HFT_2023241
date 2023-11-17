using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Models
{
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AreaId { get; set; }
        public double AreaSize { get; set; }

        public string AnnualId { get; set; }

        private string line;
        [NotMapped]
        public virtual Annual Annuals { get; set; }

        public Area()
        {
            //Annuals = new HashSet<Annual>();
        }

        //public Area() { }

        public Area(int areaId, double areaSize)
        {
            AreaId = areaId;
            AreaSize = areaSize;
        }
        public Area (string line)
        {
            string[] split = line.Split('#');
            AreaId = int.Parse(split[0]);
            AreaSize = double.Parse(split[1]);
            AnnualId = split[2];
        }
       


    }
}
