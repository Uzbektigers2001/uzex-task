using MockTask.DBContext;
using MockTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace MockTask.Services
{
    public class SQLService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly MongoService _mongoService;
        public SQLService(ApplicationDBContext dbContext,MongoService mongoService)
        {
            _mongoService = mongoService;
            _dbContext = dbContext;
        }

        public ViewModel Worker()
        {
            ViewModel model = new ViewModel();

            model.sudentsCount = GetAll(new Students()).Count;
            model.subjectsCount = GetAll(new Subjects()).Count;
            model.classesCount = GetAll(new Classes()).Count;
            model.teachersCount = GetAll(new Teachers()).Count;
            return model;
        }


        public void UpdateAll()
        {
            var students = GetAll(new Students());
            var classes = GetAll(new Classes());
            var subjects = GetAll(new Subjects());
            var teachers = GetAll(new Teachers());

            if (students.Any()) _mongoService.Insert(students);
            if (classes.Any()) _mongoService.Insert(classes);
            if (subjects.Any()) _mongoService.Insert(subjects);
            if (teachers.Any()) _mongoService.Insert(teachers);

            Update(students);
            Update(classes);
            Update(subjects);
            Update(teachers);

        }

        public List<Classes> GetAll(Classes classes) => _dbContext.Classes.Where(x => x.SendCheck != 1).Any() ?
            _dbContext.Classes.Where(x => x.SendCheck != 1).ToList() : new List<Classes>();

        public List<Students> GetAll(Students students) => _dbContext.Students.Where(x => x.SendCheck != 1).Any() ? _dbContext.Students.Where(x => x.SendCheck != 1).ToList() : new List<Students>();

        public List<Subjects> GetAll(Subjects subjects) => _dbContext.Subjects.Where(x => x.SendCheck != 1).Any() ? _dbContext.Subjects.Where(x => x.SendCheck != 1).ToList() : new List<Subjects>();

        public List<Teachers> GetAll(Teachers teachers) => _dbContext.Teachers.Where(x => x.SendCheck != 1).Any() ? _dbContext.Teachers.Where(x => x.SendCheck != 1).ToList() : new List<Teachers>();

        public void Update(List<Classes> classes)
        {
            foreach (var @class in classes)
            _dbContext.Classes.FirstOrDefault(x => x.Id == @class.Id).SendCheck = 1;
            _dbContext.SaveChanges();
        }
        public void Update(List<Students> students)
        {
            foreach (var student in students)
                _dbContext.Students.FirstOrDefault(x => x.Id == student.Id).SendCheck = 1;
            _dbContext.SaveChanges();
        }
        public void Update(List<Subjects> subjects)
        {
            foreach (var subject in subjects)
                _dbContext.Subjects.FirstOrDefault(x => x.Id == subject.Id).SendCheck = 1;
            _dbContext.SaveChanges();
        }
        public void Update(List<Teachers> teachers)
        {
            foreach (var teacher in teachers)
                _dbContext.Teachers.FirstOrDefault(x => x.Id == teacher.Id).SendCheck = 1;
            _dbContext.SaveChanges();
        }
    }
    
}
