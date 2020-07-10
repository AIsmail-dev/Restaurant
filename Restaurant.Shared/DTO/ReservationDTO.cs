using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Restaurant.Shared
{
    public class ReservationDTO
    {
        [Display(Name = "Reservation Id")]
        public int ReservationId { get; set; }

        [Required]
        [Display(Name = "Guest Number")]
        public long GuestNumber { get; set; }

        [Required]
        [Display(Name = "Reservation Date")]
        [ModelBinder(BinderType = typeof(DateTimeModelBinder))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReservationDate { get; set; }

        [Required]
        [Display(Name = "Menu Type")]
        public int MenuTypeId { get; set; }

        [StringLength(300)]
        [Display(Name = "Notes")]
        public string Notes { get; set; }
    }
}
