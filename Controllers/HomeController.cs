using LittleLearningSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data;

namespace LittleLearningSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            TempData["Email"] = email;
            
            DBManager dbm = new DBManager();

            DataTable dt = dbm.GetDBStudent();

            foreach (DataRow dr in dt.Rows) 
            {
                if (email == dr["Email"].ToString().Trim() && password == dr["Spassword"].ToString().Trim())
                {
                    return RedirectToAction("Index", "Course");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View();
        }

		public IActionResult Logout()
		{
			return View();
		}
    }
}