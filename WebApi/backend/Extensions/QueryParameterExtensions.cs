using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Extensions
{
    public static class QueryParameterExtensions
    {
        public static bool IsDescending(this QueryParameters queryParameters)
        {
            if (!string.IsNullOrEmpty(queryParameters.OrderBy))
            {
                queryParameters.OrderBy.Split(' ').Last().ToLowerInvariant().StartsWith("desc");
            }

            return false;
        }
    }
}
