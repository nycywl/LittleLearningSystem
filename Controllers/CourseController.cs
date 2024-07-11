using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LittleLearningSystem.Models;
using System;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using LittleLearningSystem.Models;
using System.Data;

namespace LittleLearningSystem.Controllers
{
    public class CourseController : Controller
    {
        DBManager dbm = new DBManager();  

        public IActionResult Index()
        {
            string email = null;

            if (TempData.ContainsKey("Email"))
            {
                email = TempData.Peek("Email") as string;
            }

            DataTable dt = dbm.GetDBCourse(email);

            ViewData["Course"] = dt;

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            string email = null;

            if (TempData.ContainsKey("Email"))
            {
                email = TempData.Peek("Email") as string;
            }

            dbm.InsertDBCourse(course);

            dbm.InsertDBEnroll(email, course.CourseID);

            return RedirectToAction("Index", "Course");
        }

        public IActionResult Edit(int id)
        {
            DataTable dt = dbm.GetDBCourseByID(id);

            ViewData["CourseByID"] = dt;

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            dbm.EditDBCourse(course);

            return RedirectToAction("Index", "Course");
        }

        public IActionResult Delete(int id)
        {
            string email = null;

            if (TempData.ContainsKey("Email"))
            {
                email = TempData.Peek("Email") as string;
            }

            dbm.DeleteDBCourseByID(id);

            dbm.DeleteDBEnroll(email, id);

            return RedirectToAction("Index", "Course");
        }

        public IActionResult Enroll(int id)
        {
            DataTable dt = dbm.GetDBEnroll(id);

            ViewData["Enroll"] = dt;
            
            return View();
        }
    }
}