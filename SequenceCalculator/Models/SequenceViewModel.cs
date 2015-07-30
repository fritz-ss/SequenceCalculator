using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SequenceCalculator.Models
{
    public class SequenceViewModel
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Must be a positive integer")]
        public int input { get; set; }

        [Display(Name = "All Numbers")]
        public string allNumbers { get; set; }

        [Display(Name = "Odd Numbers")]
        public string oddNumbers { get; set; }

        [Display(Name = "Even Numbers")]
        public string evenNumbers { get; set; }

        [Display(Name = "Fizz Buzz Numbers")]
        public string fizzBuzzNumbers { get; set; }

        [Display(Name = "Fibonacci Numbers")]
        public string fibonacciNumbers { get; set; }
    }
}