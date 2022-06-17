using Microsoft.Extensions.Options;
using MockTask.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MockTask.Services
{
    public class MongoService
    {
        private readonly IMongoCollection<Students> _studentMongo;
        private readonly IMongoCollection<Subjects> _subjectMongo;
        private readonly IMongoCollection<Teachers> _teacherMongo;
        private readonly IMongoCollection<Classes> _classMongo;

        public MongoService(IOptions<DatabaseSettings> _databaseSettingsModel)
        {
            var mongoClient = new MongoClient(_databaseSettingsModel.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_databaseSettingsModel.Value.DatabaseName);
            _studentMongo = mongoDatabase.GetCollection<Students>(_databaseSettingsModel.Value.CollectionNames[0]);
            _subjectMongo = mongoDatabase.GetCollection<Subjects>(_databaseSettingsModel.Value.CollectionNames[1]);
            _teacherMongo = mongoDatabase.GetCollection<Teachers>(_databaseSettingsModel.Value.CollectionNames[2]);
            _classMongo = mongoDatabase.GetCollection<Classes>(_databaseSettingsModel.Value.CollectionNames[3]);

        }

        public void Insert(List<Students> students) => _studentMongo.InsertMany(students);
        public void Insert(List<Subjects> subjects) => _subjectMongo.InsertMany(subjects);
        public void Insert(List<Teachers> teachers) => _teacherMongo.InsertMany(teachers);
        public void Insert(List<Classes> classes) => _classMongo.InsertMany(classes);

    }
}
