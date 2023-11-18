using HotChocolate.Types;

// Modèle pour le type Dossier
using DossierAPI.Models;
 

public class DossierType : ObjectType<Dossier>
{
    protected override void Configure(IObjectTypeDescriptor<Dossier> descriptor)
    {
        descriptor.Field(d => d.DossierId).Type<IdType>();
        descriptor.Field(d => d.TypeVoyageId).Type<IdType>();
        descriptor.Field(d => d.DateArrivee).Type<DateType>();
        descriptor.Field(d => d.DureeSejourJours).Type<IntType>();
        descriptor.Field(d => d.NumeroVol).Type<StringType>();
        descriptor.Field(d => d.Lieu).Type<StringType>();
        // ... Définissez d'autres champs
    }
}

// Modèle pour le type TypeVoyage
public class TypeVoyageType : ObjectType<TypeVoyage>
{
    protected override void Configure(IObjectTypeDescriptor<TypeVoyage> descriptor)
    {
        descriptor.Field(t => t.TypeVoyageId).Type<IdType>();
        descriptor.Field(t => t.Libelle).Type<StringType>();
        // ... Définissez d'autres champs
    }
}
