using Microsoft.AspNetCore.Mvc;
using Poudlard.Api.Domain.Commands;
using Poudlard.Api.Domain.Entities;
using Poudlard.Api.Domain.Queries;
using Poudlard.Api.Domain.Repositories;
using Poudlard.Api.Dtos;
using Poudlard.Api.Infrastructure;
using Tools.Results;

namespace Poudlard.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SorcierController : ControllerBase
    {
        private readonly ISorcierRepository _sorcierRepository;
        private readonly IMaisonRepository _maisonRepository;

        public SorcierController(ISorcierRepository sorcierRepository, IMaisonRepository maisonRepository)
        {
            _sorcierRepository = sorcierRepository;
            _maisonRepository = maisonRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return this.FromResult(_sorcierRepository.Handle(new GetSorciersQuery()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Result<Sorcier> result = _sorcierRepository.Handle(new GetSorcierByIdQuery(id));

            if(result.IsFailure)
                return this.FromResult(result);

            Result<Maison> resultMaison = _maisonRepository.Handle(new GetMaisonByIdQuery(result.Data.MaisonId));

            return Ok(new { result.Data.Id, result.Data.Nom, result.Data.Prenom, result.Data.MaisonId, Maison = resultMaison.Data });           
        }

        [HttpGet("ParMaison/{maisonId}")]
        [HttpGet("/api/maison/{maisonId}/sorciers")]
        public IActionResult Get(Guid maisonId)
        {
            return this.FromResult(_sorcierRepository.Handle(new GetSorciersByMaisonQuery(maisonId)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreerSorcierDto dto)
        {            
            Result<int> result = _sorcierRepository.Handle(new AjoutSorcierCommand(dto.Nom, dto.Prenom, dto.MaisonId));
                
            if(result.IsFailure)
                return BadRequest(result.Error);

            return Created($"https://localhost:7050/api/sorcier/{result.Data}", null);            
        }

        [HttpPatch]
        [HttpPut]
        public IActionResult ChangeMaison(ChangeMaisonDto dto)
        {
            return this.FromResult(_sorcierRepository.Handle(new ChangeMaisonSorcierCommand(dto.IdSorcier, dto.IdMaison)));
        }

        [HttpGet("test")]
        public IActionResult Test([FromQuery] TestDto dto)
        {
            //Uri to test : https://localhost:7050/api/Sorcier/test?intValue=42&word=toto
            return Ok(dto);
        }


        //(N'28fe6773-670d-4ba8-bc19-3e59fc154a1e', N'Gryffondor', N'Godric Gryffondor', N'Rouge/Or', N'Lion')
        //(N'0603ca10-46aa-4aeb-ab9a-69a89e9e34cb', N'Serpentard', N'Salazar Serpentard', N'Vert/Argent', N'Serpent')
        //(N'19d6ca50-3f0b-42f2-9c7f-84a4438ce92d', N'Poufsouffle', N'Helga Poufsouffle', N'Jaune/Noir', N'Blaireau')
        //(N'e68d1fa2-eceb-4284-b576-be5c37372896', N'Serdaigle', N'Rowena Serdaigle', N'Bleu/Argent', N'Aigle')
    }
}
