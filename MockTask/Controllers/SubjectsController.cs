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
    public class SubjectsController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly SQLService _sqlService;

        public SubjectsController(ApplicationDBContext context,SQLService sqlService)
        {
            _sqlService = sqlService;
            _context = context;
        }


        public IActionResult Index()
        {
            return View(_sqlService.GetAll(new Subjects()));
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
