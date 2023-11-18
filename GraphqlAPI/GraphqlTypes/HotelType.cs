using HotChocolate.Types;

// Modèle pour le type Dossier
using ProduitAPI.Models;

// Modèle pour le type Hotel
public class HotelType : ObjectType<Hotel>
{
    protected override void Configure(IObjectTypeDescriptor<Hotel> descriptor)
    {
        descriptor.Field(h => h.ProduitId).Type<IdType>();
        descriptor.Field(h => h.Nom).Type<StringType>();
        descriptor.Field(h => h.Description).Type<StringType>();
        descriptor.Field(h => h.Prix).Type<DecimalType>();
        descriptor.Field(h => h.Fabricant).Type<StringType>();
        descriptor.Field(h => h.NombreEtoiles).Type<IntType>();
        descriptor.Field(h => h.Ville).Type<StringType>();
        descriptor.Field(h => h.Pays).Type<StringType>();
        descriptor.Field(h => h.Adresse).Type<StringType>();
        // ... Définissez d'autres champs pour l'HotelType
    }
}