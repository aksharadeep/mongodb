using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DataAccess
{
    public class NoteDbContext 
    {
        MongoClient mongoClient;
        IMongoDatabase database;

        public NoteDbContext() { }

        public NoteDbContext(IConfiguration configuration)
        {
            mongoClient = new MongoClient(configuration.GetSection("MongoDB:server").Value);
            database = mongoClient.GetDatabase(configuration.GetSection("MongoDB:database").Value);
        }

        public IMongoCollection<Note> notes => database.GetCollection<Note>("Notes");
        public IMongoCollection<Label> labels => database.GetCollection<Label>("Labels");
    }
}
