using Poudlard.Api.Domain.Entities;
using Tools.CommandQuerySeparation;

namespace Poudlard.Api.Domain.Queries
{
    public class GetSorciersQuery : IQueryDefinition<IEnumerable<Sorcier>>
    {
    }
}
