using GymManagement.BLL.Interfaces;
using GymManagement.BLL.ViewModels.Analytics;
using GymManagement.PL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GymManagement.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnalyticsService analyticsService;

        public HomeController(IAnalyticsService _analyticsService)
        {
            analyticsService = _analyticsService;
        }

        public IActionResult Index()
        {
            AnalyticsViewModel model = analyticsService.GetAnalytics();

            return View(model);
        }
    }
}
