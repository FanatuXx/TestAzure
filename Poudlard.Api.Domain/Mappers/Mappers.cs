using Poudlard.Api.Domain.Entities;
using System.Data;

namespace Poudlard.Api.Domain.Mappers
{
    internal static class Mappers
    {
        extension(IDataRecord record)
        {
            internal Maison ToMaison()
            {
                return new Maison((Guid)record["Id"], (string)record["Nom"], (string)record["Fondateur"], (string)record["Couleur"], (string)record["Embleme"]);
            }

            internal Sorcier ToSorcier()
            {
                return new Sorcier((int)record["Id"], (string)record["Nom"], (string)record["Prenom"], (Guid)record["MaisonId"]);
            }
        }
    }
}
