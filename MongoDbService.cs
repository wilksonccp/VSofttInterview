using MongoDB.Driver;
using MongoDbCrudDemo.Models;

namespace MongoDbCrudDemo.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<User> _usersCollection;

        public MongoDbService()
        {
            var conectionString = "mongodb+srv://wilksoncc:NMwcfybp2lGUFLaS@cluster0.z6umbgr.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            var databaseName = "UserDatabase";
            var collectionName = "Users";

            var mongoClient = new MongoClient(conectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);

            _usersCollection = mongoDatabase.GetCollection<User>(collectionName);
        }

        //CRATE
        public async Task CreateUserAsync(User user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        //READ ALL
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _usersCollection.Find(_ => true).ToListAsync();
        }

        //READ BY ID
        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _usersCollection.Find(user => user.Id == id).FirstOrDefaultAsync();
        }

        //UPDATE
        public async Task UpdateUserAsync(string id, User user)
        {
            await _usersCollection.ReplaceOneAsync(u => u.Id == id, user);
        }

        //DELETE
        public async Task DeleteUserAsync(string id)
        {
            await _usersCollection.DeleteOneAsync(user => user.Id == id);
        }
    }
}
