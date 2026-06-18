using FluentResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookOnline.Shared.Results
{
 
    public class UnauthorizedError : Error
    {
        public UnauthorizedError(string message) : base(message)
        {

        }
    }

    public class NotFoundError : Error
    {
        public NotFoundError(string message) : base(message)
        {
            // می‌توانید متادیتای اضافه هم اینجا اضافه کنید
            Metadata.Add("ErrorCode", 404);
        }
    }

    public class ValidationError : Error
    {
        public List<string> Errors { get; set; } = new();

        // سازنده ۱: برای زمانی که فقط یک پیام متنی ساده دارید
        public ValidationError(string message) : base(message)
        {
            Metadata.Add("ErrorCode", 400);
            Errors.Add(message);
        }

        // سازنده ۲: برای زمانی که لیستی از خطاهای Identity را دارید
        public ValidationError(IEnumerable<string> errorMessages)
            : base("یک یا چند خطای اعتبار‌سنجی رخ داده است.")
        {
            Metadata.Add("ErrorCode", 400); // کد ۴۰۰ را اینجا هم اضافه می‌کنیم
            Errors.AddRange(errorMessages);
        }
    }
}
