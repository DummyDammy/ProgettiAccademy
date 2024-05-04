using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Progetto_Chat.Models
{
    public class Messaggio
    {
        [BsonId]
        public ObjectId MessaggioID { get; set; }

        [BsonElement("dataInvio")]
        public DateTime DataInvio { get; set; } = DateTime.Now;

        [BsonElement("utenteID")]
        public int UtenteRIF { get; set; }

        [BsonElement("utenteMittente")]
        public Utente Mittente { get; set; } = null!;

        [BsonElement("stanzaID")]
        public ObjectId StanzaRIF { get; set; }

        [BsonElement("stanza")]
        public Stanza StanzaRIFNavigation { get; set; } = null!;

        [BsonElement("text")]
        public string Testo { get; set; } = null!;
    }
}
