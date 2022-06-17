using Microsoft.Extensions.Options;
using MockTask.DBContext;
using MockTask.Models;
using MongoDB.Driver;

namespace MockTask.Services
{
    public class HomeServices
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly SQLService _sqlService;
        private readonly MongoService _mongoService;

        private readonly IMongoCollection<Students> _studentMongo;
        private readonly IMongoCollection<Subjects> _subjectMongo;
        private readonly IMongoCollection<Teachers> _teacherMongo;
        private readonly IMongoCollection<Classes> _classMongo;
        public HomeServices(ApplicationDBContext dbcontext, IOptions<DatabaseSettings> _databaseSettingsModel,
                            SQLService sqlService, MongoService mongoService)
        {
            _dbContext = dbcontext;
            _sqlService = sqlService;
            _mongoService = mongoService;

            var mongoClient = new MongoClient(_databaseSettingsModel.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_databaseSettingsModel.Value.DatabaseName);
            _studentMongo = mongoDatabase.GetCollection<Students>(_databaseSettingsModel.Value.CollectionNames[0]);
            _subjectMongo = mongoDatabase.GetCollection<Subjects>(_databaseSettingsModel.Value.CollectionNames[1]);
            _teacherMongo = mongoDatabase.GetCollection<Teachers>(_databaseSettingsModel.Value.CollectionNames[2]);
            _classMongo = mongoDatabase.GetCollection<Classes>(_databaseSettingsModel.Value.CollectionNames[3]);
        }

        
        public ViewModel Worker()
        {
            ViewModel model = new ViewModel();
            model.sudentsCount = _sqlService.GetAll(new Students()).Count;
            model.subjectsCount = _sqlService.GetAll(new Subjects()).Count;
            model.classesCount = _sqlService.GetAll(new Classes()).Count;
            model.teachersCount = _sqlService.GetAll(new Teachers()).Count;
            return model;
        }

    }
}
