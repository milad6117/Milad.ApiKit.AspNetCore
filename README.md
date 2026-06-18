\# Milad.ApiKit.AspNetCore



Milad.ApiKit.AspNetCore is a lightweight toolkit for building clean ASP.NET Core APIs.



\## Features



\- Result Pattern

\- ApiResult

\- Custom Errors

\- Pagination

\- FluentResults integration



\# Milad.ApiKit.AspNetCore



\[!\[NuGet](https://img.shields.io/nuget/v/Milad.ApiKit.AspNetCore.svg)](https://www.nuget.org/packages/Milad.ApiKit.AspNetCore)

\[!\[NuGet Downloads](https://img.shields.io/nuget/dt/Milad.ApiKit.AspNetCore.svg)](https://www.nuget.org/packages/Milad.ApiKit.AspNetCore)

\[!\[GitHub Actions](https://github.com/milad6117/Milad.ApiKit.AspNetCore/actions/workflows/publish.yml/badge.svg)](https://github.com/milad6117/Milad.ApiKit.AspNetCore/actions)

\[!\[License](https://img.shields.io/github/license/milad6117/Milad.ApiKit.AspNetCore)](LICENSE)

\[!\[.NET](https://img.shields.io/badge/.NET-10-512BD4)](https://dotnet.microsoft.com/)

\[!\[C#](https://img.shields.io/badge/C%23-13-239120)](https://learn.microsoft.com/dotnet/csharp/)



A lightweight ASP.NET Core toolkit that provides Result Pattern, API Response, Pagination, Custom Errors, and other reusable building blocks for modern APIs.



Markdown



\## Installation



Install the package using the .NET CLI:



dotnet add package Milad.ApiKit.AspNetCore

Or install it from NuGet Package Manager in Visual Studio.



\## Usage



\### Result



var result = Result.Success();



if(result.IsSuccess)

{

&#x20;   Console.WriteLine("Success");

}

\### Failure



var result = Result.Failure(CustomErrors.NotFound("Book"));



if(result.IsFailed)

{

&#x20;   Console.WriteLine(result.Errors.First().Message);

}

\### Pagination



var response = new PaginationResult<BookDto>(

&#x20;   items,

&#x20;   totalCount,

&#x20;   page,

&#x20;   pageSize);

\## License



MIT License

