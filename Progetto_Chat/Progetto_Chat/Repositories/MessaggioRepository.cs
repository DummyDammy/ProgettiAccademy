using MongoDB.Driver;
using Progetto_Chat.Models;

namespace Progetto_Chat.Repositories
{
    public class MessaggioRepository : IRepository<Messaggio>
    {
        #region database
        readonly IMongoDatabase database;

        public MessaggioRepository(IConfiguration configuration)
        {
            string? connection = configuration.GetValue<string>("MongoDbSettings:Local");
            string? databaseName = configuration.GetValue<string>("MongoDbSettings:Database");

            MongoClient client = new MongoClient(connection);
            database = client.GetDatabase(databaseName);
        }
        #endregion

        #region Implementazione interfaccia
        public bool DeleteByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Messaggio> GetAll()
        {
            throw new NotImplementedException();
        }

        public Messaggio GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Messaggio t)
        {
            try
            {
                IMongoCollection<Messaggio> messaggi = database.GetCollection<Messaggio>("Messaggios");

                messaggi.InsertOne(t);
                return true;
            }
            catch { }

            return false;
        }

        public bool Update(Messaggio t)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
