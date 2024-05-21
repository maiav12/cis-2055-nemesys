using Nemesys.Models;
using System;
using System.ComponentModel.DataAnnotations;


namespace Nemesys.ViewModels
{
    public class InvestigationViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateOfAction { get; set; }

        [Required]
        public string InvestigatorEmail { get; set; }

        public string InvestigatorPhone { get; set; }

        [Required]
        public int NearMissReportId { get; set; }

     
        public UserRole? Role { get; set; }
    }
}