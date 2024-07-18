using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebScrape.Service.DTOs;

namespace WebScrape.API
{
    public static class ValidationResponseExtension
    {
        public static async Task<IActionResult> Process<T>(this Task<T> requestResult, Func<T, IActionResult> response)
            where T : BaseResult
        {
            var result = await requestResult;
            if (result == null)
                throw new ArgumentNullException("Result cannot be null");

            if (result.Errors != null)
                return new JsonResult(result.Errors)
                { StatusCode = (int)HttpStatusCode.BadRequest };

            return response.Invoke(result);
        }
    }
}