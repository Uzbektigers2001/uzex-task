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
    public class TeachersController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly SQLService _sqlService;

        public TeachersController(ApplicationDBContext context, SQLService sqlService)
        {
            _context = context;
            _sqlService = sqlService;
        }


        public IActionResult Index()
        {
            return View(_sqlService.GetAll(new Teachers()));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Patronymic,Age,Gender")] Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teachers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teachers);
        }

    }
}
