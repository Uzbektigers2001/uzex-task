using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MockTask.DBContext;
using MockTask.Models;
using MockTask.Services;
using MongoDB.Driver;

namespace MockTask.Controllers
{

    public class HomeController : Controller
    {

        private readonly ApplicationDBContext _dbContext;
        private readonly SQLService _sqlService;
        private readonly MongoService _mongoService;
        public HomeController(ApplicationDBContext dbcontext, SQLService sqlService, MongoService mongoService)
        {
            _dbContext = dbcontext;
            _sqlService = sqlService;
            _mongoService = mongoService;

        }

        public IActionResult Index()
        {
            return View(_sqlService.Worker());
        }

        [HttpPost]
        public IActionResult Index(ViewModel model)
        {

            return View(model);
        }
    }
}
