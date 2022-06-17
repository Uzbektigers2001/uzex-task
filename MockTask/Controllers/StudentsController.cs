using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MockTask.DBContext;
using MockTask.Models;
using MockTask.Services;

namespace MockTask.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly MongoService _mongoservice;
        public StudentsController(ApplicationDBContext context, MongoService mongoService)
        {
            _context = context;
            _mongoservice = mongoService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {

            var res = _context.Students.Where(x => x.Id != 1).ToList();

            _mongoservice.Insert(res);

            return View(await _context.Students.ToListAsync());
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
                return View(students); //RedirectToAction(nameof(Index));
            }
            return View(students);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

    }
}
