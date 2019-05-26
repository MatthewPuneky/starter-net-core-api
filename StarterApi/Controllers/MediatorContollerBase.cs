using Microsoft.AspNetCore.Mvc;
using StarterApi.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarterApi.Controllers
{
    public class MediatorControllerBase : ControllerBase
    {
        public IActionResult Ok<TResponse>(Response<TResponse> response)
            where TResponse : class, new()
        {
            if (!response.IsValid) return BadRequest(response.ToEmptyData());
            return base.Ok(response);
        }

        public IActionResult Created<TResponse>(string uri, Response<TResponse> response)
            where TResponse : class, new()
        {
            if (!response.IsValid) return BadRequest(response.ToEmptyData());
            return base.Created(uri, response);
        }

        public IActionResult BadRequest<TResponse>(Response<TResponse> response)
            where TResponse : class, new()
        {
            return base.BadRequest(response);
        }
    }

    public static class ResponseHelpers
    {
        public static Response<object> ToEmptyData<T>(this Response<T> response)
            where T : class, new()
        {
            var emptyDataResponse = new Response<object>
            {
                Data = new object(),
                ErrorMessages = response.ErrorMessages
            };

            return emptyDataResponse;
        }
    }
}