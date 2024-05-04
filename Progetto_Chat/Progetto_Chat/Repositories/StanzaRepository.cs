using MongoDB.Driver;
using Progetto_Chat.Models;

namespace Progetto_Chat.Repositories
{
    public class StanzaRepository : IRepository<Stanza>
    {
        #region database
        readonly IMongoDatabase database;

        public StanzaRepository(IConfiguration configuration)
        {
            string? connection = configuration.GetValue<string>("MongoDbSettings:Local");
            string? databaseName = configuration.GetValue<string>("MongoDbSettings:Database");

            MongoClient client = new MongoClient(connection);
            database = client.GetDatabase(databaseName);
        }
        #endregion

        #region Implementazione Interfaccia
        public bool DeleteByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Stanza> GetAll()
        {
            throw new NotImplementedException();
        }

        public Stanza GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Stanza t)
        {
            try
            {
                IMongoCollection<Stanza> stanze = database.GetCollection<Stanza>("Stanzas");

                if (stanze.Find(s => s.Titolo == t.Titolo).ToList().Count() > 0)
                {
                    return false;
                }

                stanze.InsertOne(t);
                return true;
            }
            catch { }

            return false;
        }

        public bool Update(Stanza t)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Metodi personalizzati
        public bool DeleteByTitle(string titolo)
        {
            try
            {
                database.GetCollection<Stanza>("Stanzas").DeleteOne(s => s.Titolo == titolo);
                database.GetCollection<Messaggio>("Messaggios").DeleteMany(m => m.StanzaRIFNavigation.Titolo == titolo);
                return true;
            }
            catch { }

            return false;
        }

        public Stanza GetByTitle(string titolo)
        {
            try
            {
                return database.GetCollection<Stanza>("Stanzas").AsQueryable().Single(s => s.Titolo == titolo);
            }
            catch { }

            return new Stanza();
        }

        public bool AddMember(Stanza stanza, Utente utente)
        {
            try
            {
                Stanza temp = GetByTitle(stanza.Titolo);

                var filter = Builders<Stanza>.Filter.Eq(s => s.StanzaID, temp.StanzaID);
                temp.Utenti.Add(utente);
                database.GetCollection<Stanza>("Stanzas").ReplaceOne(filter, temp);
                return true;
            }
            catch { }

            return false;
        }

        public bool RemoveMember(Stanza stanza, Utente utente)
        {
            try
            {
                database.GetCollection<Stanza>("Stanzas").UpdateOne(Builders<Stanza>.Filter.Eq(s => s.StanzaID, GetByTitle(stanza.Titolo).StanzaID), Builders<Stanza>.Update.Pull("utenza", utente));
                return true;
            }
            catch { }

            return false;
        }

        public Stanza GetStanzaFromTitle(string titolo)
        {
            try
            {
                return database.GetCollection<Stanza>("Stanzas").AsQueryable().Single(s => s.Titolo == titolo);
            }
            catch { }

            return new Stanza();
        }

        public bool AddMessageToRoom(Stanza stanza, Messaggio messaggio)
        {
            try
            {
                Stanza temp = GetByTitle(stanza.Titolo);

                var filter = Builders<Stanza>.Filter.Eq(s => s.StanzaID, temp.StanzaID);
                temp.Messaggi.Add(messaggio);
                database.GetCollection<Stanza>("Stanzas").ReplaceOne(filter, temp);
                return true;
            }
            catch { }

            return false;
        }

        public List<Stanza> GetAllOfUser(Utente utente)
        {
            try
            {
                return database.GetCollection<Stanza>("Stanzas").AsQueryable().Where(s => s.Utenti.Contains(utente)).ToList();
            }
            catch { }

            return new List<Stanza>();
        }

        public List<Stanza> GetRoomsWhereAdmin(string nickname)
        {
            try
            {
                return database.GetCollection<Stanza>("Stanzas").AsQueryable().Where(s => s.Amministratore.Nickname == nickname).ToList();
            }
            catch { }

            return new List<Stanza>();
        }

        public List<Stanza> GetRoomsWhereNotAdmin(string nickname)
        {
            try
            {
                List<Stanza> lista = database.GetCollection<Stanza>("Stanzas").AsQueryable().Where(s => s.Amministratore.Nickname != nickname).ToList();
                List<Stanza> temp = new List<Stanza>();
                foreach(Stanza stanza in lista)
                {
                    foreach(Utente utente in stanza.Utenti)
                    {
                        if (utente.Nickname.Equals(nickname))
                        {
                            temp.Add(stanza);
                        }
                    }
                }

                return temp;
            }
            catch { }

            return new List<Stanza>();
        }
        #endregion
    }
}
