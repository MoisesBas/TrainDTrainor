using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TrainDTrainorV2.API.Utility
{
    public class PushStreamResult : IActionResult
    {
        Func<Stream, CancellationToken, Task> _pushAction;
        string _contentType;

        public PushStreamResult(Func<Stream, CancellationToken, Task> pushAction, 
            string contentType)
        {
            _pushAction = pushAction;
            _contentType = contentType;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = _contentType;
            response.StatusCode = 200;
            return _pushAction(response.Body, context.HttpContext.RequestAborted);
        }

        //public Task ExecuteResultAsync(ActionContext context)
        //{
        //    var stream = context.HttpContext.Response.Body;
        //    context.HttpContext.Response.GetTypedHeaders().ContentType = new MediaTypeHeaderValue(_contentType);
        //    _onStreamAvailabe(stream);
        //    return Task.CompletedTask;
        //}
    }
}
