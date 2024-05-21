using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Nemesys.Models
{
    public class NearMissReport
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Required]
        [Display(Name = "Date of Report")]
        public DateTime DateOfReport { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Date and Time Spotted")]
        public DateTime DateAndTimeSpotted { get; set; }

        [Required]
        [Display(Name = "Type of Hazard")]
        public string TypeOfHazard { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Status")]
        public string? Status { get; set; } // Nullable status property

        [Required]
        [Display(Name = "Reporter Email")]
        public string ReporterEmail { get; set; }

        [Display(Name = "Reporter Phone")]
        public string? ReporterPhone { get; set; } // Nullable phone property

        [Display(Name = "Optional Photo")]
        public string? OptionalPhoto { get; set; } // Nullable photo property

        [Display(Name = "Upvotes")]
        public int Upvotes { get; set; }

        // Foreign Key - navigation property
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        // Nullable role property
        public UserRole? Role { get; set; }

        // Navigation property
        public ICollection<Investigation> Investigations { get; set; }
    }
}
