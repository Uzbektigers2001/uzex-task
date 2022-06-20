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
    public class ClassesController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly SQLService _sqlService;

        public ClassesController(ApplicationDBContext context, SQLService sqlService)
        {
            _sqlService = sqlService;
            _context = context;
            
        }

        public IActionResult Index()
        {
            return View(_sqlService.GetAll(new Classes()));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Classes classes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classes);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(classes);
        }


        private bool ClassesExists(int id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}
