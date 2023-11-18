using Core.Data;
using GraphqlAPI.GraphqlQueries;
using GraphqlAPI.GraphqlTypes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPooledDbContextFactory<TDbContext>(o => o.UseSqlite("TravalDb"));

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddQueryType<ClientType>()
     .AddQueryType<DossierType>()
      .AddQueryType<TypeVoyageType>()
       .AddQueryType<HotelType>()
       .AddQueryType<ClientService>()
    ;

//Register Service

//InMemory Database

//GraphQL Config
builder.Services.AddGraphQLServer();

var app = builder.Build();

//GraphQL
app.MapGraphQL();

//app.UseHttpsRedirection();

app.Run();