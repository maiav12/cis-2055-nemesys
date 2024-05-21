using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nemesys.Models.Contexts;
using Nemesys.Models.Interfaces;
using Nemesys.ViewModels;

namespace Nemesys.Models.Repositories
{
    public class NemesysRepository : INemesysRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly ILogger<NemesysRepository> _logger;

        public NemesysRepository(ApplicationDbContext appDbContext, ILogger<NemesysRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public IEnumerable<NearMissReport> GetAllNearMissReports()
        {
            try
            {
                // Get the current year
                int currentYear = DateTime.Now.Year;

                // Retrieve near miss reports for the current year
                var reportsForCurrentYear = _appDbContext.NearMissReports
                    .Where(r => r.DateOfReport.Year == currentYear)
                    .OrderBy(r => r.DateOfReport)
                    .ToList();

                return reportsForCurrentYear;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
        public IEnumerable<ReporterRanking> GetTopReporters(int year)
        {
            var reporters = _appDbContext.NearMissReports
                                    .Where(r => r.DateOfReport.Year == year)
                                    .GroupBy(r => r.ReporterEmail)
                                    .Select(g => new ReporterRanking
                                    {
                                        ReporterEmail = g.Key,
                                        ReportCount = g.Count()
                                    })
                                    .OrderByDescending(r => r.ReportCount)
                                    .ToList();

            return reporters;
        }
    

    public IEnumerable<ReporterRankingViewModel> GetReporterRankingDataForCurrentYear()
        {
            // Retrieve near miss reports for the current year
            var reportsForCurrentYear = GetAllNearMissReports();

            // Group the reports by reporter email and count the number of reports for each reporter
            var reporterRankingData = reportsForCurrentYear
                .GroupBy(r => r.ReporterEmail)
                .Select(group => new ReporterRankingViewModel
                {
                    ReporterEmail = group.Key,
                    NumberOfReports = group.Count()
                })
                .OrderByDescending(data => data.NumberOfReports)
                .ToList();

            return reporterRankingData;
        }


        public NearMissReport GetNearMissReportById(int nearMissReportId)
        {
            try
            {
                return _appDbContext.NearMissReports
                .FirstOrDefault(r => r.Id == nearMissReportId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public void AddNearMissReport(NearMissReport report)
        {
            try


            {
                _appDbContext.NearMissReports.Add(report);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }



        public void UpdateNearMissReport(NearMissReport nearMissReport)
        {
            try
            {
                var existingReport = _appDbContext.NearMissReports.SingleOrDefault(r => r.Id == nearMissReport.Id);
                if (existingReport != null)
                {
                    existingReport.Title = nearMissReport.Title;
                    existingReport.DateOfReport = nearMissReport.DateOfReport;
                    existingReport.Location = nearMissReport.Location;
                    existingReport.DateAndTimeSpotted = nearMissReport.DateAndTimeSpotted;
                    existingReport.TypeOfHazard = nearMissReport.TypeOfHazard;
                    existingReport.Description = nearMissReport.Description;
                    existingReport.Status = nearMissReport.Status;
                    existingReport.ReporterEmail = nearMissReport.ReporterEmail;
                    existingReport.ReporterPhone = nearMissReport.ReporterPhone;
                    existingReport.OptionalPhoto = nearMissReport.OptionalPhoto;
                    existingReport.Upvotes = nearMissReport.Upvotes;

                    _appDbContext.Entry(existingReport).State = EntityState.Modified;
                    _appDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public void DeleteNearMissReport(int nearMissReportId)
        {
            // Fetch the near miss report and related investigations
            var nearMissReport = _appDbContext.NearMissReports
                                         .Include(n => n.Investigations)
                                         .FirstOrDefault(n => n.Id == nearMissReportId);

            if (nearMissReport == null)
            {
                throw new Exception("NearMissReport not found.");
            }

            // Delete related investigations
            foreach (var investigation in nearMissReport.Investigations)
            {
                _appDbContext.Investigations.Remove(investigation);
            }

            // Delete the near miss report
            _appDbContext.NearMissReports.Remove(nearMissReport);

            // Save changes to the database
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Investigation> GetAllInvestigations()
        {
            try
            {
                return _appDbContext.Investigations.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public Investigation GetInvestigationById(int investigationId)
        {
            try
            {
                return _appDbContext.Investigations.Find(investigationId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public void AddInvestigation(Investigation investigation)
        {
            try
            {
                _appDbContext.Investigations.Add(investigation);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public void UpdateInvestigation(Investigation investigation)
        {
            try
            {
                _appDbContext.Investigations.Update(investigation);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public void DeleteInvestigation(int investigationId)
        {
            try
            {
                var investigation = _appDbContext.Investigations.Find(investigationId);
                if (investigation != null)
                {
                    _appDbContext.Investigations.Remove(investigation);
                    _appDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
     public Investigation GetInvestigationByNearMissReportId(int nearMissReportId)
{
    // Retrieve the investigation details from your data source
    var investigation = _appDbContext.Investigations
        .FirstOrDefault(i => i.NearMissReportId == nearMissReportId);

    if (investigation != null)
    {
        // Map the investigation entity to InvestigationViewModel
        return new Investigation
        {
            NearMissReportId = investigation.NearMissReportId,
            Id = investigation.Id,
            Description = investigation.Description,
            DateOfAction = investigation.DateOfAction,
            InvestigatorEmail = investigation.InvestigatorEmail,
            InvestigatorPhone = investigation.InvestigatorPhone
        };
    }
    else
    {
        // Return null if no investigation found
        return null;
    }
}
    }
}