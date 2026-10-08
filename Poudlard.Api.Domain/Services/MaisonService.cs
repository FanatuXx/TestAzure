using BStorm.Tools.Database;
using Poudlard.Api.Domain.Entities;
using Poudlard.Api.Domain.Mappers;
using Poudlard.Api.Domain.Queries;
using Poudlard.Api.Domain.Repositories;
using System.Data.Common;
using Tools.Results;

namespace Poudlard.Api.Domain.Services
{
    public class MaisonService : IMaisonRepository
    {
        private readonly DbConnection _dbConnection;

        public MaisonService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Result<IEnumerable<Maison>> Handle(GetMaisonQuery query)
        {
            try
            {
                return Result<IEnumerable<Maison>>.Success(_dbConnection.ExecuteReader("SELECT Id, Nom, Fondateur, Couleur, Embleme FROM Maison;", r => r.ToMaison()).ToArray());
            }
            catch (Exception)
            {
                return Error.Create("Maison.Exception", "An exception was throw");
            }
        }

        public Result<Maison> Handle(GetMaisonByIdQuery query)
        {
            try
            {
                return Result<Maison>.Success(_dbConnection.ExecuteReader("SELECT Id, Nom, Fondateur, Couleur, Embleme FROM Maison Where Id = @Id;", r => r.ToMaison(), parameters: query).Single());
            }
            catch (Exception)
            {
                return Error.Create("Maison.Exception", "An exception was throw");
            }
        }
    }
}
