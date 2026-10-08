using Poudlard.Api.Domain.Commands;
using Poudlard.Api.Domain.Entities;
using Poudlard.Api.Domain.Queries;
using Tools.CommandQuerySeparation;

namespace Poudlard.Api.Domain.Repositories
{
    public interface ISorcierRepository :
        ICommandHandler<AjoutSorcierCommand, int>,
        IQueryHandler<GetSorciersQuery, IEnumerable<Sorcier>>,
        IQueryHandler<GetSorcierByIdQuery, Sorcier>,
        IQueryHandler<GetSorciersByMaisonQuery, IEnumerable<Sorcier>>,
        ICommandHandler<ChangeMaisonSorcierCommand>
    {
    }
}
