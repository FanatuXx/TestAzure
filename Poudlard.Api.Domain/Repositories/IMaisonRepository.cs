using Poudlard.Api.Domain.Entities;
using Poudlard.Api.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.CommandQuerySeparation;

namespace Poudlard.Api.Domain.Repositories
{
    public interface IMaisonRepository :
        IQueryHandler<GetMaisonQuery, IEnumerable<Maison>>,
        IQueryHandler<GetMaisonByIdQuery, Maison>
    {
    }
}
