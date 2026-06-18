using System;
using System.Collections.Generic;
using System.Linq;

namespace BookOnline.Shared.Results
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; } // اضافه کردن این فیلد
        public T? Data { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }

        public static ApiResult<T> Success(T data, string? message = null)
        {
            return new ApiResult<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message,
                StatusCode = 200
            };
        }

        public static ApiResult<T> Failure(IEnumerable<string> errors, int statusCode = 400) =>
            new() { IsSuccess = false, Errors = errors.ToList(), StatusCode = statusCode };

        public static ApiResult<T> Failure(string message, int statusCode = 400) =>
            new() { IsSuccess = false, Message = message, StatusCode = statusCode };
    }

    #region Implicit Operator
    //Implicit Operator
    // تبدیل خودکار داده (DTO) به ApiResult موفق
    //public static implicit operator ApiResult<T>(T data)
    //{
    //    return ApiResult<T>.Success(data);
    //}

    //// (اختیاری) تبدیل خودکار خطای رشته‌ای به ApiResult ناموفق
    //public static implicit operator ApiResult<T>(string errorMessage)
    //{
    //    return ApiResult<T>.NotFound(errorMessage);
    //}
    #endregion
}
