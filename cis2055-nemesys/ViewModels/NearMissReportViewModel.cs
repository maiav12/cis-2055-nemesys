using System;
using System.ComponentModel.DataAnnotations;

namespace Nemesys.ViewModels
{
    public class NearMissReportViewModel
    {
        public NearMissReportViewModel()
        {
            DateOfReport = DateTime.Now; //setting date and time to when report is being created
            Status = "Open";
        }
        public int Id { get; set; }
        public string Title { get; set; }

        [Display(Name = "Date of Report")]
        public DateTime DateOfReport { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Date and Time Spotted")]
        public DateTime DateAndTimeSpotted { get; set; }

        [Display(Name = "Type of Hazard")]
        public string TypeOfHazard { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Reporter Email")]
        public string ReporterEmail { get; set; }

        [Display(Name = "Reporter Phone")]
        public string ReporterPhone { get; set; }

        [Display(Name = "Optional Photo")]
        public string OptionalPhoto { get; set; }

        [Display(Name = "Upvotes")]
        public int Upvotes { get; set; }

        public ReporterViewModel Reporter { get; set; }

        public InvestigationViewModel Investigation { get; set; }
    }
}

