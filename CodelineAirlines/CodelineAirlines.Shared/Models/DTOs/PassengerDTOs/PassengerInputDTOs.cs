﻿using System.ComponentModel.DataAnnotations;

namespace CodelineAirlines.Shared.Models.DTOs.PassengerDTOs
{
    public class PassengerInputDTOs
    {
        [Required]
        [StringLength(50)]
        public string PassengerName { get; set; }

        [Required(ErrorMessage = "Passport number is required")]
        [StringLength(30)]
        public string Passport { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Passenger date of birth is required")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "Nationality is required")]
        [StringLength(20)]
        public string Nationality { get; set; }

    }
}
