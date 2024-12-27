using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentDataEF.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataEF.Controllers
{
    public class HomeController : Controller
    {
        private readonly SqldbContext _context;

        public HomeController(SqldbContext context)
        {
            _context = context;
        }

        // GET: Dropdown with students
        public async Task<IActionResult> Index()
        {
            // Retrieve students for the dropdown
            var students = await _context.Students.ToListAsync();
            ViewBag.StudentList = new SelectList(students, "Id", "Name"); // Binding to dropdown
            return View();
        }

        // POST: Display details of selected student
        [HttpPost]
        public async Task<IActionResult> Index(int selectedStudentId)
        {
            // Retrieve students for the dropdown
            var students = await _context.Students.ToListAsync();
            ViewBag.StudentList = new SelectList(students, "Id", "Name");

            // Retrieve the selected student's details
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == selectedStudentId);
            if (student == null)
            {
                ViewBag.ErrorMessage = "Student not found!";
                return View();
            }

            return View(student); // Pass the selected student's details to the view
        }
    }
}
