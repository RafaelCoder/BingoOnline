using BingOnline.Persistencia.Modelo;
using BingOnline.Persistencia.Repositorios.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BingOnline.Persistencia.Repositorios
{
    public class MongoDBUsuarioRepositorio : IUsuarioRepositorio
    {
        private const string databaseName = "bingo";
        private const string collectionName = "usuarios";

        private readonly IMongoCollection<Usuario> usuariosCollection;
        private readonly FilterDefinitionBuilder<Usuario> filterBuilder = Builders<Usuario>.Filter;
        public MongoDBUsuarioRepositorio(IMongoClient mongoClient)
        {
            IMongoDatabase db = mongoClient.GetDatabase(databaseName);
            usuariosCollection = db.GetCollection<Usuario>(collectionName);
        }
        public async Task Adicionar(Usuario usuario)
        {
            await usuariosCollection.InsertOneAsync(usuario);
        }

        public async Task Atualizar(Usuario usuario)
        {
            var filter = filterBuilder.Eq(usr => usr.Id, usuario.Id);
            await usuariosCollection.ReplaceOneAsync(filter, usuario);
        }

        public async Task Deletar(Usuario usuario)
        {
            var filter = filterBuilder.Eq(usr => usr.Id, usuario.Id);
            await usuariosCollection.DeleteOneAsync(filter);
        }

        public async Task<Usuario> Obter(Guid id)
        {
            var filter = filterBuilder.Eq(usr => usr.Id, id);
            return await usuariosCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<Usuario> ObterPorNome(string nome) {
            var filter = filterBuilder.Eq(usr => usr.Nome, nome);
            return await usuariosCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            return await usuariosCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}
