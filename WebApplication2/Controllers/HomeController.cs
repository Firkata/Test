using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected ApplicationDbContext mContext;
        protected UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            mContext = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var model = new PlaneDataModel();
            //model.Id = Guid.NewGuid().ToString();
            //model.Company = "FlyAir";
            //model.PassangerCount = 300;

            //mContext.Planes.Add(model);
            //mContext.SaveChanges();

            return View();
        }

        [Authorize(Roles = "Admin, Administration")]
        public async Task<IActionResult> Privacy()
        {
           var data =  mContext.Planes.Where(s => s.PassangerCount == 300).ToList();
           var user = await _userManager.FindByNameAsync("firkata2@gmail.com");
           var roles = await _userManager.GetRolesAsync(user);
           ViewBag.Data = data;
           ViewBag.UserName = user.UserName;
            ViewBag.UserRole = roles[0];

           return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
