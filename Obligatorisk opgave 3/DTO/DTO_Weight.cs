using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Weight
    {
        //Jeg har ændret BMI til double fra int
        public double Weight_ { get; set; }
        public double BMI_ { get; set; }
        public DateTime Date_ { get; set; }

        public DTO_Weight(double weight, double BMI, DateTime date)
        {
            Weight_ = weight;
            BMI_ = BMI;
            Date_ = date;
        }
    }
}