using ClientAPI.Models;
using HotChocolate.Types;
 

// Modèle pour le type Client
public class ClientType : ObjectType<Client>
{
    protected override void Configure(IObjectTypeDescriptor<Client> descriptor)
    {
        descriptor.Field(c => c.ClientId).Type<IdType>();
        descriptor.Field(c => c.Nom).Type<StringType>();
        descriptor.Field(c => c.Prenom).Type<StringType>();
        descriptor.Field(c => c.Adresse).Type<StringType>();
        descriptor.Field(c => c.DateDeNaissance).Type<DateType>();
        // ... Définissez d'autres champs comme celui-ci
    }


    public async Task<List<Client>> GetClientListAsync([Service] IClientService clientService)
    {
        return await clientService.ClientListAsync();
    }

}

