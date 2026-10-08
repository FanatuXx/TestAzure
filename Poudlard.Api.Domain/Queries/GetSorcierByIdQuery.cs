using Poudlard.Api.Domain.Entities;
using Tools.CommandQuerySeparation;

namespace Poudlard.Api.Domain.Queries
{
    public class GetSorcierByIdQuery : IQueryDefinition<Sorcier>
    {
        public int Id { get; }

        public GetSorcierByIdQuery(int id)
        {
            Id = id;
        }
    }
}
