﻿using System;
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
    public class TeachersController : Controller
    {
        private readonly ApplicationDBContext _context;

        public TeachersController(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Teachers.ToListAsync());
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
