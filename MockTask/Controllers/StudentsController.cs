using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockTask.DBContext;
using MockTask.Models;
using MockTask.Services;

namespace MockTask.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly MongoService _mongoservice;
        private readonly SQLService _sqlService;
        public StudentsController(ApplicationDBContext context, MongoService mongoService,SQLService sqlService)
        {
            _context = context;
            _sqlService = sqlService;
            _mongoservice = mongoService;
        }

        // GET: Students
        public IActionResult Index()
        {
            return View(_sqlService.GetAll(new Students()));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Students students)
        {
            if (ModelState.IsValid)
            {
                _context.Add(students);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(students);
        }

    }
}
