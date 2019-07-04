using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Models.BindingModels
{
    public class EventCreateBindingModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Place")]
        public string Place { get; set; }

        [Required]
        [Display(Name = "Start")]
        public DateTime Start { get; set; }
        [Required]
        [Display(Name = "End")]
        public DateTime End { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Total tickets must be a positive number.")]
        [Display(Name = "Total Tickets")]
        public int TotalTickets { get; set; }

        [Required]
        [Display(Name = "Price Per Ticket")]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335", ErrorMessage = "Total tickets must be a positive number.")]
        public decimal PricePerTicket { get; set; }
    }
}
