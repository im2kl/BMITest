using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BMIteat.Models
{
    public class UserBMI
    {
        [Key]
        public int BMIID { get; set; }

        [Required(ErrorMessage ="Height is a required Numeric field.")]
        [RegularExpression(@"^[0-9]+$")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Weight is a required Numeric field.")]
        [RegularExpression(@"^[0-9]+$")]
        public double Weight { get; set; }
        
        public byte BMItype { get; set; }
    }

}