using BingOnline.Persistencia.Modelo;
using BingOnline.Persistencia.Repositorios.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BingOnline.Persistencia.Repositorios
{
    public class MongoDBPartidaRepositorio : IPartidaRepositorio
    {
        private const string databaseName = "bingo";
        private const string collectionName = "partidas";

        private readonly IMongoCollection<Partida> partidasCollection;
        private readonly FilterDefinitionBuilder<Partida> filterBuilder = Builders<Partida>.Filter;

        public MongoDBPartidaRepositorio(IMongoClient mongoClient)
        {
            IMongoDatabase db = mongoClient.GetDatabase(databaseName);
            partidasCollection = db.GetCollection<Partida>(collectionName);
        }
        public async Task Adicionar(Partida partida)
        {
            await partidasCollection.InsertOneAsync(partida);
        }

        public async Task Atualizar(Partida partida)
        {
            var filter = filterBuilder.Eq(usr => usr.Id, partida.Id);
            await partidasCollection.ReplaceOneAsync(filter, partida);
        }

        public async Task Deletar(Partida partida)
        {
            var filter = filterBuilder.Eq(prt => prt.Id, partida.Id);
            await partidasCollection.DeleteOneAsync(filter);
        }

        public async Task<Partida> Obter(Guid id)
        {
            var filter = filterBuilder.Eq(prt => prt.Id, id);
            return await partidasCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Partida>> ObterTodos()
        {
            return await partidasCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}
