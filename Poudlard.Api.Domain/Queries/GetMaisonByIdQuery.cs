using Poudlard.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.CommandQuerySeparation;

namespace Poudlard.Api.Domain.Queries
{
    public class GetMaisonByIdQuery : IQueryDefinition<Maison>
    {
        public Guid Id { get; }

        public GetMaisonByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
