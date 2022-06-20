using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MockTask.DBContext;
using MockTask.Models;

namespace MockTask.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public SubjectsController(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Subjects.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Subjects subjects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjects);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(subjects);
        }

    }
}
