using Nemesys.ViewModels;
using System.Collections.Generic;

namespace Nemesys.Models.Interfaces
{
    public interface INemesysRepository
    {
        IEnumerable<NearMissReport> GetAllNearMissReports();
      
        NearMissReport GetNearMissReportById(int nearMissReportId);
        Task SaveAsync();
        IEnumerable<ReporterRanking> GetTopReporters(int year);
        void AddNearMissReport(NearMissReport report);
        void UpdateNearMissReport(NearMissReport report);
        void DeleteNearMissReport(int nearMissReportId);


        IEnumerable<Investigation> GetAllInvestigations();
        Investigation GetInvestigationById(int investigationId);

        void AddInvestigation(Investigation investigation);
        void UpdateInvestigation(Investigation investigation);
        void DeleteInvestigation(int investigationId);
        Investigation GetInvestigationByNearMissReportId(int nearMissReportId);
    
    // Method to retrieve reporter ranking data for the current year
    IEnumerable<ReporterRankingViewModel> GetReporterRankingDataForCurrentYear();


    }
}