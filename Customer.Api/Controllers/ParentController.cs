using Customer.Service.EventHandlers.Commands;
using Customer.Service.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order.Service.Queries;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("v1/parents")]
    public class ParentController : ControllerBase
    {
        private readonly IParentQueryService _parentQueryService;
        private readonly ILogger<ParentController> _logger;
        private readonly IMediator _mediator;

        public ParentController(
            ILogger<ParentController> logger,
            IMediator mediator,
            IParentQueryService parentQuerService)
        {
            _logger = logger;
            _mediator = mediator;
            _parentQueryService = parentQuerService;
        }

        [HttpGet]
        public async Task<DataCollection<ParentDto>> GetAll(int page = 1, int take = 10, string ids = null) 
        {
            IEnumerable<int> parents = null;

            if (!string.IsNullOrEmpty(ids)) 
            {
                parents = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _parentQueryService.GetAllAsync(page, take, parents);
        }

        [HttpGet("{id}")]
        public async Task<ParentDto> Get(int id)
        {
            return await _parentQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ParentCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }
    }
}
