using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BingOnline.Persistencia.Modelo
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {
            Id = Guid.NewGuid();
            Nome = "";
            Email = "";
            Senha = "";
        }
    }
}
