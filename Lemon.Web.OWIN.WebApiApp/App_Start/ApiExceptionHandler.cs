using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using Lemon.Web.OWIN.WebApiApp.Models;


namespace Lemon.Web.OWIN.WebApiApp
{
    /// <summary>
    /// 全局错误处理
    /// </summary>
    public class ApiExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="context"></param>
        public override void Handle(ExceptionHandlerContext context)
        {
            var metadata = new ErrorInfoModel
            {
                Message = "An unexpected error occurred! Please use the Error ID to contact support",
                TimeStamp = DateTime.UtcNow,
                RequestUri = context.Request.RequestUri,
                ErrorId = Guid.NewGuid()
            };

            //TODO 记日志
            //全局错误处理
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, metadata/*TODO 错误数据*/);
            context.Result = new ResponseMessageResult(response);


            
           


        }
    }
}