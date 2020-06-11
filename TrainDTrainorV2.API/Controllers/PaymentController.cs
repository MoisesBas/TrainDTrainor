using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Annotations;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Payment.Commands;
using TrainDTrainorV2.Core.Domain.Payment.Models;
using TrainDTrainorV2.Core.Enum;
using TrainDTrainorV2.Core.Extensions;
using TrainDTrainorV2.Core.Services;

namespace TrainDTrainorV2.API.Controllers
{
    //[Authorize(Roles = "Administrator,Trainor,Trainee")]
    [SwaggerTag("CREATE, READ, UPDATE & DELETE Payment")]
    [Route("api/payment")]    
    public class PaymentController : MediatorCommandControllerBase<Guid,
        PaymentTransaction,
        PaymentReadModel,
        PaymentCreateModel,
        PaymentUpdateModel>
    {
        public PaymentController(IMediator mediator, IGridFsService gridFsService
            ) : base(mediator,gridFsService)
        {

        }
        // [FromForm]

        [HttpPost("insert")]
        [ProducesResponseType(typeof(PaymentReadModel), 200)]
        public async Task<IActionResult> Insert(CancellationToken cancellationToken,            
            [FromForm] PaymentCreateModel model)
        {
            var command = new PaymentCommand(model);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return ObjectResult(result, StatusCodes.Status200OK);
        }
        [HttpPost("Update")]
        [ProducesResponseType(typeof(PaymentReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken,
            Guid id,
            [FromForm] PaymentUpdateModel model)
        {
            var userAgent = Request.UserAgent();
            var command = new PaymentUpdateCommand<PaymentUpdateModel,Guid>(id,model,null,userAgent);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return ObjectResult(result, StatusCodes.Status200OK);
        }
         
        [HttpGet("approvals")]
        [ProducesResponseType(typeof(EntityListResult<PaymentDetailApprovalModel>), 200)]
        public async Task<IActionResult> Approvals(CancellationToken cancellationToken,
            string fullName,int page = 1, int pageSize = 20)
        {
            var search = Query<PaymentDetailApproval>.Create(x => x.FullName.ToUpper().Contains(string.Empty));
            var query = new EntityQuery<PaymentDetailApproval>(search, page, 20, null);
            var command = new PaymentApprovalReadCommand<PaymentDetailApproval>(query, (int)TrainDTrainorV2.Core.Enum.PaymentStatus.Submitted);
            var readModel = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = readModel,
                Status = StatusCodes.Status200OK
            });
        }
        [HttpGet("approvedpayments")]
        [ProducesResponseType(typeof(EntityListResult<PaymentDetailApprovalModel>), 200)]
        public async Task<IActionResult> ApprovedPayments(CancellationToken cancellationToken,
            string fullName, int page = 1, int pageSize = 20)
        {
            var search = Query<PaymentDetailApproval>.Create(x => x.FullName.ToUpper().Contains(string.Empty) && x.Status != (int)PaymentStatus.Submitted);
            search.IncludeProperties = @"UserProfile,UserProfile.User,Course";
            var query = new EntityQuery<PaymentDetailApproval>(search, page, 20, null);
            var command = new PaymentApprovalReadCommand<PaymentDetailApproval>(query, (int)PaymentStatus.Approved);
            var readModel = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return new OkObjectResult(new
            {
                Data = readModel,
                Status = StatusCodes.Status200OK
            });
        }

        [HttpPut("approved")]
        [ProducesResponseType(typeof(PaymentReadModel), 200)]
        public async Task<IActionResult> Approved(Guid id, CancellationToken cancellationToken)
        {
            var command = new PaymentApprovalCommand<Guid,PaymentTransaction,PaymentReadModel>(id, User, (int)PaymentStatus.Approved);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return ObjectResult(result, StatusCodes.Status200OK);           
        }

       
        [HttpPut("reject")]
        [ProducesResponseType(typeof(PaymentReadModel), 200)]
        public async Task<IActionResult> Reject(Guid id, CancellationToken cancellationToken)
        {
            var command = new PaymentApprovalCommand<Guid, PaymentTransaction, PaymentReadModel>(id, User, (int)PaymentStatus.Reject);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return ObjectResult(result, StatusCodes.Status200OK);            
        }
        
        [HttpPut("canceled")]
        [ProducesResponseType(typeof(PaymentReadModel), 200)]
        public async Task<IActionResult> Cancelled(Guid id, CancellationToken cancellationToken)
        {
            var command = new PaymentApprovalCommand<Guid, PaymentTransaction, PaymentReadModel>(id, User, (int)PaymentStatus.Canceled);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return ObjectResult(result, StatusCodes.Status200OK);
        }       

        [HttpGet("getpaymentByuserId")]
        [ProducesResponseType(typeof(PaymentReadModel), 200)]
        public async Task<IActionResult> GetPaymentByuserId(CancellationToken cancellationToken, Guid? userProfileId)
        {            
           ////////////
            var command = new PaymentGetCommand(userProfileId);
            var result = await Mediator.Send(command,cancellationToken).ConfigureAwait(false);
            return ObjectResult(result, StatusCodes.Status200OK);
        }
        [HttpGet("getpaymentreceiptByuserId")]
        [ProducesResponseType(typeof(FileStreamResult), 200)]
        public async Task<FileStreamResult> GetPaymentReceiptByuserId(CancellationToken cancellationToken, Guid? userProfileId)
        {
            var command = new PaymentGetCommand(userProfileId);
            var result = await Mediator.Send(command,cancellationToken).ConfigureAwait(false);
            var memory = new MemoryStream();
            using (var stream = new FileStream(result.PaymentPicPath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(result.PaymentPicPath), Path.GetFileName(result.PaymentPicPath));
        }
        
    }
}