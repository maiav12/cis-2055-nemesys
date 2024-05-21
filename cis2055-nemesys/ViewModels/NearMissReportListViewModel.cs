using System.Collections.Generic;
using Nemesys.Models;

namespace Nemesys.ViewModels
{
    public class NearMissReportListViewModel
    {
     
        public List<NearMissReport> FilteredNearMissReports { get; set; }
        public IEnumerable<NearMissReportViewModel> NearMissReports { get; set; }
        public int TotalEntries { get; set; }
    }
}