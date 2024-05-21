using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nemesys.Models.Interfaces;
using Nemesys.ViewModels;
namespace Nemesys.Controllers
{

    public class HomeController : Controller
    {
        private readonly INemesysRepository _nemesysRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        public HomeController(INemesysRepository nemesysRepository, UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _nemesysRepository = nemesysRepository;
            _userManager = userManager;
            _logger = logger;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult HallOfFame()
        {
            int currentYear = DateTime.Now.Year;
            var topReporters = _nemesysRepository.GetTopReporters(currentYear);
            return View(topReporters);
        }
        [HttpGet]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Client)]

        [Authorize(Roles = "Admin")]
        public IActionResult Dashboard()
        {
            try
            {
                var model = new ReportDashboardViewModel();
                model.TotalRegisteredUsers = _userManager.Users.Count();
                model.TotalReports = _nemesysRepository.GetAllNearMissReports().Count();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View("Error");
            }
        }


        public IActionResult Index()
        {
            //Load data from the Model
            ViewBag.Title = "Nemesys - Home";
            ViewBag.Message = "Hello there, this is the time: " + DateTime.Now;
            return View();
        }

        public class ModelBindingTest
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


        public IActionResult About(ModelBindingTest test)
        {
            try
            {
                //Load data from the Model
            ViewBag.Title = "Nemesys - About";
            ViewBag.Message = "Hello there, this is the about page. The model binder found - " + test.Name + " - " + test.Id;
                return View(); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return View("Error");
            }
        }
    }
}
