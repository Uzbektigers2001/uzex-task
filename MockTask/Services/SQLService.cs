using MockTask.DBContext;
using MockTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace MockTask.Services
{
    public class SQLService
    {
        private readonly ApplicationDBContext _dbContext;
        public SQLService(ApplicationDBContext dbContext)
        {
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

        public List<Classes> GetAll(Classes classes) => _dbContext.Classes.Where(x => x.SendCheck != 1).ToList();
        public List<Students> GetAll(Students students) => _dbContext.Students.Where(x => x.SendCheck != 1).ToList();
        public List<Subjects> GetAll(Subjects subjects) => _dbContext.Subjects.Where(x => x.SendCheck != 1).ToList();
        public List<Teachers> GetAll(Teachers teachers) => _dbContext.Teachers.Where(x => x.SendCheck != 1).ToList();

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
