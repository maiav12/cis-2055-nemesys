using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nemesys.ViewModels
{
    public enum ReportStatus
    {
        Open,
        BeingInvestigated,
        Closed,
        NoActionRequired
    }

    public class EditNearMissReportViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Display(Name = "Date of Report")]
        public DateTime DateOfReport { get; set; }

        [Required(ErrorMessage = "The Location field is required.")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "The Date and Time Spotted field is required.")]
        [Display(Name = "Date and Time Spotted")]
        public DateTime DateAndTimeSpotted { get; set; }

        [Required(ErrorMessage = "The Type of Hazard field is required.")]
        [Display(Name = "Type of Hazard")]
        public string TypeOfHazard { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Reporter Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Reporter Email")]
        public string ReporterEmail { get; set; }

        [Display(Name = "Reporter Phone")]
        public string ReporterPhone { get; set; }

        [Display(Name = "Optional Photo")]
        public IFormFile? OptionalPhoto { get; set; }

        [Display(Name = "Upvotes")]
        public int Upvotes { get; set; }

        // Add property for report status options
        [Display(Name = "Report Status")]
        public ReportStatus SelectedStatus { get; set; }
        
        // List to store investigation details
       
        public List<ReportStatus> StatusOptions { get; set; } = Enum.GetValues(typeof(ReportStatus)).Cast<ReportStatus>().ToList();
    }
}
