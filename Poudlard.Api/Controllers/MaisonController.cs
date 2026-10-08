using Microsoft.AspNetCore.Mvc;
using Poudlard.Api.Domain.Entities;
using Poudlard.Api.Domain.Queries;
using Poudlard.Api.Domain.Repositories;
using Poudlard.Api.Infrastructure;
using System.Net.Sockets;
using Tools.Results;

namespace Poudlard.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MaisonController : ControllerBase
    {
        private readonly IMaisonRepository _maisonService;

        public MaisonController(IMaisonRepository maisonService)
        {
            _maisonService = maisonService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return this.FromResult(_maisonService.Handle(new GetMaisonQuery()));                        
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return this.FromResult(_maisonService.Handle(new GetMaisonByIdQuery(id)));
        }
    }
}
