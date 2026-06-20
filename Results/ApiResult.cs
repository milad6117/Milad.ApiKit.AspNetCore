using System;
using System.Collections.Generic;
using System.Linq;

namespace Milad.ApiKit.AspNetCore.Results
{

    public class ApiResult<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }

        public static ApiResult<T> Success(T data, string? message = null)
            => new()
            {
                IsSuccess = true,
                Data = data,
                Message = message,
                StatusCode = 200
            };

        public static ApiResult<T> Failure(List<string> errors, int statusCode = 400)
            => new()
            {
                IsSuccess = false,
                Errors = errors,
                StatusCode = statusCode
            };

        public static ApiResult<T> Failure(string message, int statusCode = 400)
            => new()
            {
                IsSuccess = false,
                Message = message,
                StatusCode = statusCode
            };
    }

}
