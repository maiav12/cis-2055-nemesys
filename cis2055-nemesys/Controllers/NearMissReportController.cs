using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Models;
using Nemesys.Data;
using Nemesys.Models.Interfaces;
using Nemesys.ViewModels;
using Nemesys.Models.Repositories;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nemesys.Models.Contexts;

namespace Nemesys.Controllers
{
    public class NearMissReportController : Controller
    {
        private readonly INemesysRepository _nemesysRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<NearMissReportController> _logger;
        private readonly ApplicationDbContext _context;

        


        public NearMissReportController(INemesysRepository nemesysRepository, UserManager<IdentityUser> userManager, ILogger<NearMissReportController> logger, ApplicationDbContext context)
        {
            _nemesysRepository = nemesysRepository;
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string status)
        {
            try
            {
                // Get all reports from the repository
                var allNearMissReports = _nemesysRepository.GetAllNearMissReports();

                // Filter reports based on the status if it's not null or empty
                if (!string.IsNullOrEmpty(status))
                {
                    allNearMissReports = allNearMissReports.Where(r => r.Status != null && r.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
                }

                // Create the view model with the filtered reports
                var model = new NearMissReportListViewModel()
                {
                    TotalEntries = allNearMissReports.Count(),
                    NearMissReports = allNearMissReports
                        .OrderByDescending(b => b.DateOfReport)
                        .Select(b => new NearMissReportViewModel
                        {
                            Id = b.Id,
                            Title = b.Title ?? "",
                            DateOfReport = b.DateOfReport,
                            Location = b.Location ?? "",
                            DateAndTimeSpotted = b.DateAndTimeSpotted,
                            TypeOfHazard = b.TypeOfHazard,
                            Description = b.Description,
                            Status = b.Status,
                            ReporterEmail = b.ReporterEmail,
                            ReporterPhone = b.ReporterPhone,
                            OptionalPhoto = b.OptionalPhoto,
                            Upvotes = b.Upvotes,

                            Investigation = new InvestigationViewModel()
                            {
                                Id = b.Id,
                                Description = "",
                                DateOfAction = DateTime.Now,
                                InvestigatorEmail = "",
                                InvestigatorPhone = ""
                            },

                            Reporter = new ReporterViewModel()
                            {
                                Id = b.UserId,
                                Name = (_userManager.FindByIdAsync(b.UserId).Result != null) ?
                                    _userManager.FindByIdAsync(b.UserId).Result.UserName : "Anonymous"
                            }
                        })
                        .ToList()
                };

                // Populate the status filter options
                //ViewBag.Statuses = new SelectList(new List<string> { "Open", "Closed", "Being Investigated", "No Action Required" });

                // Return the view with the model
                return View(model);
            }
            catch (Exception ex)
            {
                // Log the error and return the error view
                _logger.LogError(ex.Message, ex);
                return View("Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Upvote(int id)
        {
            var report = await _context.NearMissReports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            report.Upvotes += 1;
            _context.Update(report);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id)
        {
            try
            {
                var nearMissReport = _nemesysRepository.GetNearMissReportById(id);
                if (nearMissReport == null)
                    return NotFound();
                else
                {
                    var model = new NearMissReportViewModel()
                    {
                        Id = nearMissReport.Id,
                        Title = nearMissReport.Title,
                        DateOfReport = nearMissReport.DateOfReport,
                        Location = nearMissReport.Location,
                        DateAndTimeSpotted = nearMissReport.DateAndTimeSpotted,
                        TypeOfHazard = nearMissReport.TypeOfHazard,
                        Description = nearMissReport.Description,
                        Status = nearMissReport.Status,
                        ReporterEmail = nearMissReport.ReporterEmail,
                        ReporterPhone = nearMissReport.ReporterPhone,
                        OptionalPhoto = nearMissReport.OptionalPhoto,
                        Upvotes = nearMissReport.Upvotes,
                        Reporter = new ReporterViewModel()
                        {
                            Id = nearMissReport.UserId,
                            Name = (_userManager.FindByIdAsync(nearMissReport.UserId).Result != null) ?
                                _userManager.FindByIdAsync(nearMissReport.UserId).Result.UserName : "Anonymous"
                        }
                    };

                    // Retrieve investigation details
                    var investigation = _nemesysRepository.GetInvestigationByNearMissReportId(id);
                    if (investigation != null)
                    {
                        model.Investigation = new InvestigationViewModel()
                        {
                            Id = investigation.Id,
                            Description = investigation.Description,
                            DateOfAction = investigation.DateOfAction,
                            InvestigatorEmail = investigation.InvestigatorEmail != null ? investigation.InvestigatorEmail : "", // Handle null InvestigatorEmail
                            InvestigatorPhone = investigation.InvestigatorPhone != null ? investigation.InvestigatorPhone : "" , // Handle null InvestigatorPhone
                     
                        };
                    }
                    else
                    {
                        model.Investigation = new InvestigationViewModel()
                        {
                            Id = id, // Set the id of the report
                            Description = "",
                            DateOfAction = DateTime.Now,
                            InvestigatorEmail = "",
                            InvestigatorPhone = ""
                        };
                    }

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View("Error");
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                var model = new EditNearMissReportViewModel();

                // Pass the view model to the view
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return View("Error");
            }
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title, Location, DateAndTimeSpotted, TypeOfHazard, Description, ReporterEmail, ReporterPhone, OptionalPhoto")] EditNearMissReportViewModel newNearMissReport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string fileName = "";
                    if (newNearMissReport.OptionalPhoto != null && newNearMissReport.OptionalPhoto.Length > 0)
                    {
                        var extension = Path.GetExtension(newNearMissReport.OptionalPhoto.FileName);
                        fileName = Guid.NewGuid().ToString() + extension;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "nearmissreports", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await newNearMissReport.OptionalPhoto.CopyToAsync(stream);
                        }
                    }

                    NearMissReport nearMissReport = new NearMissReport()
                    {
                        Title = newNearMissReport.Title,
                        DateOfReport = DateTime.Now, // Set the current date and time
                        Location = newNearMissReport.Location,
                        DateAndTimeSpotted = newNearMissReport.DateAndTimeSpotted,
                        TypeOfHazard = newNearMissReport.TypeOfHazard,
                        Description = newNearMissReport.Description,
                        ReporterEmail = newNearMissReport.ReporterEmail,
                        ReporterPhone = newNearMissReport.ReporterPhone,
                        OptionalPhoto = fileName, // Assign the file name here
                        Upvotes = 0, // Initialize upvotes to 0
                        UserId = _userManager.GetUserId(User)
                    };

                    // Persist to the repository
                    _nemesysRepository.AddNearMissReport(nearMissReport);
                    await _nemesysRepository.SaveAsync(); // Ensure to save changes asynchronously
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(newNearMissReport);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return View("Error");
            }
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteNearMissReport(int nearMissReportId)
        {
            _logger.LogInformation("Attempting to delete NearMissReport with ID: {NearMissReportId}", nearMissReportId);

            try
            {
                var nearMissReport = _nemesysRepository.GetNearMissReportById(nearMissReportId);
                if (nearMissReport == null)
                {
                    _logger.LogWarning("NearMissReport with ID: {NearMissReportId} not found.", nearMissReportId);
                    return NotFound();
                }

                var currentUserId = _userManager.GetUserId(User);
                if (nearMissReport.UserId != currentUserId)
                {
                    _logger.LogWarning("User ID: {UserId} is not authorized to delete NearMissReport with ID: {NearMissReportId}", currentUserId, nearMissReportId);
                    return Forbid();
                }

                if (!string.IsNullOrEmpty(nearMissReport.OptionalPhoto))
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "nearmissreports", nearMissReport.OptionalPhoto);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                        _logger.LogInformation("Deleted image file: {ImagePath}", imagePath);
                    }
                    else
                    {
                        _logger.LogWarning("Image file not found: {ImagePath}", imagePath);
                    }
                }

                _nemesysRepository.DeleteNearMissReport(nearMissReportId);
                _logger.LogInformation("Deleted NearMissReport with ID: {NearMissReportId}", nearMissReportId);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting NearMissReport with ID: {NearMissReportId}", nearMissReportId);
                return View("Error");
            }
        }



        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var existingNearMissReport = _nemesysRepository.GetNearMissReportById(id);
                if (existingNearMissReport != null)
                {
                    var currentUserId = _userManager.GetUserId(User);
                    if (existingNearMissReport.UserId == currentUserId || User.IsInRole("Admin"))
                        
                    {
                        var model = new EditNearMissReportViewModel()
                        {
                            Id = existingNearMissReport.Id,
                            DateOfReport = existingNearMissReport.DateOfReport,
                            Location = existingNearMissReport.Location,
                            DateAndTimeSpotted = existingNearMissReport.DateAndTimeSpotted,
                            TypeOfHazard = existingNearMissReport.TypeOfHazard,
                            Description = existingNearMissReport.Description,
                            ReporterEmail = existingNearMissReport.ReporterEmail,
                            ReporterPhone = existingNearMissReport.ReporterPhone,
                            Upvotes = existingNearMissReport.Upvotes
                        };

                        // If the user is an admin, allow modification of report status
                        if (User.IsInRole("Admin"))
                        {
                            // Load all report status options
                            var statusOptions = Enum.GetValues(typeof(ReportStatus)).Cast<ReportStatus>().ToList();
                            model.StatusOptions = statusOptions;
                        }

                        return View(model);
                    }
                    else
                    {
                        return Forbid(); // or redirect to an error page or to the Index page
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return View("Error");
            }
        }


        [HttpPost]
        [Authorize]
        public IActionResult Edit([FromRoute] int id, EditNearMissReportViewModel updatedNearMissReport)
        {
            try
            {
                var modelToUpdate = _nemesysRepository.GetNearMissReportById(id);
                if (modelToUpdate == null)
                {
                    return NotFound();
                }
                var currentUserId = _userManager.GetUserId(User);
                if (modelToUpdate.UserId == currentUserId)
                {
                    if (ModelState.IsValid)
                    {
                        string optionalPhoto = "";
                        // Check if a new photo is uploaded
                        if (updatedNearMissReport.OptionalPhoto != null)
                        {
                            string fileName = "";
                            // Process the uploaded photo and update the model
                            var extension = "." + updatedNearMissReport.OptionalPhoto.FileName.Split('.')[updatedNearMissReport.OptionalPhoto.FileName.Split('.').Length - 1];
                            fileName = Guid.NewGuid().ToString() + extension;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "nearmissreports", fileName);
                            using (var bits = new FileStream(path, FileMode.Create))
                            {
                                updatedNearMissReport.OptionalPhoto.CopyTo(bits);
                            }
                            modelToUpdate.OptionalPhoto = "/images/nearmissreports/" + fileName;
                        }
                        if (User.IsInRole("Admin"))
                        {
                            // Set the status to the value selected by the admin
                            modelToUpdate.Status = updatedNearMissReport.SelectedStatus.ToString();
                        }
                        else

                            modelToUpdate.OptionalPhoto = optionalPhoto;

                        // Update other properties of the model
                        modelToUpdate.Title = updatedNearMissReport.Title;
                        modelToUpdate.DateOfReport = updatedNearMissReport.DateOfReport;
                        modelToUpdate.Location = updatedNearMissReport.Location;
                        modelToUpdate.DateAndTimeSpotted = updatedNearMissReport.DateAndTimeSpotted;
                        modelToUpdate.TypeOfHazard = updatedNearMissReport.TypeOfHazard;
                        modelToUpdate.Description = updatedNearMissReport.Description;

                        modelToUpdate.ReporterEmail = updatedNearMissReport.ReporterEmail;
                        modelToUpdate.ReporterPhone = updatedNearMissReport.ReporterPhone;
                        modelToUpdate.Upvotes = updatedNearMissReport.Upvotes;
                        modelToUpdate.UserId = _userManager.GetUserId(User);
                        _nemesysRepository.UpdateNearMissReport(modelToUpdate);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(updatedNearMissReport);
                    }
                }
                else return Forbid();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return View("Error");
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateInvestigation(int id)
        {
            var model = new InvestigationViewModel();
            // Optionally, you can pass the ID of the near miss report to the view model if needed
            model.NearMissReportId = id;
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateInvestigation(InvestigationViewModel model)
        {
            try
            {
                // Validate model state
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Map view model to entity
                var investigation = new Investigation
                {
                    Description = model.Description,
                    DateOfAction = model.DateOfAction,
                    InvestigatorEmail = model.InvestigatorEmail,
                    InvestigatorPhone = model.InvestigatorPhone,
                    NearMissReportId = model.NearMissReportId,
                 
                    Role = model.Role ?? UserRole.User // Handle null value
                };

                // Add investigation to repository
                _nemesysRepository.AddInvestigation(investigation);

                return RedirectToAction("Details", new { id = model.NearMissReportId }); // Redirect to the near miss report details
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                // Log inner exception details
                if (ex.InnerException != null)
                {
                    _logger.LogError("Inner Exception: " + ex.InnerException.Message, ex.InnerException);
                }

                return StatusCode(500, "An error occurred while creating the investigation."); // Return error status
            }
        }


        [Authorize(Roles = "Admin")]
        public IActionResult UpdateStatus(int reportId, string status)
        {
            try
            {
                // Get the near miss report from repository
                var nearMissReport = _nemesysRepository.GetNearMissReportById(reportId);
                if (nearMissReport == null)
                {
                    return NotFound(); // Return not found status if report not found
                }

                // Update the status
                nearMissReport.Status = status;

                // Save changes
                _nemesysRepository.UpdateNearMissReport(nearMissReport);

                return RedirectToAction("Details", new { id = reportId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, "An error occurred while updating the report status."); // Return error status
            }
        }


    }
}