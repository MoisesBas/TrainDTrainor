using System;
using TrainDTrainorV2.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TrainDTrainorV2.Core.Services;
using Microsoft.Extensions.Caching.Memory;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorModel), 422)]
    [ProducesResponseType(typeof(ErrorModel), 500)]
    public abstract class MediatorControllerBase : ControllerBase
    {
        protected MediatorControllerBase(IMediator mediator)
        {
            Mediator = mediator;
        }
        protected MediatorControllerBase(IMediator mediator,
            IGridFsService gridFsService)
        {
            Mediator = mediator;
            GridFsService = gridFsService;
        }

        protected MediatorControllerBase(IMediator mediator, IAppCache cache)
        {
            Mediator = mediator;
            Cache = cache;
        }
        protected MediatorControllerBase(IMediator mediator,
            IGridFsService gridFsService, IAppCache cache)
        {
            Mediator = mediator;
            GridFsService = gridFsService;
            Cache = cache;
        }
        public IMediator Mediator { get; }
        public IGridFsService GridFsService { get; }
        public IAppCache Cache { get; set; }
    }
}