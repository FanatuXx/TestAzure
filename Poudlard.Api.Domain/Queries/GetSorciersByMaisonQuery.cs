using Poudlard.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.CommandQuerySeparation;

namespace Poudlard.Api.Domain.Queries
{
    public class GetSorciersByMaisonQuery : IQueryDefinition<IEnumerable<Sorcier>>
    {
        public Guid MaisonId { get; }

        public GetSorciersByMaisonQuery(Guid maisonId)
        {
            MaisonId = maisonId;
        }
    }
}
