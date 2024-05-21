using System.ComponentModel.DataAnnotations;

namespace Nemesys.ViewModels
{
    public class ReportDashboardViewModel
    {
        [Display(Name = "Total Reports")]
        public int TotalReports { get; set; }

        [Display(Name = "Total Registered Users")]
        public int TotalRegisteredUsers { get; set; }
        public List<ReporterRankingViewModel> ReporterRankings { get; set; }
    }

    public class ReporterRankingViewModel
    {
        public string ReporterEmail { get; set; }
        public int NumberOfReports { get; set; }
    }
}
    