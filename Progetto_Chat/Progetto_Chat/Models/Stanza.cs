using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Progetto_Chat.Models
{
    public class Stanza
    {
        [BsonId]
        public ObjectId StanzaID { get; set; }

        [BsonElement("nom")]
        public string Titolo { get; set; } = null!;

        [BsonElement("desc")]
        public string? Descrizione { get; set; }

        [BsonElement("adminRIF")]
        public int AmministratoreRIF { get; set; }

        public Utente Amministratore { get; set; } = null!;

        [BsonElement("utenza")]
        public ICollection<Utente> Utenti { get; set; } = new List<Utente>();

        [BsonElement("messaggistica")]
        public ICollection<Messaggio> Messaggi { get; set; } = new List<Messaggio>();
    }
}
