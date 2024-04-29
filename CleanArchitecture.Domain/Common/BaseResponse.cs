using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Common
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string ResponseMessage { get; set; }
        public object? Data { get; set; }
        public BaseResponse(bool success, int statusCode, string responseMessage, object? data = null)
        {
            IsSuccess = success;
            StatusCode = statusCode;
            ResponseMessage = responseMessage;
            Data = data;
        }
    }
}
