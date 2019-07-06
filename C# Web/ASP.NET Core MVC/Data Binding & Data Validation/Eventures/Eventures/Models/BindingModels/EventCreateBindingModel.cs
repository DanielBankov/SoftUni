using Eventures.ModelBinders;
using Eventures.ValidationAttributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Models.BindingModels
{
    public class EventCreateBindingModel
    {
        [Required]
        [Display(Name = "Name")]
        [StringLength(10, ErrorMessage = "Name must contains at least 10 symbols")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Place")]
        public string Place { get; set; }

        [Required]
        [Display(Name = "End")]
        [DataType(DataType.Date)]
        //[ModelBinder(typeof(DateTimeToYearModelBinder))]
        public DateTime End { get; set; }

        [Required]
        [Display(Name = "Start")]
        [DataType(DataType.Date)]
        [ValidateStartDate("End")]
        //[ModelBinder(typeof(DateTimeToYearModelBinder))]
        public DateTime Start { get; set; }

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
