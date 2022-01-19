using MongoDB.Driver;
using BingOnline.Settings;
using BingOnline.Persistencia.Repositorios.Interfaces;
using BingOnline.Persistencia.Repositorios;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

builder.Services.AddSingleton<IMongoClient>(serviceProvider => {
    var settings = builder.Configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddSingleton<IUsuarioRepositorio, MongoDBUsuarioRepositorio>();
builder.Services.AddSingleton<IPartidaRepositorio, MongoDBPartidaRepositorio>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers(options => { 
    options.SuppressAsyncSuffixInActionNames = false; //Gambita pra aceitar o Async como sufixo dos metodos em runtime
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
