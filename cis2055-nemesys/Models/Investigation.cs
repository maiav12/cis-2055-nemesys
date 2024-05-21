using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nemesys.Models
{
    public enum UserRole
    {
        Admin,
        User
    }

    public class Investigation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public NearMissReport NearMissReport { get; set; }

       

        public UserRole? Role { get; set; }
    }
}
