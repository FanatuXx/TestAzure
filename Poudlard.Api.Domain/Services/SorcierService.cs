using BStorm.Tools.Database;
using Microsoft.Extensions.Logging;
using Poudlard.Api.Domain.Commands;
using Poudlard.Api.Domain.Entities;
using Poudlard.Api.Domain.Errors;
using Poudlard.Api.Domain.Mappers;
using Poudlard.Api.Domain.Queries;
using Poudlard.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Tools.Results;

namespace Poudlard.Api.Domain.Services
{
    public class SorcierService : ISorcierRepository
    {
        private readonly DbConnection _dbConnection;
        private readonly ILogger _logger;

        public SorcierService(DbConnection dbConnection, ILogger<SorcierService> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }

        public Result<int> Handle(AjoutSorcierCommand command)
        {
            try
            {
                return Result<int>.Success((int)_dbConnection.ExecuteScalar("INSERT INTO Sorcier (Nom, Prenom, MaisonId) OUTPUT inserted.Id VALUES (@Nom, @Prenom, @MaisonId)", parameters: command)!);
            }
            catch (Exception)
            {
                return SorcierErrors.SorcierException;
            }
        }

        public Result<IEnumerable<Sorcier>> Handle(GetSorciersQuery query)
        {
            try
            {
                return Result<IEnumerable<Sorcier>>.Success(_dbConnection.ExecuteReader("SELECT Id, Nom, Prenom, MaisonId FROM Sorcier;", r => r.ToSorcier()).ToArray());
            }
            catch (Exception)
            {
                return SorcierErrors.SorcierException;
            }
        }

        public Result<Sorcier> Handle(GetSorcierByIdQuery query)
        {
            try
            {
                return Result<Sorcier>.Success(_dbConnection.ExecuteReader("SELECT Id, Nom, Prenom, MaisonId FROM Sorcier Where Id = @Id;", r => r.ToSorcier(), parameters: query).Single());
            }
            catch (Exception)
            {
                return SorcierErrors.SorcierException;
            }
        }

        public Result<IEnumerable<Sorcier>> Handle(GetSorciersByMaisonQuery query)
        {
            try
            {
                return Result<IEnumerable<Sorcier>>.Success(_dbConnection.ExecuteReader("SELECT Id, Nom, Prenom, MaisonId FROM Sorcier WHERE MaisonId = @MaisonId;", r => r.ToSorcier(), parameters: query).ToArray());
            }
            catch (Exception)
            {
                return SorcierErrors.SorcierException;
            }
        }

        public Result Handle(ChangeMaisonSorcierCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("UPDATE Sorcier SET MaisonId = @MaisonId WHERE Id = @SorcierId AND MaisonId != @MaisonId", parameters: command);

                if (rows == 0)
                    return SorcierErrors.SorcierUnmodified;

                if (rows > 1)
                    return Error.Create("Sorcier.TooLineModified", "Too many lines are modified");

                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return SorcierErrors.SorcierException;
            }
        }
    }
}
