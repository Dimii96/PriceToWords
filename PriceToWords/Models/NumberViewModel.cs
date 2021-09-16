using System;
using System.ComponentModel.DataAnnotations;

namespace PriceToWords.Models
{
    public class PriceViewModel
    {
        public string PriceAsText { get; set; }
        public decimal Price { get; set; } 
    }
}
