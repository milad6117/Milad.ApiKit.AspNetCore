
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOnline.Shared.Results;
using FluentResults;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BookOnline.Shared.Validation
{
    public static class ValidationExtensions
    {
        public static ValidationError ToResultError(this FluentValidation.Results.ValidationResult validationResult)
        {
            // تمام پیام‌های خطا را از FluentValidation استخراج می‌کند
            var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage);

            // از سازنده دوم کلاس خودت (ValidationError) استفاده می‌کند که IEnumerable می‌گرفت
            return new ValidationError(errorMessages);
        }


        public static async Task<Result<TResponse>> ValidateDtoAsync<TRequest, TResponse>(
         this IServiceProvider serviceProvider, TRequest dto)
        {
            // پیدا کردن ولیدیتور مناسب برای این DTO از توی سرویس‌های ثبت شده
            var validator = serviceProvider.GetService<IValidator<TRequest>>();

            if (validator == null) return null; // یا اگر ولیدیتور نبود، فرض رو بر صحت بزار

            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                // استفاده از اکستنشن متدی که قبلاً برای تبدیل خطاها داشتی
                return Result.Fail<TResponse>(validationResult.ToResultError());
            }

            return null; // یعنی خطایی وجود ندارد
        }
    }
}
